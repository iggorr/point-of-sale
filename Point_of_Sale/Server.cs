using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;


namespace cw2_40125689
{
    /* Server.cs
    * This class is used to store and manipulate data of orders taken by a Server. It inherits from the Staff class.
    *
    * 
    * Written by Igors Ahmetovs 15/11/15
    * Relation added 19/11/15
    * AddOrder method added 8/12/15
    */
    public class Server : Staff
    {

        private List<Order> takes = new List<Order>(); // list containing orders taken by the server

        [XmlIgnore] // avoiding a loop in serialisation
        public List<Order> Takes // public property for displaying Takes List content
        {
            get { return takes; }
        }


        public void AddOrder(Order o) // method for adding a new order to the Takes List
        {
            takes.Add(o);
        }
        
            
    }
}
