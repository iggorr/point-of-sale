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
    /* ManageDrivers.xaml.cs
    * Window for managing drivers.
    * Allows the manager to manipulate drivers and their details.
    * Uses data binding to display/add/remove/change contents of lists of the manager object through WPF controls.
    * Using exceptions to validate whether the above mentioned actions can be performed.
    * 
    * 
    * Written by Igors Ahmetovs 27/11/2015
    */
    public partial class ManageDrivers : Window
    {
        private Manager theManager; // declaring an instance of the Manager class
        internal ManageDrivers(Manager m) // constructor that takes a manager object as an argument
        {
            InitializeComponent();
            theManager = m; // setting theManager according to the received reference 
            this.DataContext = theManager; // setting DataContext of the window to theManager for data binding
        }
        private void btnRemoveDriver_Click(object sender, RoutedEventArgs e)
        {
            if (lbxDrivers.SelectedIndex == -1) // checking if there is a driver selected to remove
            {
                MessageBox.Show("No driver selected!");
            }
            else
            {
                // using exception to validate whether the action can be performed
                try
                {
                    theManager.RemoveDriver(lbxDrivers.SelectedItem); // calling the RemoveDish method of theManager object by passing the selected Driver
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }

        }
        private void btnAmendDriver_Click(object sender, RoutedEventArgs e)
        {
            if (lbxDrivers.SelectedIndex == -1) // checking if there is a driver selected to amend
            {
                MessageBox.Show("No driver selected!");
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
                        Driver tempDriver = (Driver)lbxDrivers.SelectedItem; // casting selected item of the listbox to a temporary Driver
                        if (tempDriver.StaffId == Convert.ToInt32(txtStaffId.Text)) // check if the staff ID is not to be changed
                        {
                            tempDriver.Name = txtName.Text; // setting the Driver's name to the content of the textbox  
                            tempDriver.CarReg = txtCarReg.Text; // setting the Driver's car registration to the content of the textbox
                        }
                        else // if the staff ID is to be changed
                        {
                            theManager.CheckIfIdUnique(Convert.ToInt32(txtStaffId.Text)); // checking that the Staff ID isn't taken  
                            tempDriver.StaffId = Convert.ToInt32(txtStaffId.Text); // setting the Driver's ID to the content of the textbox
                            tempDriver.Name = txtName.Text; // setting the Driver's name to the content of the textbox  
                            tempDriver.CarReg = txtCarReg.Text; // setting the Driver's car registration to the content of the textbox
                        }
                        lbxDrivers.Items.Refresh(); // making the changes show up in the listbox
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.Message);
                    }
                }
            }
        }
        private void btnAddDriver_Click(object sender, RoutedEventArgs e)
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
                    Driver newDriver = new Driver(); // creating a temporary Driver object
                    newDriver.StaffId = Convert.ToInt32(txtNewStaffId.Text); // setting staff ID of the temp Driver to the content of the textbox
                    newDriver.Name = txtNewName.Text; // setting the temp Driver's name to the content of the textbox
                    newDriver.CarReg = txtNewCarReg.Text; // setting the temp Driver's registration to the content of the textbox
                    theManager.AddToDrivers(newDriver); // calling method, passing the temporary Driver

                    txtNewStaffId.Text = ""; // clearing the contents of the textbox
                    txtNewName.Text = ""; // clearing the contents of the textbox
                    txtNewCarReg.Text = ""; // clearing the contents of the textbox
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }

        }


    }
}
