using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet
{
    public class Bank
    {

        private Dictionary<string, double> _course;
        public IEnumerable<string> AvalibleCurrencies
        {
            get { return _course.Keys; }
        }

        public Bank()
        {
            _course = new Dictionary<string, double>();
        }


        private void Init()
        {
            _course.Add("USD", 1);
            _course.Add("RUB", 1/62);
            _course.Add("EUR", 1.18);
            _course.Add("TENGE", 0.003);
        }

        public int Convert(string from, string to, int value)
        {
            

            from = from.ToUpper();
            to = to.ToUpper();

            if (!AvalibleCurrencies.Contains(from) || !AvalibleCurrencies.Contains(to))
                throw new NotImplementedException();

            var dollarValue = _course[from] * value;
            var RandomFluctuations = (int)(dollarValue * 0.2);
            dollarValue += new Random().Next(-RandomFluctuations, RandomFluctuations);

            return (int) (dollarValue / _course[to]) ;

        }

    }
}
