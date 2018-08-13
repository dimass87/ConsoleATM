using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ATMConcole
{
    class Util
    {
        public static void CreateFileIfNotExist(String name, string data)
        {

            if (!File.Exists(name))
            {
                try {
                    using (TextWriter tw = new StreamWriter(File.Create(name)))
                    {
                        tw.WriteLine(data);
                        tw.Close();
                    }
                } catch
                {
                    Console.WriteLine("System data storage error");
                }
               
            }
        }

        public static string SearchInFile(string name, string s)
        {
            StreamReader sr = null;
            try
            {
                sr = new StreamReader(name, Encoding.Default);
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    if (line.Split(':')[0] == (s))
                    {
                        return line;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(Constants.errorFileConnection);
            }
            finally
            {
                sr.Close();
            }
            return null;
        }



        public static void WriteToFile(String fileName, String data)
        {
            StreamWriter writer = null;
            try
            {
                using (writer = new StreamWriter(fileName, false))
                {
                    writer.Write(data);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(Constants.errorFileConnection);
            }
            finally
            {
                writer.Close();
            }
            
        }
    }

}
