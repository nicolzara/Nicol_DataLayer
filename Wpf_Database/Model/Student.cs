using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Database
{
    public class Student : BaseEntity
    {
        protected string FirstName;
        public string FIRST_NAME
        {
            get { return FirstName; }
            set { FirstName = value; }
        }

        protected string LastName;
        public string LAST_NAME
        {
            get { return LastName; }
            set { LastName = value; }
        }

        protected DateTime Birthdate;
        public DateTime BIRTHDATE
        {
            get { return Birthdate; }
            set { Birthdate = value; }
        }

        protected bool Gender;
        public bool GENDER
        {
            get { return Gender; }
            set { Gender = value;}
        }

        protected string PhoneNumber;
        public string PHONE_NUMBER
        {
            get { return PhoneNumber; }
            set { PhoneNumber = value; }
        }

        protected City City;
        public City CITY
        {
            get { return City; }
            set { City = value; }
        }

        public DishList FavoriteDishes;
    }

    public class StudentList : List<Student>
    {
        public StudentList() { } // default c'tor with empty list

        public StudentList(IEnumerable<Student> list) : base(list) { } // parse generic list to student list

        public StudentList(IEnumerable<BaseEntity> list) : base(list.Cast<Student>().ToList()) { } // from base class to student list
    }
}
