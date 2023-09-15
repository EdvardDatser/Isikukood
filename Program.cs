
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
                isiku ida = new isiku(id); 
                int l = 0;
                while (l != 1)
                {
                    if (ida.IsValid())
                    {
                        Console.WriteLine("                          Menu:\n");
                        Console.WriteLine("[0] - Exit ");
                        Console.WriteLine("[1] - Vaata missugune haigla ");
                        Console.WriteLine("[2] - Vaata kõik info isikukoodust ");
                        Console.WriteLine("[3] - Uus isikukood ");
                        int ans = Convert.ToInt32(Console.ReadLine());

                        if (ans == 0)
                        {
                            Environment.Exit(0);
                        }
                        else if (ans == 1 && ida.IsValid())
                        {
                            isiku.haigla(id);
                        }
                        if (ans == 2 && ida.IsValid())
                        {
                            Console.WriteLine("Sugu: " + ida.GetGender());
                            Console.WriteLine("Sunnipaev: " + ida.GetBirthDate() + " ,Vana: " + ida.age());
                            isiku.haigla(id);
                        }
                        else if (ans == 3)
                        {
                            l++;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Midagi läks valesti!");
                        l++;
                    }
                   
                }    

            }
        }
    }
}
