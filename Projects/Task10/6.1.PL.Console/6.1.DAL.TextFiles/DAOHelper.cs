using _6._1.Common.Entities;
using _6._1.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

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
