using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wallet
{
    class MoneyPrinterFile
    {

        public string fileName = "log.txt";

        public void Print(String operation, String currency, int amount)
        {
            var resultString = operation + " " + currency + " " + amount;

            using (var sw = File.AppendText(fileName))
            {
                sw.WriteLine(resultString);
            }
        }
    }
}
