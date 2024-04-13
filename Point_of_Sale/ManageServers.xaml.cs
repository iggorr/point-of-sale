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
    /* ManageServers.xaml.cs
    * Window for managing servers.
    * Allows the manager to manipulate servers and their details.
    * Uses data binding to display/add/remove/change contents of lists of the manager object through WPF controls.
    * Using exceptions to validate whether the above mentioned actions can be performed.
    * 
    * 
    * Written by Igors Ahmetovs 20/11/2015
    * Added data binding 20/11/15
    * Added Remove button functionality 23/11/15
    * Added Name and Staff ID labels+text boxes with data binding 23/11/15
    * Added amend button functionality 23/11/15
    * Changed appearance of the window 23/11/15
    * Changed binding mode of Staff ID and Name textboxes to OneWay 27/11/15
    * Added solution to avoid multiple servers with the same Staff ID 27/11/15
    * Added a listbox control displaying all the orders taken 10/12/15
    */
    public partial class ManageServers : Window
    {
        private Manager theManager; // declaring an instance of the Manager class
        internal ManageServers(Manager m) // constructor that takes a manager object as an argument
        {
            InitializeComponent();
            theManager = m; // setting theManager according to the received reference 
            this.DataContext = theManager; // setting DataContext of the window to theManager for data binding
        }

        private void btnRemoveServer_Click(object sender, RoutedEventArgs e) 
        {
            if (lbxServers.SelectedIndex == -1) // checking if there is a server selected to remove
            {
                MessageBox.Show("No server selected!");
            }
            else
            {
                // using exception to validate whether the action can be performed
                try
                {
                    theManager.RemoveServer(lbxServers.SelectedItem); // calling the RemoveServer method of theManager object by passing the selected Server
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }

        }

        private void btnAmendServer_Click(object sender, RoutedEventArgs e)
        {
            if (lbxServers.SelectedIndex == -1) // checking if there is a server selected to amend
            {
                MessageBox.Show("No server selected!");
            }
            else
            {
                if (String.IsNullOrWhiteSpace(txtStaffId.Text)) // checking that the staff ID field is not blank
                {
                    MessageBox.Show("Staff ID field is empty!");
                }
                else
                {
                    // using exception to validate whether the action can be performed
                    try
                    {
                        Server tempServer = (Server)lbxServers.SelectedItem; // casting selected item of the listbox to a temporary Server
                        if (tempServer.StaffId == Convert.ToInt32(txtStaffId.Text)) // check if the staff ID is not to be changed
                        {
                            tempServer.Name = txtName.Text; // setting the Server's name to the content of the textbox   
                        }
                        else // if the staff ID is to be changed
                        {
                            theManager.CheckIfIdUnique(Convert.ToInt32(txtStaffId.Text)); // checking that the Staff ID isn't taken  
                            tempServer.StaffId = Convert.ToInt32(txtStaffId.Text); // setting the Server's ID to the content of the textbox
                            tempServer.Name = txtName.Text; // setting the Server's name to the content of the textbox   
                        }
                        lbxServers.Items.Refresh(); // making the changes show up in the listbox
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.Message);
                    }
                }
            }
        }

        private void btnAddServer_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNewStaffId.Text)) // checking that the staff ID field is not blank
            {
                MessageBox.Show("Staff ID field is empty!");
            }
            else
            {
                // using exception to validate whether the action can be performed
                try
                {
                    Server newServer = new Server(); // creating a temporary Server object
                    newServer.StaffId = Convert.ToInt32(txtNewStaffId.Text); // setting staff ID of the temp Server to the content of the textbox
                    newServer.Name = txtNewName.Text; // setting the temp Server's name to the content of the textbox
                    theManager.AddToServers(newServer); // calling method, passing the temporary server

                    txtNewStaffId.Text = ""; // clearing the contents of the textbox
                    txtNewName.Text = ""; // clearing the contents of the textbox
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }

        }
    }
}
