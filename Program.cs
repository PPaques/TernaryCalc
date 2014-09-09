using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TernaryCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 0 : (UI) Print welcome message
            Console.WriteLine("Welcome to Ternary Calc Software");
            Console.WriteLine("Please enter your ternary operations then press enter:");

            // Step 1 : get the string to compute
            string original_line = Console.ReadLine();

            // Step 2 : Convert all numbers to decimal
            string base10_line = ConvertToBase10(original_line);
            Console.WriteLine(base10_line);

            // Step 3 : Parse and execute the string
            // Step 4 : Convert back in base 3
            // Step 5 : show result


            Console.WriteLine("Press any key to quit the Ternary Calc");
            Console.ReadKey();
        }

        public static string ConvertToBase10( string original_line)
        {
            Int32 base10_number = 0;

            // convert the string to a char line
            char[] original_line_char = original_line.ToCharArray();

            for (int i = 0; i < original_line_char.Length; i++) 
            {
                // Console.WriteLine("actual char  :" + original_line_char[i]);
                // Console.WriteLine("Actual Power :" +(original_line_char.Length- 1 - i).ToString());
                // Console.WriteLine("Actual base10:" + base10_number);
                base10_number += int.Parse(original_line_char[i].ToString()) * Convert.ToInt32(Math.Pow(3, original_line_char.Length - 1 -i));
                // Console.WriteLine("New base10:" + base10_number);
            }

            return base10_number.ToString();
        }
    }
}
