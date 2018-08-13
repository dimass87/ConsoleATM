using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ATMConcole
{
    class Commands
    {



        public static void ShowUserInfo(CreditCard card)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("\r\nCard Info:\r\n");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Balance: " + card.Balance);
            Console.ResetColor();
            Console.WriteLine(Constants.operations);


        }

        public static void ReplenishOwnCard(CreditCard card)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("\r\nReplenish Own Card:\r\n");
            Console.ResetColor();
            while (true)
            {
                Console.WriteLine("Please, type an amount:");
                string money = Console.ReadLine();
                if (!money.Equals(null) && money.Length > 0)
                {
                    long balance = card.Balance;
                    try
                    {
                        long sum = Int64.Parse(money);
                        //card.SetBalance(balance + sum);
                        card.UpdateBalance(balance + sum);
                        new ATM().PutBanknote(sum);
                        ShowUserInfo(card);
                        break;
                    }
                    catch (Exception e)
                    {
                        e.ToString();
                        Console.WriteLine("Please, type the correct amount:");
                    }
                }
            }
        }

        public static void ReplenishOtherCard()
        {
            Console.WriteLine("Current operation is not available at this time");
        }

        public static void Withdrawal(CreditCard card)
        {

            ATM atm = new ATM();
            long atmBalance;
            long cardBalance;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("\r\nWithdrawal operation:\r\n");
            Console.ResetColor();

            while (true)
            {
                Console.WriteLine("Please, type amount for withdrawal:");

                atmBalance = atm.GetBalance();
                cardBalance = card.Balance;
                try
                {
                    long sum = Int64.Parse(Console.ReadLine());


                    if (!Validations.WithdrawalValidations(atmBalance, cardBalance, sum))
                    {
                        break;
                    }

                    Dictionary<int, long> transactionCash = atm.GetBanknotes();

                    long remains;
                    long banknotes;
                    foreach (var item in transactionCash)
                    {
                        banknotes = sum / item.Key;
                        if (banknotes > 0)
                        {
                            remains = sum % item.Key; ;
                            long res = item.Value - banknotes;
                            if (res <= 0)
                            {
                                transactionCash.Remove(item.Key);
                            }
                            else
                            {
                                transactionCash[item.Key] = res;
                            }

                            if (remains == 0)
                            {

                                card.UpdateBalance(card.Balance - sum);
                                atm.UpdateBalance(transactionCash);
                                break;
                            }

                            else
                            {
                                sum = remains;
                            }

                        }
                    }

                    break;


                }
                catch (Exception e)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect amount data format.!\r\n");
                    Console.ResetColor();
                }

            }
            Commands.ShowUserInfo(card);
        }



        public static void Exit()
        {
            Environment.Exit(0);
        }

        public static CreditCard Login(CreditCard card)
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.WriteLine("Authorization step\r\n");
            Console.ResetColor();

            while (true)
            {
                Console.WriteLine("Please, type your card number (16 digits):");
                string cardNum = Console.ReadLine();
                if (cardNum.Equals("exit"))
                {
                    Environment.Exit(0);
                }
                else if (!cardNum.Equals(null) && cardNum.Length == 16)
                {
                    string str = Util.SearchInFile("Cards.txt", cardNum);
                    if (str != null)
                    {
                        while (true)
                        {
                            Console.WriteLine("Please, type pin (4 digits):");
                            string s = Console.ReadLine();
                            if (s.Equals("exit"))
                            {
                                Environment.Exit(0);
                            }
                            else if (str.Split(':')[1] == s)
                            {
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("Authorized successfull!");
                                Console.ResetColor();
                                card.SetAuthStatus(true);
                                card.SetCardNumber(Int64.Parse(cardNum));
                                card.SetBalance(Int64.Parse(str.Split(':')[2]));
                                ShowUserInfo(card);
                                return card;
                            }
                            else
                            {
                                Console.BackgroundColor = ConsoleColor.Red;
                                Console.WriteLine("Incorrect pin!");
                                Console.ResetColor();
                            }
                        }
                    }
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrect card!");
                    Console.ResetColor();
                }


            }
        }

        public static void Logout(CreditCard card)
        {
            card.SetAuthStatus(false);
        }

    }
}
