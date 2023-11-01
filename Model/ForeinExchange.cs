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

    public class ForeinExchangeList : List<ForeinExchange>
    {
        public ForeinExchangeList() { } // default c'tor with empty list

        public ForeinExchangeList(IEnumerable<ForeinExchange> list) : base(list) { } // parse generic list to forein exchange list

        public ForeinExchangeList(IEnumerable<BaseEntity> list) : base(list.Cast<ForeinExchange>().ToList()) { } // from base class to forein exchange list
    }
}
