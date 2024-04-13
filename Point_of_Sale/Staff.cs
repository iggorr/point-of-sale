using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2_40125689
{
    /* Staff.cs
    * This is the parent class for Servers and Drivers. 
    * Used for storing and manipulating data of the member of the staff .
    * The properties of the class are validated through exceptions.
    * 
    *
    * Written by Igors Ahmetovs 15/11/15
    * Added exceptions 23/11/15
    */
    public class Staff
    {
        // private properties
        private string name;
        private int staffId;

        public string Name   // property for manipulating name of the member of the staff. Validating that the string passed is not empty
        {
            get { return name; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name field is empty!");
                }
                name = value;
            }
        }

        public int StaffId  // property for manipulating staff ID. Validating that the Staff ID is a positive number
        {
            get { return staffId; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Staff ID should be a positive number!");
                }
                staffId = value;
            }
        }
    }
}
