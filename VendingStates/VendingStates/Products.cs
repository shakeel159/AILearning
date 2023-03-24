using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingStates
{
    //Singleton Class
    public class Products
    {
        public string name;
        public static Products instance = new Products();
        public Products() { }

        public static Products GetInstance
        {
            get { return instance; }
        }
    }
}
