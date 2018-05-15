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
        private Bank _bank;
        int currentMoneySumm = 0;   
        

        public Money(Bank bank)
        {
            _bank = bank;
        }

        public int GetKeys()
        {
            return account.Keys.Count;
        }

        public int GetMoney(string currency)
        {
            if (account.Keys.Contains(currency))
                return account[currency];
            else return 0;

        }

        public void Add(string currency, int money)
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

        public void Remove(string currency, int money)
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

        public override string ToString()
        {
            return "{ "+String.Join(", ", account.Select(x => x.Value + " " + x.Key)) + " }";   
        }
    }
}
