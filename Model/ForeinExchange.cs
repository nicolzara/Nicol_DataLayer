using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ForeinExchange
    {
        protected string currencyName;
        public string CurrencyName
        {
            get { return CurrencyName; }
            set { CurrencyName = value; }
        }

        protected string shortName;
        public string ShortName
        {
            get { return shortName; }
            set { shortName = value; }
        }

        protected double value;
        public double Value
        {
            get { return value; }
            set { this.value = value; }
        }
    }
}
