using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TernaryCalc
{
    class Ternary
    {
        
        /// <summary>
        /// Simple function to convert a base 3 to base 10 
        /// </summary>
        /// <param name="original_line">Base 3 line to be converted</param>
        /// <returns>Converted Base 10 number</returns>
        public static string ConvertToBase10( string base3_number)
        {
            Int32 base10_number = 0;

            // convert the string to a char line
            char[] base3_number_chars = base3_number.ToCharArray();

            for (int i = 0; i < base3_number_chars.Length; i++) 
            {
                // Console.WriteLine("actual char  :" + original_line_char[i]);
                // Console.WriteLine("Actual Power :" +(original_line_char.Length- 1 - i).ToString());
                // Console.WriteLine("Actual base10:" + base10_number);
                base10_number += int.Parse(base3_number_chars[i].ToString()) * Convert.ToInt32(Math.Pow(3, base3_number_chars.Length - 1 -i));
                // Console.WriteLine("New base10:" + base10_number);
            }

            return base10_number.ToString();
        }

        /// <summary>
        /// Convert a base 10 number to a base 3
        /// </summary>
        /// <param name="base10_number">Original base 10 number</param>
        /// <returns>Converted base 3 number</returns>
        public static string ConvertFromBase10(string base10_number)
        {
            string base3_number = "";
            int q = Convert.ToInt32(base10_number);
            int r = 0;

            while (q >= 3) {
                r = q % 3;
                q = q / 3;

                base3_number = r.ToString() + base3_number;
            }
            
            // with the last character
            base3_number = q.ToString() + base3_number;

            return base3_number;
        }

        /// <summary>
        /// Convert a calc line in base 3 to a calc line ine base 10
        /// </summary>
        /// <param name="calc_line_base_3">the string in base 3 to convert</param>
        /// <returns>A string line in base 10 number with all operations</returns>
        public static string ConvertCalcLineFromBase10(string base3_calc_line)
        {
            string base10_calc_line = "";
            string accumulator_number = "";
            string tempory_string = "";

            // purpose: made a for to convert all numbers to decimal number and keep all operations
            for (int i = 0; i < base3_calc_line.Length; i++)
            {
                // Debug
                // Console.WriteLine(calc_line_base_3.Substring(i, 1));
                tempory_string = base3_calc_line.Substring(i, 1);
                switch (tempory_string)
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
                            base10_calc_line += Ternary.ConvertToBase10(accumulator_number).ToString();
                            // reset the accumulator
                            accumulator_number = "";
                        }

                        // add the current character
                        base10_calc_line += tempory_string;
                        break;

                    // if the next char is a ternary number
                    case "0":
                    case "1":
                    case "2":
                        // we add the number to the accumulator
                        accumulator_number += tempory_string;
                        break;

                    // if unknow, throw an error
                    default:
                        Console.WriteLine("You used a bad character in your calc : " + tempory_string);
                        throw new BadImageFormatException();
                }
            }

            // at the end we have to verify that the accumulator is ok
            if (accumulator_number != "")
            {
                base10_calc_line += Ternary.ConvertToBase10(accumulator_number).ToString();
            }

            return base10_calc_line;
        }
    }
}
