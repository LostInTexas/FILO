using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FILO.Domain;
using Newtonsoft.Json;

namespace FILOApp
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                ISortSingle sortSingle = new Sort();
                ISortMultiple sortMultiple = new Sort();

                string json;
                List<Data> items;

                string[] lines = System.IO.File.ReadAllLines(@"file.txt");

                foreach (string s in lines)
                {
                    Console.WriteLine(string.Concat("Original string: ", s));
                    Console.WriteLine(string.Concat("Method 1: ", sortSingle.SortString(s)));
                    Console.WriteLine(string.Concat("Method 2: ", sortMultiple.SortString(s)));
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured: ");
                Console.WriteLine(e.Message);
            }
            finally
            {
                Console.WriteLine("Press enter");
                Console.ReadLine();
            }




        }
    }
}
