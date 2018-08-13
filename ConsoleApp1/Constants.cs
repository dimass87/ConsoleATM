using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using ATMConcole;

namespace ATMConcole
{
    class Constants
    {
        public const string atmFileData = "500:10\r\n200:10\r\n100:10\r\n50:10\r\n20:10\r\n10:10";
        public const string cardFileData = "1111111111111111:1111:0\r\n2222222222222222:2222:0\r\n3333333333333333:3333:0\r\n4444444444444444:4444:0\r\n5555555555555555:5555:0";
        public const string atmFileName = "ATM.txt";
        public const string cardFileName = "Cards.txt";
        public const string operations = "\r\nAvailable operations:\r\nType 0 to close terminal\r\nType 1 to withdrawal;\r\nType 2 to replenish Own card;\r\nType 3 to transfer to Other Card;\r\nType 4 to logout;\r\n";
        public const string errorFileConnection = "Data storage error connection";
    }
}



