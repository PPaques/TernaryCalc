using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc; // library that can parse and execute calcs in base 10. Under MIT licence.

namespace TernaryCalc
{
    class Program
    {
        static void Main(string[] args)
        {
            // Step 0 : (UI) Print welcome message
            Console.WriteLine("Welcome to Ternary Calc Software");
            Console.WriteLine("Please enter your ternary operations then press enter:");

            try
            {
                // Step 1 : get the string to compute
                string original_line = Console.ReadLine();
                
                // Step 2 : Convert all numbers to decimal
                string base10_line = Ternary.ConvertCalcLineFromBase10(original_line);
                
                // Step 3 : Parse and execute the string
                string base10_result = new Expression(base10_line).Evaluate().ToString();
                //Console.WriteLine("decimal : " + base10_line + " = " + base10_result);
                
                // Step 4 : Convert back in base 3
                string base3_result = Ternary.ConvertFromBase10(base10_result);

                // Step 5 : show result
                Console.WriteLine("Base 3 : " + original_line + " = " + base3_result);
                
            }
            catch (Exception)
            {
                Console.WriteLine("Press any key to retry..");
                Console.ReadKey();
                /// TODO Return to state 0
            }

            Console.WriteLine("Press any key to quit the Ternary Calc");
            Console.ReadKey();
        }

       

       
    }
}
