using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Database
{
    public class City : BaseEntity
    {
        protected string CityName;
        public string CITY_NAME
        {
            get { return CityName; }
            set { CityName = value; }
        }
    }

    public class CityList : List<City>
    {
        public CityList() { } // default c'tor with empty list

        public CityList(IEnumerable<City> list) : base(list){ } // parse generic list to city list

        public CityList(IEnumerable<BaseEntity> list) : base(list.Cast<City>().ToList()) { } // from base class to city list
    }
}
