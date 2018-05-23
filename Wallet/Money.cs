using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet
{
    public class Money
    {
        
        private Dictionary<string, int> _account = new Dictionary<string, int>();
        private Bank _bank;
        private MoneyPrinterConsole _moneyPrinter;
        
        public Money() { }

        public Money(Bank bank, MoneyPrinterConsole moneyPrinter)
        {
            _moneyPrinter = moneyPrinter;
            _bank = bank;
        }

        public int GetKeys()
        {
            return _account.Keys.Count;
        }

        public int GetMoney(string currency)
        {
            if (_account.Keys.Contains(currency))
                return _account[currency];
            else return 0;

        }

        public void Add(string currency, int money)
        {
            _moneyPrinter.Print("inserting", currency, money);
            if (_account.Keys.Contains(currency))
            {
                _account[currency] += money;
            }
            else
            {
                _account.Add(currency, money);
            }
        }

        public void Remove(string currency, int money)
        {
            _moneyPrinter.Print("removing", currency, money);
            if (_account.Keys.Contains(currency))
            {
                int m = _account[currency];
                if (money > m)
                {
                    throw new ArgumentException();
                }
                else if (money == m)
                {
                    _account.Remove(currency);
                }
                else
                {
                    _account[currency] -= money;
                }
                
            }
            else throw new ArgumentException();            
        }

        public override string ToString()
        {
            return "{ "+String.Join(", ", _account.Select(x => x.Value + " " + x.Key)) + " }";   
        }

        public int GetTotalMoney(string currency)
        {
            return _account.Sum(x => _bank.Convert(x.Key, currency, x.Value));
        }
    }
}
