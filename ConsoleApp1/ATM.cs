using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ATMConcole
{


    class ATM
    {
        CreditCard card;
        long balance;
        public int[] banknote = new int[] { 10, 20, 50, 100, 200, 500 };
        public string fileName = "ATM.txt";
        long sum;
        public ATM()
        {
            card = new CreditCard();
        }

        public void Operations()
        {
            switch (Console.ReadLine())
            {
                case "0":
                    Commands.Exit();
                    break;

                case "1":
                    Commands.Withdrawal(card);
                    break;

                case "2":
                    Commands.ReplenishOwnCard(card);
                    break;

                case "3":
                    Commands.ReplenishOtherCard();
                    break;

                case "4":
                    Commands.Logout(card);
                    break;

                default:
                    Console.WriteLine("Please, type existing operations");
                    break;
            }
        }

        public long GetBalance()
        {
            long atmBalance = 0;
            foreach (var item in GetBanknotes())
            {
                atmBalance = atmBalance + (item.Key * item.Value);
            }
            return atmBalance;
        }

        public void UpdateBalance(Dictionary<int, long> atmCash)
        {
            string data = "";
            foreach (var item in atmCash)
            {
                data += item.Key + ":" + item.Value + "\r\n";
            }
            Util.WriteToFile("ATM.txt", data);
        }

        public Dictionary<int, long> GetBanknotes()
        {
            Dictionary<int, long> cash = new Dictionary<int, long>();
            StreamReader sr = new StreamReader(fileName, Encoding.Default);
            while (!sr.EndOfStream)
            {
                string[] line = sr.ReadLine().Split(':');
                cash.Add(Int32.Parse(line[0]), Int64.Parse(line[1]));
            }
            sr.Close();
            return cash;
        }

        public void PutBanknote(long sum)
        {
            string data = "";
            Dictionary<int, long> cash = GetBanknotes();





            for (int i = banknote.Length - 1; i >= 0; i--)
            {

                long res = sum % banknote[i];
                long count = (sum - res) / banknote[i];
                if (!cash.ContainsKey(banknote[i]))
                {
                    cash.Add(banknote[i], count);
                }
                data += banknote[i] + ":" + (cash[banknote[i]]) + "\r\n";
                sum = res;


            }
            Util.WriteToFile("ATM.txt", data);
        }

        public void Run()
        {
            while (true)
            {
                if (!card.AuthStatus)
                {
                    Commands.Login(card);
                }
                Operations();

            }
        }

    }

}
