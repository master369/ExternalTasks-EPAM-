using System.IO;
using System.Text.RegularExpressions;

namespace _6._1.DAL.TextFiles
{
    class DAOHelper
    {
        static public void ReplaceInFile(string filePath, string searchText, string replaceText)
        {
            string content;

            using (StreamReader reader = new StreamReader(filePath))
            {
                content = reader.ReadToEnd();
            }

            content = Regex.Replace(content, searchText, replaceText);


            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(content);
            }
        }
    }
}
