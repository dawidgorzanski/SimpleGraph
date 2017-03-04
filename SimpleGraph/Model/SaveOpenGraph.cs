using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraph.Model
{
    //Pamiętać o zamknięciu pliku - można użyć "using(new ..." i wtedy plik się zawsze zamknie
    public static class SaveOpenGraph
    {
        public static bool SaveToFile(string Graph)
        {
            //TODO
            return true;
        }

      public static string ReadFromFile(string FilePath)
        {
            string text = null;
            using (TextReader reader = File.OpenText("C:\\Users\\IgnoRant\\Desktop\\test.txt"))
            {
                text = reader.ReadToEnd();
                string[] lines = text.Split('\n');
                foreach(string line in lines)
                {
                    string[] numbers = line.Split(' ');
                    if(lines.Length!=numbers.Length)
                    {
                        text = null;
                        break;
                    }
                    foreach(string Char in numbers)
                    {
                        if(Char!="1"&&Char!="0")
                        {
                            text = null;
                            break;
                        }
                    }
                }
            }
            return text;
        }
    }
}
