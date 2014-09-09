using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NCalc;

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
                string base10_line = ConvertCalcLineFromBase3To10(original_line);
                // Step 3 : Parse and execute the string
            }
            catch (Exception)
            {
                Console.WriteLine("Press any key to retry..");
                Console.ReadKey();
                /// TODO Return to state 0
            }



            // Step 4 : Convert back in base 3
            // Step 5 : show result


            Console.WriteLine("Press any key to quit the Ternary Calc");
            Console.ReadKey();
        }

        /// <summary>
        /// Convert a calc line in base 3 to a calc line ine base 10
        /// </summary>
        /// <param name="calc_line_base_3">the string in base 3 to convert</param>
        /// <returns></returns>
        public static string ConvertCalcLineFromBase3To10(string calc_line_base_3)
        {
            string calc_line_base_10 = "";
            string accumulator_number = "";
            string tempory_char = "";

            // purpose: made a for to convert all numbers to decimal number and keep all operations
            for (int i = 0; i < calc_line_base_3.Length; i++)
            {
                // Debug
                // Console.WriteLine(calc_line_base_3.Substring(i, 1));
                tempory_char = calc_line_base_3.Substring(i, 1);
                switch (tempory_char)
                {
                    // if the next char is an operator
                    case "+":
                    case "-":
                    case "/":
                    case "*":
                    case "(":
                    case ")":
                    case " ":
                        // first we verify if ther is a number in the accumulator, if there is, we have to convert the number
                        if (accumulator_number != "")
                        {
                            calc_line_base_10 += ConvertToBase10(accumulator_number).ToString();
                            // reset the accumulator
                            accumulator_number = "";
                        }

                        // add the current character
                        calc_line_base_10 += tempory_char;
                        break;

                    // if the next char is a ternary number
                    case "0":
                    case "1":
                    case "2":
                        // we add the number to the accumulator
                        accumulator_number += tempory_char;
                        break;

                    // if unknow, throw an error
                    default:
                        Console.WriteLine("You used a bad character in your calc. This character will be ignored : " + tempory_char);
                        throw new BadImageFormatException();
                }
            }

            // at the end we have to verify that the accumulator is ok
            if (accumulator_number != "")
            {
                calc_line_base_10 += ConvertToBase10(accumulator_number).ToString();
            }

            return calc_line_base_10;
        }

        /// <summary>
        /// Simple function to convert a base 3 to base 10 
        /// </summary>
        /// <param name="original_line">Base 3 line to be converted</param>
        /// <returns></returns>
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
