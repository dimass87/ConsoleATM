using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace ATMConcole
{
    class CreditCard
    {
        private long cardNumber;
        private readonly int cardPin;
        private long balance;
        private Boolean isAuth = false;

        public long CardNumber => cardNumber;

        public int CardPin => cardPin;

        public long Balance => balance;

        public void SetBalance(long balance)
        {
            this.balance = balance;
        }

        public void Withdraw(int sum)
        {
            balance -= sum;
        }

        public long Replenish(int sum)
        {
            balance += sum;
            return balance;
        }

        public Boolean AuthStatus => isAuth;

        public void SetAuthStatus(Boolean status)
        {
            isAuth = status;
        }

        public void SetCardNumber(long cardNumber)
        {
            this.cardNumber = cardNumber;
        }

        public void UpdateBalance(long balance)
        {
            SetBalance(balance);
            string line = "";
            StreamReader sr = null;
            try
            {
                using (sr = new StreamReader(Constants.cardFileName, Encoding.Default))
                {
                    while (!sr.EndOfStream)
                    {
                        string temp = sr.ReadLine();
                        if (temp.Split(':')[0] == (this.CardNumber.ToString()))
                        {
                            temp = temp.Split(':')[0] + ":" + temp.Split(':')[1] + ":" + balance.ToString();
                        }
                        line += temp + "\r\n";
                    }
                    
                }
                Util.WriteToFile(Constants.cardFileName, line);
            } catch (Exception e)
            {
                Console.WriteLine(Constants.errorFileConnection);
            }
            finally
            {
                sr.Close();
            }
            
        }
    }

}
