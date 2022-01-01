using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L38TRN_HFT_2021221.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.Sleep(8000);
            Console.WriteLine("hello");
            RestService restService = new RestService();
            MakeConnection(ref restService);
        }

        static void MakeConnection(ref RestService rest)
        {
            try
            {
                rest = new RestService("http://localhost:3445");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
