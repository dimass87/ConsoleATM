using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using ATMConcole;

namespace ATMConcole
{
    class Program
    {
        static void Main(string[] args)
        {
            Util.CreateFileIfNotExist(Constants.cardFileName, Constants.cardFileData);
            Util.CreateFileIfNotExist(Constants.atmFileName, Constants.atmFileData);
            ATM atm = new ATM();
            atm.Run();
        }
    }
}



