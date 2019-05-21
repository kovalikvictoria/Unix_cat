using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Unix_cat.Concrete
{
    public static class CatOptions
    {
        private readonly static string version = "1.0";

        public static bool Cat(string pathToFile1, string pathToFile2, string pathToOutput = null)
        {
            try
            {
                string[] file1 = File.ReadAllLines(pathToFile1);
                string[] file2 = File.ReadAllLines(pathToFile2);
                string[] output = new string[file1.Length + file2.Length];
                int counter = 1;

                foreach (string str in file1)
                {
                    output[counter - 1] = str;
                    counter += 1;
                }
                foreach (string str in file2)
                {
                    output[counter - 1] = str;
                    counter += 1;
                }

                if (pathToOutput == null)
                {
                    Console.WriteLine(string.Join("\n", output));
                }
                else
                {
                    File.WriteAllLines(pathToOutput, output);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        
        //-b
        public static bool NumberNonblank(string pathToFile1, string pathToFile2, string pathToOutput = null)
        {
            try
            {
                string[] file1 = File.ReadAllLines(pathToFile1);
                string[] file2 = File.ReadAllLines(pathToFile2);
                string[] output = new string[file1.Length + file2.Length];
                int counter = 1;
                int empty = 0;

                foreach (string str in file1)
                {
                    if (str == "")
                    {
                        empty += 1;
                    }
                    else
                    {
                        output[counter - 1] = counter.ToString() + " " + str;
                    }
                    counter += 1;
                }
                foreach (string str in file2)
                {
                    if (str == "")
                    {
                        empty += 1;
                    }
                    else
                    {
                        output[counter - 1] = counter.ToString() + " " + str;
                    }
                    counter += 1;
                }

                if (pathToOutput == null)
                {
                    Console.WriteLine(string.Join("\n", output));
                }
                else
                {
                    File.WriteAllLines(pathToOutput, output);
                }

                Console.WriteLine("Number of nonblank lines: " + (counter - empty).ToString());

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //-E
        public static bool ShowEnds(string pathToFile1, string pathToFile2, string pathToOutput = null)
        {
            try
            {
                string[] file1 = File.ReadAllLines(pathToFile1);
                string[] file2 = File.ReadAllLines(pathToFile2);
                string[] output = new string[file1.Length + file2.Length];
                int counter = 1;

                foreach (string str in file1)
                {
                    output[counter - 1] = str + "$";
                    counter += 1;
                }

                foreach (string str in file2)
                {
                    output[counter - 1] = str + "$";
                    counter += 1;
                }

                if (pathToOutput == null)
                {
                    Console.WriteLine(string.Join("\n", output));
                }

                else
                {
                    File.WriteAllLines(pathToOutput, output);
                }

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e.ToString());
                return false;
            }
        }

        //-n
        public static bool Number(string pathToFile1, string pathToFile2, string pathToOutput = null)
        {
            try
            {
                string[] file1 = File.ReadAllLines(pathToFile1);
                string[] file2 = File.ReadAllLines(pathToFile2);
                string[] output = new string[file1.Length + file2.Length];
                int counter = 1;
                
                foreach (string str in file1)
                {
                    output[counter - 1] = counter.ToString() + " " + str;
                    counter += 1;
                }
                foreach (string str in file2)
                {
                    output[counter - 1] = counter.ToString() + " " + str;
                    counter += 1;
                }

                if (pathToOutput == null)
                {
                    Console.WriteLine(string.Join("\n", output));
                }
                else
                {
                    File.WriteAllLines(pathToOutput, output);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //-s
        public static bool SqueezeBlank(string pathToFile1, string pathToFile2, string pathToOutput = null) //???
        {
            try
            {
                string[] file1 = File.ReadAllLines(pathToFile1);
                string[] file2 = File.ReadAllLines(pathToFile2);
                string[] output = new string[file1.Length + file2.Length];
                int counter = 1;

                foreach (string str in file1)
                {
                    output[counter - 1] = counter.ToString() + str;
                    counter += 1;
                }
                foreach (string str in file2)
                {
                    output[counter - 1] = counter.ToString() + str;
                    counter += 1;
                }

                if (pathToOutput == null)
                {
                    Console.WriteLine(string.Join("\n", output));
                }
                else
                {
                    File.WriteAllLines(pathToOutput, output);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //-T
        public static bool ShowTabs(string pathToFile1, string pathToFile2, string pathToOutput = null)
        {
            try
            {
                string[] file1 = File.ReadAllLines(pathToFile1);
                string[] file2 = File.ReadAllLines(pathToFile2);
                string[] output = new string[file1.Length + file2.Length];
                int counter = 1;

                foreach (string str in file1)
                {
                    output[counter - 1] = str.Replace(" ", "^I");
                    counter += 1;
                }
                foreach (string str in file2)
                {
                    output[counter - 1] = str.Replace(" ", "^I");
                    counter += 1;
                }

                if (pathToOutput == null)
                {
                    Console.WriteLine(string.Join("\n", output));
                }
                else
                {
                    File.WriteAllLines(pathToOutput, output);
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        //--version, --version output version information and exit
        public static bool Version()
        {
            Console.WriteLine(version);
            return true;
        }

        //--help display help and exit
        public static bool Help()
        {
            Console.Write(File.ReadAllText(@"..\..\Helper.txt"));
            return true;
        }
    }
}
