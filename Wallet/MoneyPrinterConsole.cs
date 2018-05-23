using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet
{
    public class MoneyPrinterConsole
    {
        public void Print(String operation, String currency, int amount)
        {
            Console.Write(operation + " " + currency + " " + amount);
        }
    }
}
