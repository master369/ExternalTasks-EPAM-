using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Task_5
{
    public partial class Form1 : Form
    {
        FileSystemWatcher watcher;
        DateTime TableDT;
        bool flagChange;
        int posStartChange;

        public Form1()
        {
            InitializeComponent();
            flagChange = false;
        }
        private int changeNumber;
        private void button1_Click(object sender, EventArgs e)
        {
            var system = Environment.GetFolderPath(Environment.SpecialFolder.System);
            var path = Path.GetPathRoot(system);
            var LocateChangesFolder = path + "changes";
            var LocateDublicateFolder = path + "duplicate";

            watcher = new FileSystemWatcher(textInput.Text.ToString(), "*.txt");
            dataGridView1.Rows.Clear();
            dataGridView1.Refresh();
            changeNumber = 0;

            if (Directory.Exists(LocateDublicateFolder))
            {
                Directory.Delete(LocateDublicateFolder, true);
            }

            if (Directory.Exists(LocateChangesFolder))
            {
                Directory.Delete(LocateChangesFolder, true);
            }

            if (!Directory.Exists(textInput.Text))
            {
                Directory.CreateDirectory(textInput.Text);
            }

            Directory.CreateDirectory(LocateDublicateFolder);

            Directory.CreateDirectory(LocateChangesFolder);

            DirectoryCopy(textInput.Text, LocateDublicateFolder, true);
            watcher.EnableRaisingEvents = false;
            watcher.IncludeSubdirectories = false;//посмотр подпапок
            watcher.IncludeSubdirectories = true;
            watcher.Changed += watcher_Changed;
            watcher.Created += watcher_Created;
            watcher.Deleted += watcher_Deleted;
            watcher.Renamed += watcher_Renamed;

            watcher.EnableRaisingEvents = true;
            button1.Visible = false;
            richTextBox1.AppendText("Включен режим наблюдения \r\n");
        }

        private void watcher_Renamed(object sender, RenamedEventArgs e)
        {
            richTextBox1.Invoke((MethodInvoker)delegate
            {
                richTextBox1.AppendText("Выполнено переименование файла: " + e.FullPath + "\n");
            });

            AddChangeTable(e.FullPath, "1");

            dataGridView1.Invoke((MethodInvoker)delegate
            {
                dataGridView1[3, dataGridView1.RowCount - 2].Value += " " + e.OldFullPath;
            });

        }

        private void watcher_Deleted(object sender, FileSystemEventArgs e)
        {
            richTextBox1.Invoke((MethodInvoker)delegate
            {
                richTextBox1.AppendText("Выполнено удаление файла: " + e.FullPath + "\n");
            });

            AddChangeTable(e.FullPath, "2");
        }


        private void watcher_Created(object sender, FileSystemEventArgs e)
        {
            richTextBox1.Invoke((MethodInvoker)delegate
            {
                richTextBox1.AppendText("Выполнено создание файла: " + e.FullPath + "\n");
            });
            AddChangeTable(e.FullPath, "3");

            AddChangeFolder(e);
        }

        private void watcher_Changed(object sender, FileSystemEventArgs e)
        {
            richTextBox1.Invoke((MethodInvoker)delegate
            {
                richTextBox1.AppendText("Выполнено изменение файла: " + e.FullPath + "\n");
            });
            AddChangeTable(e.FullPath, "4");

            AddChangeFolder(e);
        }

        private void AddChangeTable(string path, string typeChange)
        {
            DateTime dateNow = DateTime.Now;
            changeNumber++;
            string str = dateNow.ToString("yyyy.MM.dd HH:mm:ss");

            dataGridView1.Invoke((MethodInvoker)delegate
            {
                dataGridView1.Rows.Add(changeNumber.ToString(), str, typeChange, path);
            });
        }

        private void AddChangeFolder(FileSystemEventArgs e)
        {
         
            var system = Environment.GetFolderPath(Environment.SpecialFolder.System);
            var path = Path.GetPathRoot(system);
            var LocateChangesFolder = path + "changes";
            var LocateDublicateFolder = path + "duplicate";
            string str = Path.Combine(LocateChangesFolder, changeNumber.ToString());
            Directory.CreateDirectory(str);
            //str = Path.Combine(str, e.Name);
            //str = Path.Combine(str, changeNumber.ToString(), ".txt");
            //ДОБАВИТЬ ПРОВЕРКА ЯВЛЯЕТСЯ ЛИ ФАЙЛ ПАПКОЙ 
            if (e.FullPath.IndexOf(".") > 0 && !Directory.Exists(e.FullPath))
            {
                str = str + "\\" + changeNumber.ToString() + e.Name.Substring(e.Name.LastIndexOf("."), e.Name.Length - e.Name.LastIndexOf(".")); //".txt";
                File.Copy(e.FullPath, str, overwrite: true);
                dataGridView1[4, changeNumber - 1].Value = str;
            }
            else
            {
                str = str + "\\" + changeNumber.ToString();
                dataGridView1[4, changeNumber - 1].Value = str;
                DirectoryCopy(e.FullPath, str, true);
            }
        }


        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }


        private string SearchFullPathInArchive(string filePath)
        {
            int i;
            string str;
            string tablePathStr;
            string typeChangeStr;

            for (i = dataGridView1.RowCount - 2; i >= 0; i--)
            {
                tablePathStr = dataGridView1[3, i].Value.ToString();
                typeChangeStr = dataGridView1[2, i].Value.ToString();

                if (tablePathStr.IndexOf(filePath) >= 0)
                {
                    if (int.Parse(typeChangeStr) > 2)//если нашли в таблице создание или изменение файла
                        break;
                    else if (int.Parse(typeChangeStr) == 1)//если нашли ПЕРЕИМЕНОВАНИЕ файла
                        filePath = tablePathStr.Substring(0, tablePathStr.IndexOf(" "));
                }

            }
            if (i < 0)
            {
                str = filePath.Replace("duplicate", "temp");
            }
            else
                str = dataGridView1[4, i].Value.ToString();

            return str;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Invoke((MethodInvoker)delegate
            {
                richTextBox1.Clear();
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh(); 
            });
        }

        private void SelectCatalogButton_Click(object sender, EventArgs e)
        {


            FolderBrowserDialog openFolderDialog1 = new FolderBrowserDialog();
            if (openFolderDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    textInput.Text = openFolderDialog1.SelectedPath;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Path.Combine("Error: Could not read file from disk. Original error: ", ex.Message));
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            watcher.EnableRaisingEvents = false;
            var system = Environment.GetFolderPath(Environment.SpecialFolder.System);
            var path = Path.GetPathRoot(system);
            var LocateChangesFolder = path + "changes";
            var LocateDublicateFolder = path + "duplicate";

            if (Directory.Exists(textInput.Text))
            {
                foreach (string file in Directory.GetFiles(textInput.Text))
                    File.Delete(file);

                foreach (string file in Directory.GetDirectories(textInput.Text))
                    Directory.Delete(file, true);
            }


            DirectoryCopy(LocateDublicateFolder, textInput.Text, true);


            string[] str;

            int TypeChange;
            int i;//РАБОТАЕТ БОЛЕЕ РАННИЙ ОТКАТ ПРИ ТЕКУЩЕМ ОТКАТЕ
            for (i = (flagChange) ? posStartChange : dataGridView1.RowCount - 2; i >= 0; i--)
            {
                TableDT = DateTime.Parse(dataGridView1[1, i].Value.ToString(), CultureInfo.InvariantCulture);
                TypeChange = int.Parse(dataGridView1[2, i].Value.ToString());

                string strFile = dataGridView1[3, i].Value.ToString();
                switch (TypeChange)
                {
                    case 1://ПЕРЕИМЕНОВАНИЕ
                        {
                            str = strFile.Split(new Char[] { ' ' },
                                StringSplitOptions.RemoveEmptyEntries);
                            //File.Move(str[0], str[1]);//ПЕРЕИМЕНОВАНИЕ
                        }
                        break;

                    case 2://УДАЛЕНИЕ
                        {
                            if (strFile.IndexOf(".txt") > 0)
                                File.Copy(SearchFullPathInArchive(strFile),
                                        strFile, true);
                            else
                                Directory.CreateDirectory(strFile);

                        }
                        break;

                    case 3: //СОЗДАНИЕ
                        File.Delete(strFile); break;

                    case 4://ИЗМЕНЕНИЕ
                        {

                            File.Delete(strFile);
                            File.Copy(SearchFullPathInArchive(strFile), strFile, true);
                        }
                        break;
                    default: break;
                }

                posStartChange = i - 1;
                flagChange = true;

            }
            button1.Visible = true;
            richTextBox1.AppendText("Откат прошел успешно \r\n");
        }

    }
}
