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

        public int getMoney(string currency)
        {
            if (account.Keys.Contains(currency))
                return account[currency];
            else return 0;

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
            if (account.Keys.Contains(currency))
            {
                int m = account[currency];
                if (money > m)
                {
                    throw new ArgumentException();
                }
                else if (money == m)
                {
                    account.Remove(currency);
                }
                else
                {
                    account[currency] -= money;
                }
                
            }
            else throw new ArgumentException();            
        }

        public void toString()
        {
            foreach (var item in account)
            {
                Console.Write("{ " + item.Value + " " + item.Key + " }");
            }
        }
    }
}
