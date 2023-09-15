using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace OOPisik
{
    public class isiku
    {
        private readonly string _idCode;

        public isiku(string idCode)
        {
            _idCode = idCode;
        }

        private bool IsValidLength()
        {
            return _idCode.Length == 11;
        }

        private bool ContainsOnlyNumbers()
        {
            // return _idCode.All(Char.IsDigit);

            for (int i = 0; i < _idCode.Length; i++)
            {
                if (!Char.IsDigit(_idCode[i]))
                {
                    return false;
                }
            }
            return true;
        }

        private int GetGenderNumber()
        {
            return Convert.ToInt32(_idCode.Substring(0, 1));
        }

        private bool IsValidGenderNumber()
        {
            int genderNumber = GetGenderNumber();
            return genderNumber > 0 && genderNumber < 7;
        }

        private int Get2DigitYear()
        {
            return Convert.ToInt32(_idCode.Substring(1, 2));
        }

        public int GetFullYear()
        {
            int genderNumber = GetGenderNumber();
            // 1, 2 => 18xx
            // 3, 4 => 19xx
            // 5, 6 => 20xx
            return 1800 + (genderNumber - 1) / 2 * 100 + Get2DigitYear();
        }

        private int GetMonth()
        {
            return Convert.ToInt32(_idCode.Substring(3, 2));
        }

        private bool IsValidMonth()
        {
            int month = GetMonth();
            return month > 0 && month < 13;
        }

        private static bool IsLeapYear(int year)
        {
            return year % 4 == 0 && year % 100 != 0 || year % 400 == 0;
        }
        private int GetDay()
        {
            return Convert.ToInt32(_idCode.Substring(5, 2));
        }

        private bool IsValidDay()
        {
            int day = GetDay();
            int month = GetMonth();
            int maxDays = 31;
            if (new List<int> { 4, 6, 9, 11 }.Contains(month))
            {
                maxDays = 30;
            }
            if (month == 2)
            {
                if (IsLeapYear(GetFullYear()))
                {
                    maxDays = 29;
                }
                else
                {
                    maxDays = 28;
                }
            }
            return 0 < day && day <= maxDays;
        }

        private int CalculateControlNumberWithWeights(int[] weights)
        {
            int total = 0;
            for (int i = 0; i < weights.Length; i++)
            {
                total += Convert.ToInt32(_idCode.Substring(i, 1)) * weights[i];
            }
            return total;
        }

        private bool IsValidControlNumber()
        {
            int controlNumber = Convert.ToInt32(_idCode[^1..]);
            int[] weights = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 };
            int total = CalculateControlNumberWithWeights(weights);
            if (total % 11 < 10)
            {
                return total % 11 == controlNumber;
            }
            // second round
            int[] weights2 = { 3, 4, 5, 6, 7, 8, 9, 1, 2, 3 };
            total = CalculateControlNumberWithWeights(weights2);
            if (total % 11 < 10)
            {
                return total % 11 == controlNumber;
            }
            // third round, control number has to be 0
            return controlNumber == 0;
        }

        public bool IsValid()
        {
            return IsValidLength() && ContainsOnlyNumbers()
                && IsValidGenderNumber() && IsValidMonth()
                && IsValidDay()
                && IsValidControlNumber();
        }

        public DateOnly GetBirthDate()
        {
            int day = GetDay();
            int month = GetMonth();
            int year = GetFullYear();
            return new DateOnly(year, month, day);
        }
        //------------------------------------------------------------------------------------------

        public string GetGender()
        {
            string viga = "viga";
            int genderNumber = GetGenderNumber();
            string mees = "Mees";
            string naine = "Naine";
            if (genderNumber == 1 || genderNumber == 3 || genderNumber == 5) { return mees; }
            else if (genderNumber == 2 || genderNumber == 4 || genderNumber == 6) { return naine; }
            else { return viga; }
        }

        public int age()
        {
            int year = GetFullYear();
            int age = DateTime.Now.Year - year;
            return age;
        }

        public static void haigla(string IdCode)
        {
            string isik = IdCode.Substring(7, 3);
            int t = int.Parse(isik);
            string haigla = "";

            if (t >= 1 && t <= 10)
            {
                Console.WriteLine("Kuressaare haigla");
            }
            else if (t >= 11 && t <= 19)
            {
                Console.WriteLine("Tartu Ülikooli Naistekliinik");
            }
            else if (t >= 21 && t <= 150)
            {
                Console.WriteLine("Ida-Tallinna keskhaigla, Pelgulinna sünnitusmaja (Tallinn)");
            }
            else if (t >= 151 && t <= 160)
            {
                Console.WriteLine("Keila haigla");
            }
            else if (t >= 161 && t <= 220)
            {
                Console.WriteLine("Rapla haigla, Loksa haigla, Hiiumaa haigla (Kärdla)");
            }
            else if (t >= 221 && t <= 270)
            {
                Console.WriteLine("Ida-Viru keskhaigla (Kohtla-Järve, endine Jõhvi)");
            }
            else if (t >= 271 && t <= 370)
            {
                Console.WriteLine("Maarjamõisa kliinikum (Tartu), Jõgeva haigla");
            }
            else if (t >= 371 && t <= 420)
            {
                Console.WriteLine("Narva haigla");
            }
            else if (t >= 421 && t <= 470)
            {
                Console.WriteLine("Pärnu haigla");
            }
            else if (t >= 471 && t <= 490)
            {
                Console.WriteLine("Haapsalu haigla");
            }
            else if (t >= 491 && t <= 520)
            {
                Console.WriteLine("Järvamaa haigla (Paide)");
            }
            else if (t >= 521 && t <= 570)
            {
                Console.WriteLine("Rakvere haigla, Tapa haigla");
            }
            else if (t >= 571 && t <= 600)
            {
                Console.WriteLine("Valga haigla");
            }
            else if (t >= 601 && t <= 650)
            {
                Console.WriteLine("Viljandi haigla");
            }
            else if (t >= 651 && t <= 700)
            {
                Console.WriteLine("Lõuna-Eesti haigla (Võru), Põlva haigla");
            }
            else
            {
                Console.WriteLine("Midagi läks valesti!");
            }

        }
    }
}
