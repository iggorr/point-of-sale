using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;
using System.IO;


namespace cw2_40125689
{
    /* NewOrder.xaml.cs
    * This is the startup window of the application. 
    * Allows the user to create a new order by selecting various options
    * and generating a bill for the customer with the amount to be paid.
    * Also provides the opportunity to open the manager window.
    * Uses data binding to display contents of lists of the manager object through WPF controls.
    *
    * 
    * Written by Igors Ahmetovs 15/11/15
    * ClassDiagramStage1 created 15/11/15
    * ClassDiagramStage1 amended 19/11/15
    * Changed appearance of window 20/11/15
    * Added data binding 23/11/15
    * Updated appearance of the window 1/12/15
    * Added Create Bill button functionality 8/12/15
    * Updated class diagram to show GUI classes 10/12/15
    * Serialisation added 10/12/15
    * ClassDiagram amended 11/12/15
    */
    public partial class NewOrder : Window
    {
        private Manager theManager = new Manager(); // creating a manager object when on app startup
        private List<Dish> order = new List<Dish>(); // creating a new List of Dishes of the current order 
        private int count = 0; // creating and integer for assigning the order number
        public NewOrder()
        {
            InitializeComponent();

            // deserealising theManager class on app startup
           // XmlSerializer deserializer = new XmlSerializer(typeof(Manager)); // creating the deserializer of type Manager
           // TextReader reader = new StreamReader(@"H:\Manager.xml"); // creating a TextReader, passing the location of the file
          //  object obj = deserializer.Deserialize(reader); // deserializing object
           // theManager = (Manager)obj; // setting theManager to the deserialized object
          //  reader.Close(); // cleaning up

            this.DataContext = theManager; // setting DataContext of the window to theManager for data binding

            // adding orders to the corresponding Server that took the order
            foreach (Server s in theManager.Servers) // iterating through the deserialised servers held in the Manager class
            {
                foreach (Order o in theManager.SitIns) // iterating through the deserialised sit-in orders held in the Manager class
                {
                    if (o.TakenBy.StaffId == s.StaffId) // checking whether the Staff Id of the server that took the order is equal to the current server's Staff Id
                    {
                        s.AddOrder(o); // calling the AddOrder method if condition is met
                    }
                }
                foreach (Order o in theManager.Deliveries) // iterating through the deserialised delivery orders held in the Manager class
                {
                    if (o.TakenBy.StaffId == s.StaffId) // checking whether the Staff Id of the server that took the order is equal to the current server's Staff Id
                    {
                        s.AddOrder(o); // calling the AddOrder method if condition is met
                    }
                }
            }

            // iterating through deserialised orders to find the last order number used
            foreach (Order o in theManager.SitIns) // iterating through sit-in orders
            {
                if (o.OrderNumber >= count) // checking whether the order number of the current order is equal or higher than the current count value
                {
                    count = o.OrderNumber; // setting the count to that order number if the condition was met
                }
            }
            foreach (Order o in theManager.Deliveries) // iterating through delivery orders
            {
                if (o.OrderNumber >= count)  // checking whether the order number of the current order is equal or higher than the current count value
                {
                    count = o.OrderNumber; // setting the count to that order number if the condition was met
                }
            }
        }

        private void btnManager_Click(object sender, RoutedEventArgs e) // modally displaying the manager window on button click
        {
            ManagerWindow newWin = new ManagerWindow(theManager); // passing reference of theManager object to the ManagerWindow through a constructor with 1 argument
            newWin.ShowDialog();
        }

        private void btnAddDish_Click(object sender, RoutedEventArgs e) // adding a Dish from the list of existing Dishes to the one of the current order
        {
            Dish newOrderedDish = (Dish)lbxDishes.SelectedItem; // casting the selected item of the list to a Dish object
            lbxOrder.Items.Add(newOrderedDish); // adding the Dish to the ListBox of items of this order
            order.Add(newOrderedDish); // adding the Dish to the List of items of this order
        }

        private void rdbSitIn_Checked(object sender, RoutedEventArgs e) // displaying Table label and textbox when the radio button is checked
        {
            lblTable.Visibility = System.Windows.Visibility.Visible;
            txtTable.Visibility = System.Windows.Visibility.Visible;
        }

