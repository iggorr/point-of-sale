using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cw2_40125689
{
    /* Dish.cs
    * This class is used to store the data of menu items. 
    * Stores orders where the dish was used in.
    * 
    *
    * Written by Igors Ahmetovs 19/11/15
    * Relation added 19/11/15
    * Added exceptions 27/11/15
    * ToString() method overriden 8/12/15
    * Removed usedIn List and added Quantity property instead 8/12/15
    */
    public class Dish
    {
        // private properties
        private string description;
        private int price;
        private bool vegetarian;
        private int quantity = 0;


        public string Description // property for manipulating the description of the dish. Validating that the string passed is not empty
        {
            get { return description; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Description field is empty!");
                }
                description = value;
            }
        }

        public int Price // property for manipulating the price of the dish. Validating that the Price is within the range
        {
            get { return price; }
            set
            {
                if (value <= 0 || value >= 100000)
                {
                    throw new ArgumentException("Price should be in range of 0 to 100000 pence!");
                }
                price = value;
            }
        }

        public bool Vegetarian // property for manipulating whether the dish is vegeterian or not
        {
            get { return vegetarian; }
            set { vegetarian = value; }
        }

        public int Quantity // property for manipulating the quantity of the item sold
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public void AddQuantity() // method for increasing the quantity of the dish ordered by 1
        {
            Quantity += 1;
        }
        public override string ToString() // overriden ToString() method returning the Description of the dish
        {
            return Description;
        }
    }
}
