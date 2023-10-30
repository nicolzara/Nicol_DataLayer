using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Database
{
    public class Dish : BaseEntity
    {
        protected string DishName;
        public string DISH_NAME
        {
            get { return DishName; }
            set { DishName = value; }
        }
    }

    public class DishList : List<Dish>
    {
        public DishList() { } // default c'tor with empty list

        public DishList(IEnumerable<Dish> list) : base(list) { } // parse generic list to dish list

        public DishList(IEnumerable<BaseEntity> list) : base(list.Cast<Dish>().ToList()) { } // from base class to dish list
    }
}
