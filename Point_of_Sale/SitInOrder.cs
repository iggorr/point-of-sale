using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2_40125689
{
    /* SitInOrder.cs
    * This class is used to store and manipulate additional data of sit in orders. It inherits from the Order class.
    *
    * 
    * Written by Igors Ahmetovs 19/11/15
    * Added exceptions 1/12/15
    */
    public class SitInOrder : Order
    {
        // additional private property
        private int table;

        public int Table // property for manipulating table number. Validating that the value is within the range
        {
            get { return table; }
            set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException("Table number should be in range of 1-10!");
                }
                table = value;
            }
        }
    }
}