        private void rdbSitIn_Unchecked(object sender, RoutedEventArgs e) // hiding Table label and textbox when the radio button is unchecked
        {
            lblTable.Visibility = System.Windows.Visibility.Hidden;
            txtTable.Visibility = System.Windows.Visibility.Hidden;
            txtTable.Text = ""; // clearing the Table textbox
        }

        private void rdbDelivery_Checked(object sender, RoutedEventArgs e) // displaying Name and Address labels and textboxes when the radio button is checked,
                                                                           // also displaying the Driver label and combobox 
        {
            lblDriver.Visibility = System.Windows.Visibility.Visible;
            cbxDriver.Visibility = System.Windows.Visibility.Visible;
            lblName.Visibility = System.Windows.Visibility.Visible;
            txtName.Visibility = System.Windows.Visibility.Visible;
            lblAddress.Visibility = System.Windows.Visibility.Visible;
            txtAddress.Visibility = System.Windows.Visibility.Visible;

        }

        private void rdbDelivery_Unchecked(object sender, RoutedEventArgs e) // hiding Name and Address labels and textboxes when the radio button is unchecked,
                                                                             // also hiding the Driver label and combobox 
        {
            lblDriver.Visibility = System.Windows.Visibility.Hidden;
            cbxDriver.Visibility = System.Windows.Visibility.Hidden;
            lblName.Visibility = System.Windows.Visibility.Hidden;
            txtName.Visibility = System.Windows.Visibility.Hidden;
            lblAddress.Visibility = System.Windows.Visibility.Hidden;
            txtAddress.Visibility = System.Windows.Visibility.Hidden;
            cbxDriver.SelectedIndex = -1; // unselecting a driver if selected
            txtName.Text = ""; // clearing the Name textbox
            txtAddress.Text = ""; // clearing the Address textbox
        }

