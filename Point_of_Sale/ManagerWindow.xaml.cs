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
using System.Windows.Shapes;

namespace cw2_40125689
{
    /* ManagerWindow.xaml.cs
    * Manager window of the application.
    * Allows the manager to manipulate menu items, servers, drivers and display all orders/menu items by criteria by linking to the appropriate windows.
    * 
    * 
    * Written by Igors Ahmetovs 27/11/15 
    * Added orders button 8/12/15
    */
    public partial class ManagerWindow : Window
    {
        private Manager theManager; // declaring an instance of the Manager class
        internal ManagerWindow(Manager m) // constructor that takes a manager object as an argument
        {
            InitializeComponent();
            theManager = m; // setting theManager according to the received reference
        }

        private void btnServers_Click(object sender, RoutedEventArgs e) // modally displaying the manage servers on button click
        {
            ManageServers newWin = new ManageServers(theManager); // passing reference of theManager object to the ManageServers window through a constructor with 1 argument
            newWin.ShowDialog();
        }

        private void btnDrivers_Click(object sender, RoutedEventArgs e) // modally displaying the manage servers on button click
        {
            ManageDrivers newWin = new ManageDrivers(theManager); // passing reference of theManager object to the ManageServers window through a constructor with 1 argument
            newWin.ShowDialog();
        }

        private void btnMenuItems_Click(object sender, RoutedEventArgs e) // modally displaying the manage servers on button click
        {
            ManageDishes newWin = new ManageDishes(theManager); // passing reference of theManager object to the ManageDishes window through a constructor with 1 argument
            newWin.ShowDialog();
        }

        private void btnOrders_Click(object sender, RoutedEventArgs e) // modally displaying the order window on button click
        {
            OrdersWindow newWin = new OrdersWindow(theManager); // passing reference of theManager object to the Orders window through a constructor with 1 argument
            newWin.ShowDialog();
        }
    }
}
