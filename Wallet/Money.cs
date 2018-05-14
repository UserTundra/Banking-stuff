using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet
{
    public class Money
    {
        
        private Dictionary<string, int> account = new Dictionary<string, int>();
        int currentMoney;   
        

        public Money()
        {
            
        }

        public int getKeys()
        {
            return account.Keys.Count;
        }

        public int getValues(string key)
        {
            return account[key];
        }

        public void add(string currency, int money)
        {
            if (account.Keys.Contains(currency))
            {
                account[currency] += money;
            }
            else
            {
                account.Add(currency, money);
            }
        }

        public void remove(string currency, int money)
        {
            
        }
    }
}
