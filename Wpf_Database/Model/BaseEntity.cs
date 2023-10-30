using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_Database
{
    public class BaseEntity
    {
        protected int Id;
        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }
    }
}
