




using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Reflection.Emit;

namespace OOPisik
{
    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.WriteLine("Sisesta isikukood: ");
                string id = Console.ReadLine();
                IdCode idcode = new IdCode(id);
                Console.WriteLine(id);
                //Console.Clear();
                //IdCode.Menu();
                //if (idcode.IsValid())
                //{
                //    Menu();

                //}
                //else
                //{
                //    Console.WriteLine("Smth wrong");
                //}

            }
        }
    }
}
