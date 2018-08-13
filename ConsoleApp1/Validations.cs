using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ATMConcole
{
    class Validations
    {


        public static bool WithdrawalValidations(long atmBalance, long cardBalance, long sum)
        {
            if (atmBalance == 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, but ATM is Empty!\r\n");
                Console.ResetColor();
                return false;
            }
            else if (cardBalance < sum)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, but you don`t have enough money!\r\n");
                Console.ResetColor();
                return false;
            }
            else if (atmBalance < sum)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, but not enough money in ATM\r\n");
                Console.ResetColor();
                return false;
            }
            else if (sum % 5 != 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, required amount is not correct. Ti should be 50, 150, 350, 1000, etc.\r\n");
                Console.ResetColor();
                return false;
            }
            else if (cardBalance == 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry, but your balance is 0!\r\n");
                Console.ResetColor();
                return false;
            }
            else if (sum <= 0)
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Please, type correct amaunt!\r\n");
                Console.ResetColor();
                return false;
            }
            return true;
        }

    }
}
