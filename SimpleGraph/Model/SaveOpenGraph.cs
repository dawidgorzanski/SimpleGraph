using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGraph.Model
{
    //Pamiętać o zamknięciu pliku - można użyć "using(new ..." i wtedy plik się zawsze zamknie
    public static class SaveOpenGraph
    {
        public static void SaveToFile(string Graph)
        {
            File.WriteAllText("C:\\Users\\IgnoRant\\Desktop\\test2.tx", Graph);
           // return true;
        }

        public static int[][] ReadFromFile(string FilePath)
        {
            string text = null;
            int[][] MatrixInt = null;
            using (TextReader reader = File.OpenText("C:\\Users\\IgnoRant\\Desktop\\file.txt"))
            {
                //Variable- zmienna używana do otrzymywania wartości z funkcji TryParse 
                int Variable;
                text = reader.ReadToEnd();

                //lines- tablica liń naszej macierzy
                string[] lines = text.Split('\n');

                //Dimenion to wymiar naszej macierzy
                int Dimension = lines.Length;

                //Sprawdzenie czy ostania linia nie jest pusta jeśli tak to zmiejszam rozmiar
                foreach (string line in lines)
                {
                    string[] numbers = line.Split(' ');

                    if (numbers.Length == 1)
                        Dimension--;
                }

                //Counter liczy abyśmy nie przeszli przypadkiem do pustej lini i tam coś robili
                int Counter = 0;
                //Sprawdzenie czy macierz jest odpowiedniego wymiaru

                foreach (string line in lines)
                {
                    
                    string[] numbers = line.Split(' ');

                    if (Dimension == numbers.Length - 1)
                    {
                        if (Int32.TryParse(numbers[numbers.Length - 1], out Variable))
                        {
                            text = null;
                            break;
                        }
                    }
                    else if (Dimension == numbers.Length)
                    {
                        if (Int32.TryParse(numbers[numbers.Length - 1], out Variable) == false)
                        {
                            Console.WriteLine(line);
                            text = null;
                            break;
                        }
                    }
                    else
                    {
                        text = null;
                        break;
                    }

                    Counter++;
                    if (Counter == Dimension)
                        break;
                }
                //Inicjalizacja MatrixInt
                MatrixInt = new int[Dimension][];
                for (int i = 0; i < Dimension; i++)
                {
                    MatrixInt[i] = new int[Dimension];
                }
                //Sprawdzenie czy w macierzy są tylko 0 i 1
                for (int i = 0; i < Dimension; i++)
                {
                    string[] numbers = lines[i].Split(' ');

                    for (int j = 0; j < Dimension; j++)
                    {
                        if (int.TryParse(numbers[j], out Variable) != true)
                        {
                            text = null;
                            break;
                        }
                        if (Variable != 1 && Variable != 0)
                        {
                            text = null;
                            break;
                        }
                        MatrixInt[i][j] = Variable;
                    }
                }

                for (int i = 0; i < Dimension; i++)
                {
                    for (int j = 0; j < Dimension; j++)
                    {
                        if (MatrixInt[i][j] != MatrixInt[j][i])
                        {
                            text = null;
                            break;
                        }
                    }
                }
                for(int i=0;i<Dimension;i++)
                {
                    if (MatrixInt[i][i] == 1)
                        text = null;
                }
            }
            
            return MatrixInt;
        }
    }
}

