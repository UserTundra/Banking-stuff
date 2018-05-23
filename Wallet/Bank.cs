using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet
{
    public class Bank
    {
        private const int RANDOMED = 9;
        private Dictionary<string, double> _course;
        public IEnumerable<string> AvalibleCurrencies
        {
            get { return _course.Keys; }
        }

        public Bank()
        {
            _course = new Dictionary<string, double>();
            Init();
        }


        private void Init()
        {
            _course.Add("USD", 1);
            _course.Add("RUB", 1/62.0);
            _course.Add("EUR", 1.18);
            _course.Add("TENGE", 0.003);
        }

        public virtual int Convert(string from, string to, int value)
        {
            from = from.ToUpper();
            to = to.ToUpper();

            if (value <= 0)
                throw new ArgumentException();

            if (!AvalibleCurrencies.Contains(from) || !AvalibleCurrencies.Contains(to))
                throw new NotImplementedException();

            var dollarValue = _course[from] * value;
            var RandomFluctuations = (int)(dollarValue * 0.2);
            var randomBetween = new Random(RANDOMED).Next(-RandomFluctuations, RandomFluctuations);
            dollarValue += randomBetween;

            return (int) Math.Abs(dollarValue / _course[to]) ;

        }

    }
}
