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
    /* OrdersWindow.xaml.cs
    * Window for listing all orders.
    * Allows the manager to select an order to view it's details.
    * Uses data binding to display contents of lists of the manager object through WPF controls.
    * 
    * 
    * Written by Igors Ahmetovs 8/12/2015
    */
    public partial class OrdersWindow : Window
    {
        private Manager theManager; // declaring an instance of the Manager class
        internal OrdersWindow(Manager m) // constructor that takes a manager object as an argument
        {
            InitializeComponent();
            theManager = m; // setting theManager according to the received reference 
            this.DataContext = theManager; // setting DataContext of the window to theManager for data binding
        }

        private void rdbSitIn_Checked(object sender, RoutedEventArgs e) // displaying the necessary elements when the radio button is checked
        {
            lblSitInOrders.Visibility = System.Windows.Visibility.Visible;
            lbxSitInOrders.Visibility = System.Windows.Visibility.Visible;
            lblServer.Visibility = System.Windows.Visibility.Visible;
            lblSitInServer.Visibility = System.Windows.Visibility.Visible;
            lblTable.Visibility = System.Windows.Visibility.Visible;
            lblTableValue.Visibility = System.Windows.Visibility.Visible;
            lblTotal.Visibility = System.Windows.Visibility.Visible;
            lblSitInTotal.Visibility = System.Windows.Visibility.Visible;
        }

        private void rdbSitIn_Unchecked(object sender, RoutedEventArgs e) // hiding the elements when the radio button is unchecked
        {
            lblSitInOrders.Visibility = System.Windows.Visibility.Hidden;
            lbxSitInOrders.Visibility = System.Windows.Visibility.Hidden;
            lblServer.Visibility = System.Windows.Visibility.Hidden;
            lblSitInServer.Visibility = System.Windows.Visibility.Hidden;
            lblTable.Visibility = System.Windows.Visibility.Hidden;
            lblTableValue.Visibility = System.Windows.Visibility.Hidden;
            lblTotal.Visibility = System.Windows.Visibility.Hidden;
            lblSitInTotal.Visibility = System.Windows.Visibility.Hidden;
            lbxSitInOrders.SelectedIndex = -1; // unselecting item of the listbox
        }

        private void rdbDelivery_Checked(object sender, RoutedEventArgs e) // displaying the necessary elements when the radio button is checked
        {
            lblDeliveryOrders.Visibility = System.Windows.Visibility.Visible;
            lbxDeliveryOrders.Visibility = System.Windows.Visibility.Visible;
            lblServer.Visibility = System.Windows.Visibility.Visible;
            lblDeliveryServer.Visibility = System.Windows.Visibility.Visible;
            lblDriver.Visibility = System.Windows.Visibility.Visible;
            lblDriverValue.Visibility = System.Windows.Visibility.Visible;
            lblCustomerName.Visibility = System.Windows.Visibility.Visible;
            lblCustomerNameValue.Visibility = System.Windows.Visibility.Visible;
            lblTotal.Visibility = System.Windows.Visibility.Visible;
            lblDeliveryTotal.Visibility = System.Windows.Visibility.Visible;
        }

        private void rdbDelivery_Unchecked(object sender, RoutedEventArgs e) // hiding the elements when the radio button is unchecked
        {
            lblDeliveryOrders.Visibility = System.Windows.Visibility.Hidden;
            lbxDeliveryOrders.Visibility = System.Windows.Visibility.Hidden;
            lblServer.Visibility = System.Windows.Visibility.Hidden;
            lblDeliveryServer.Visibility = System.Windows.Visibility.Hidden;
            lblDriver.Visibility = System.Windows.Visibility.Hidden;
            lblDriverValue.Visibility = System.Windows.Visibility.Hidden;
            lblCustomerName.Visibility = System.Windows.Visibility.Hidden;
            lblCustomerNameValue.Visibility = System.Windows.Visibility.Hidden;
            lblTotal.Visibility = System.Windows.Visibility.Hidden;
            lblDeliveryTotal.Visibility = System.Windows.Visibility.Hidden;
            lbxDeliveryOrders.SelectedIndex = -1; // unselecting item of the listbox
        }
    }
}
