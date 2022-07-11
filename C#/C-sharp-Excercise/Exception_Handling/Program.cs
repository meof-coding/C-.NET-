using System;
using System.Collections;

namespace Exception_Handling
{
    class Program
    {
        static void Main(string[] args)
        {
            // Question 1: This program is throwing exception IndexOutOfRangeException.
            //Using your skills fix this problem using try catch block.
            string[] list = new string[5];
            list[0] = "Sunday";
            list[1] = "Monday";
            list[2] = "Tuesday";
            list[3] = "Wednesday";
            list[4] = "Thursday";
            try
            {
<<<<<<< HEAD
                for (int i = 0; i <= 5; i++)
                {
                    Console.WriteLine(list[i].ToString());
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Null_Reference_Exception!", Console.ForegroundColor);
=======
               for (int i = 0; i <= 5; i++)
               {
                   Console.WriteLine(list[i].ToString());
               }
               Console.ReadLine();
            }
            catch (Exception ex)
            {
               Console.ForegroundColor = ConsoleColor.DarkBlue;
               Console.WriteLine("Null_Reference_Exception!",Console.ForegroundColor);
>>>>>>> 5895f65c0ce34b0ecc14f80be81d30dddf427c6c
            }

            //Quesstion 2: The given program is throwing OverflowException. Fix it.
            int num1, num2;
            byte result;
            num1 = 30;
            num2 = 60;
            try
            {
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine("{0} x {1} = {2}", num1, num2, result);
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("Overflow_Exception is caught!!",Console.ForegroundColor);
            }
            
            Console.ReadLine();

        }
    }
}
