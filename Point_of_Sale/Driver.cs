using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2_40125689
{
    /* Driver.cs
    * This class is used to store and manipulate additional data of the Driver. It inherits from the Staff class.
    * Stores orders that were delivered by the driver.
    * 
    * 
    * Written by Igors Ahmetovs 15/11/15
    * Relation added 19/11/15
    * Added exceptions 27/11/15
    * Added AddOrder() method 8/12/15
    */
    public class Driver : Staff
    {
        // additional private property
        private string carReg;

        private List<Order> delivers = new List<Order>(); // list containing orders delivered by the driver

        public string CarReg  // property for manipulating registration number of the driver's car. Validating that the string passed is not empty
        {
            get { return carReg; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Car registration field is empty!");
                }
                carReg = value;
            }
        }
        public void AddOrder(Order o) // method for adding a new order to the delivers List
        {
            delivers.Add(o);
        }
    }
}
