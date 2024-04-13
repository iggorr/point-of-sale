using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace cw2_40125689
{
    /* Order.cs
    * This is the parent class for SitInOrder and DeliveryOrder. 
    * Stores the server that added the order. 
    * Stores dishes that are part of the order.
    * 
    *
    * Written by Igors Ahmetovs 19/11/15
    * Relation added 19/11/15
    * Added OrderNumber property 8/12/15
    * Added Items property with exception 8/12/15
    * Added CalculateTotal() method 8/12/15
    */
    public class Order
    {
        private Server takenBy; // stores the server that added the order

        private List<Dish> items = new List<Dish>(); // stores menu items that are part of the order

        // private property
        private int orderNumber;
        private string amountPaid; 

        public int OrderNumber // property for manipulating order number
        {
            get { return orderNumber; }
            set { orderNumber = value; }
        }
        public string AmountPaid // property for displaying amount paid
        {
            get { return amountPaid; }
            set { amountPaid = value; }
        }

        public Server TakenBy // public property for manipulating the server that has taken the order
        {
            get { return takenBy; }
            set { takenBy = value; }
        }

        [XmlIgnore]
        public List<Dish> Items // public property for manipulating the dishes list of the order. Validating that the list passed is not empty
        {
            get { return items; }
            set
            {
                if (value.Count == 0)
                {
                    throw new ArgumentException("Order must have at least one dish ordered!");
                }
                items = value;
            }
        }

        public virtual string CalculateTotal() // method for calculating the total of the order
        {
            int total = 0; // setting the total to 0
            foreach (Dish d in Items) // adding the price of each item of the order to the total
            {
                total += d.Price;
            }
            AmountPaid = String.Format("£{0:#0}.{1:00}", total / 100, total % 100); // converting the total to a string in an appropriate format
            return AmountPaid; // returning the result
         }
        
    }
}