        private void btnCreateBill_Click(object sender, RoutedEventArgs e)
        {
            if (rdbSitIn.IsChecked == false && rdbDelivery.IsChecked == false) // checking whether an order type has been selected
            {
                MessageBox.Show("Order type not selected!"); // displaying a message asking the user to specify the order's type
            }
            else
            {
                if (cbxServer.SelectedIndex == -1) // checking whether a Server was selected
                {
                    MessageBox.Show("Please select a server!");
                }
                else
                {
                    if (rdbSitIn.IsChecked == true) // checking whether the SitIn radio button has been checked
                    {
                        if (String.IsNullOrWhiteSpace(txtTable.Text)) // checking if the user has specified table number
                        {
                            MessageBox.Show("Please specify table number!");
                        }
                        else
                        {
                            // using exception to validate whether the action can be performed
                            try
                            {
                                SitInOrder newSitIn = new SitInOrder(); // creating a temporary SitIn order
                                newSitIn.OrderNumber = count+1; // setting the order number to the value of the last count variable used
                                newSitIn.Table = Convert.ToInt32(txtTable.Text); // setting table number of the order to the content of the textbox
                                newSitIn.Items = order; // setting items List of the created order to List order of the window

                                Server tempServer = (Server)cbxServer.SelectedItem; // casting selected item of the listbox to a temporary Server
                                newSitIn.TakenBy = tempServer; // setting the server that took the order to the temporary Server
                                tempServer.AddOrder(newSitIn); // adding the newly created order to a list of taken orders of the Server
                                theManager.AddToSitIns(newSitIn); // adding the newly created sit-in order to the manager through a method

                                // increasing the quantity of each item of the order by 1
                                foreach (Dish d in order)
                                {
                                    d.AddQuantity();
                                }

                                string items = string.Join("\n", order); // converting the contents of the order list to a string with each element starting on a new line

                                // displaying the order number, server, what was ordered and the total
                                MessageBox.Show("Order Number: " + newSitIn.OrderNumber +
                                                "\n\nServer: " + tempServer.Name +
                                                "\n\nTable: " + newSitIn.Table + 
                                                "\n\nOrder:\n" + items + 
                                                "\n\nTotal: " + newSitIn.CalculateTotal());

                                //clearing the window after an order has been created
                                cbxServer.SelectedIndex = -1; // unselecting a server
                                rdbSitIn.IsChecked = false; // unchecking the SitIn radio button
                                txtTable.Text = ""; // clearing the Table textbox
                                lbxOrder.Items.Clear(); // clearing the order listbox
                                order.Clear(); // clearing the order list
                                count += 1; // adding 1 to the count for using it for the next order
                            }
                            catch (Exception excep)
                            {
                                MessageBox.Show(excep.Message);
                            }

                        }

                    }
                    else // if the first condition hasn't been met, means that Delivery radio button is checked
                    {
                        if (cbxDriver.SelectedIndex == -1) // checking if the user has selected a Driver
                        {
                            MessageBox.Show("Please select a driver!");
                        }
                        else
                        {
                            // using exception to validate whether the action can be performed
                            try
                            {
                                DeliveryOrder newDelivery = new DeliveryOrder(); // creating a temporary Delivery order
                                newDelivery.OrderNumber = count + 1; // setting the order number to the value of the last count variable used
                                newDelivery.CustomerName = txtName.Text; // setting customer name of the order to the content of the textbox
                                newDelivery.DeliveryAddress = txtAddress.Text; // setting address of the order to the content of the textbox
                                newDelivery.Items = order; // setting items List of the created order to List order of the window

                                Server tempServer = (Server)cbxServer.SelectedItem; // casting selected item of the listbox to a temporary Server
                                newDelivery.TakenBy = tempServer; // setting the server that took the order to the temporary Server
                                tempServer.AddOrder(newDelivery); // adding the newly created order to a list of taken orders of the Server
                                
                                Driver tempDriver = (Driver)cbxDriver.SelectedItem; // casting selected item of the listbox to a temporary Driver
                                newDelivery.DeliveredBy = tempDriver; // setting the driver that has delivered the order to the temporary Driver
                                tempDriver.AddOrder(newDelivery); // adding the newly created order to a list of delivered orders of the Driver
                                theManager.AddToDeliveries(newDelivery); // adding the newly created delivery order to the manager through a method

                                // increasing the quantity of each item of the order by 1
                                foreach (Dish d in order)
                                {
                                    d.AddQuantity();
                                }

                                string items = string.Join("\n", order); // converting the contents of the order list to a string with each element starting on a new line

                                // displaying the order number, server, driver, what was ordered and the total
                                MessageBox.Show("Order Number: " + newDelivery.OrderNumber +
                                                "\n\nServer: " + tempServer.Name +
                                                "\n\nDriver: " + tempDriver.Name +
                                                "\n\nCustomer Name: " + newDelivery.CustomerName +
                                                "\n\nDelivery Address: " + newDelivery.DeliveryAddress +
                                                "\n\nOrder:\n" + items +
                                                "\n\nTotal: " + newDelivery.CalculateTotal());

                                //clearing the window after an order has been created
                                cbxServer.SelectedIndex = -1; // unselecting a server
                                rdbDelivery.IsChecked = false; // unchecking the Delivery radio button
                                cbxDriver.SelectedIndex = -1; // unselecting a driver
                                txtName.Text = ""; // clearing the Name textbox
                                txtAddress.Text = ""; // clearing the Address textbox
                                lbxOrder.Items.Clear(); // clearing the order listbox
                                order.Clear(); // clearing the order list
                                count += 1; // adding 1 to the count for using it for the next order
                            }
                            catch (Exception excep)
                            {
                                MessageBox.Show(excep.Message);
                            }
                        }
                    }
                }                
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e) // clear button that clears the window 
        {
            cbxServer.SelectedIndex = -1; // unselecting a server if selected
            cbxDriver.SelectedIndex = -1; // unselecting a driver if selected
            rdbSitIn.IsChecked = false; // unchecking the SitIn radio button if checked
            rdbDelivery.IsChecked = false; // unchecking the Delivery radio button if checked
            txtTable.Text = ""; // clearing the Table textbox
            txtName.Text = ""; // clearing the Name textbox
            txtAddress.Text = ""; // clearing the Address textbox
            lbxOrder.Items.Clear(); // clearing the order listbox
            order.Clear(); // clearing the order list
        }

        private void btnSerialise_Click(object sender, RoutedEventArgs e) // serialising the program to a file on the H drive on button click
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Manager));  // creating the serializer of type Manager
            using (TextWriter writer = new StreamWriter(@"H:\Manager.xml")) // creating a TextWriter, passing the location of the file
            {
                serializer.Serialize(writer, theManager); // serialising theManager object
            }

            MessageBox.Show("Changes saved successfully!"); // displaying message after serialisation
        }
    }
}
