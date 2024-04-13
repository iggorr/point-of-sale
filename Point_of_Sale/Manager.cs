using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;



namespace cw2_40125689
{
    /* Manager.cs
    * This is a class that stores collections of all the data about the staff, dishes and orders. 
    * ObservableCollection is chosen instead of List or other Collection because it is used in data binding (WPF controls will automatically update when collection is changed). 
    *
    *
    * Written by Igors Ahmetovs 20/11/15
    * Changed the way to store the data from List<> to ObservableCollection<> 23/11/15
    * Added RemoveServer method 23/11/15
    * Added exceptions 23/11/15
    * Added CheckIfIdUnique method 27/11/15
    * Added AddToDrivers method 27/11/15
    * Added collection for drivers and dishes 27/11/15
    * Added AddToDishes method 27/11/15
    * Added sitIns and deliveries lists with properties 8/12/15
    * AddToSitIns and AddToDeliveries methods created 8/12/15
    */

    public class Manager
    {

        private ObservableCollection<Server> servers = new ObservableCollection<Server>(); // collection containing all the servers
        private ObservableCollection<Driver> drivers = new ObservableCollection<Driver>(); // collection containing all the drivers
        private ObservableCollection<Dish> dishes = new ObservableCollection<Dish>(); // collection containing all the dishes
        private List<SitInOrder> sitIns = new List<SitInOrder>(); // list containing all sit in orders placed
        private List<DeliveryOrder> deliveries = new List<DeliveryOrder>(); // list containing all delivery orders placed

        public ObservableCollection<Server> Servers // public property for displaying servers collection content
        {
            get { return servers; }
        }
        public ObservableCollection<Driver> Drivers // public property for displaying drivers collection content
        {
            get { return drivers; }
        }
        public ObservableCollection<Dish> Dishes // public property for displaying dishes collection content
        {
            get { return dishes; }
        }
        public List<SitInOrder> SitIns // public property for displaying sitIns List content
        {
            get { return sitIns; }
        }
        public List<DeliveryOrder> Deliveries // public property for displaying deliveries List content
        {
            get { return deliveries; }
        }

        public void AddToServers(Server s) // method for adding a new server to the servers collection
        {
            CheckIfIdUnique(s.StaffId);
            servers.Add(s);
        }
        public void AddToDrivers(Driver d) // method for adding a new server to the drivers collection
        {
            CheckIfIdUnique(d.StaffId);
            drivers.Add(d);
        }
        public void AddToDishes(Dish d) // method for adding a new dish to the dishes collection
        {
            dishes.Add(d);
        }
        public void RemoveServer(object n) // method for removing a server from the collection
        {
            if (Servers.Count == 0) // passing an exception if the collection is empty
            {
                throw new ArgumentException("No servers to remove!");
            }
            Server serverToRemove = servers.Single(r => r == n); // setting the serverToRemove to the one received through the method's argument
            servers.Remove(serverToRemove); // removing it from the list
        }
        public void RemoveDriver(object n) // method for removing a driver from the collection
        {
            if (Drivers.Count == 0) // passing an exception if the collection is empty
            {
                throw new ArgumentException("No drivers to remove!");
            }
            Driver driverToRemove = drivers.Single(r => r == n); // setting the driverToRemove to the one received through the method's argument
            drivers.Remove(driverToRemove); // removing it from the list
        }
        public void RemoveDish(object n) // method for removing a dish from the collection
        {
            if (Dishes.Count == 0) // passing an exception if the collection is empty
            {
                throw new ArgumentException("No dishes to remove!");
            }
            Dish dishToRemove = dishes.Single(r => r == n); // setting the dishToRemove to the one received through the method's argument
            dishes.Remove(dishToRemove); // removing it from the list
        }

        public void CheckIfIdUnique(int id) // method for checking whether the staff id has already been taken
        {
            foreach (Server serv in Servers)
            {
                if (id == serv.StaffId)
                {
                    throw new ArgumentException("Staff ID is not unique!");                    
                }
            }

            foreach (Driver driv in Drivers)
            {
                if (id == driv.StaffId)
                {
                    throw new ArgumentException("Staff ID is not unique!");
                }
            }
        }

        public void AddToSitIns(SitInOrder s) // method for adding a new sit-in order to the sitIns list
        {
            sitIns.Add(s);
        }
        public void AddToDeliveries(DeliveryOrder d) // method for adding a new delivery order to the deliveries list
        {
            deliveries.Add(d);
        }

    }
}
