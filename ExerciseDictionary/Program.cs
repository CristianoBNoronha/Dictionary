using System;
using System.Collections.Generic;
using System.IO;

namespace ExerciseDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> votes = new Dictionary<string, int>();
            Console.Write("Enter full path: ");
            string path = Console.ReadLine();
            try
            {
                using (StreamReader sr = File.OpenText(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string[] line = sr.ReadLine().Split(',');
                        string name = line[0];
                        int number = int.Parse(line[1]);
                        if (votes.ContainsKey(name))
                        {
                            int soma = votes[name];
                            votes[name] = soma + number;
                        }
                        else
                        {
                            votes.Add(name, number);
                        }
                    }
                }
                foreach (KeyValuePair<string, int> item in votes)
                {
                    Console.WriteLine(item.Key + " : " + item.Value);
                }

            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
