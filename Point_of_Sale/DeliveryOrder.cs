using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2_40125689
{
    /* DeliveryOrder.cs
    * This class is used to store and manipulate additional data of sit in orders. It inherits from the Order class.
    * Stores the driver that has delivered the order.
    * 
    *
    * Written by Igors Ahmetovs 19/11/15
    * Relation added 19/11/15
    * Added exceptions 1/12/15
    * Added DeliveredBy property 8/12/15
    * Added overriden CalculateTotal() method 8/12/15
    */
    public class DeliveryOrder : Order
    {
        // additional private properties
        private string customerName;
        private string deliveryAddress;

        private Driver deliveredBy; // stores the driver that has delivered the order

        public string CustomerName // property for manipulating customer name. Validating that the string passed is not empty
        {
            get { return customerName; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Customer Name field is empty!");
                }
                customerName = value;
            }
        }

        public string DeliveryAddress // property for manipulating customer's address. Validating that the string passed is not empty
        {
            get { return deliveryAddress; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Delivery Address field is empty!");
                }
                deliveryAddress = value;
            }
        }

        public Driver DeliveredBy // public property for manipulating the driver that has delivered the order
        {
            get { return deliveredBy; }
            set { deliveredBy = value; }
        }

        public override string CalculateTotal() // overriden method for calculating the total of the delivery order with the delivery charge
        {
            int total = 0; // setting the total to 0
            foreach (Dish d in Items) // adding the price of each item of the order to the total
            {
                total += d.Price;
            }
            string result = String.Format("£{0:#0}.{1:00}", total / 100, total % 100); // converting the total to a string in appropriate format
            double deliveryCharge = total * 0.15; // calculating the delivery charge
            string delivery = String.Format("£{0:#0}.{1:00}", (int)deliveryCharge / 100, (int)deliveryCharge % 100); // formatting the delivery charge to a string in format
            int totalWithDelivery = total + (int)deliveryCharge; // calculating total with delivery
            AmountPaid = String.Format("£{0:#0}.{1:00}", totalWithDelivery / 100, totalWithDelivery % 100); // converting the new total to a string in format
            return result + "\nDelivery charge: " + delivery + "\nTotal with delivery: " + AmountPaid; // returning the overriden result
        }
    }
}
