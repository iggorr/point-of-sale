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
    /* ManageDishes.xaml.cs
    * Window for managing menu items.
    * Allows the manager to manipulate dishes and their details.
    * Uses data binding to display/add/remove/change contents of lists of the manager object through WPF controls.
    * Using exceptions to validate whether the above mentioned actions can be performed.
    * 
    * 
    * Written by Igors Ahmetovs 27/11/2015
    */
    public partial class ManageDishes : Window
    {
        private Manager theManager; // declaring an instance of the Manager class
        internal ManageDishes(Manager m)
        {
            InitializeComponent();
            theManager = m; // setting theManager according to the received reference 
            this.DataContext = theManager; // setting DataContext of the window to theManager for data binding
        }
        private void btnRemoveDish_Click(object sender, RoutedEventArgs e)
        {
            if (lbxDishes.SelectedIndex == -1) // checking if there is a dish selected to remove
            {
                MessageBox.Show("No dish selected!");
            }
            else
            {
                // using exception to validate whether the action can be performed
                try
                {
                    theManager.RemoveDish(lbxDishes.SelectedItem); // calling the RemoveDish method of theManager object by passing the selected Dish
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }

        }
        private void btnAmendDish_Click(object sender, RoutedEventArgs e)
        {
            if (lbxDishes.SelectedIndex == -1) // checking if there is a dish selected to amend
            {
                MessageBox.Show("No dish selected!");
            }
            else
            {
                if (String.IsNullOrWhiteSpace(txtPrice.Text)) // checking that the price field is not blank
                {
                    MessageBox.Show("Price field is empty!");
                }
                else
                {
                    // using exception to validate whether the action can be performed
                    try
                    {
                        Dish tempDish = (Dish)lbxDishes.SelectedItem; // casting selected item of the listbox to a temporary Dish
                        tempDish.Description = txtDescription.Text; // setting the description of the dish to the content of the textbox  
                        tempDish.Price = Convert.ToInt32(txtPrice.Text); // setting the price of the dish to the content of the textbox
                        tempDish.Vegetarian = (bool)ckbVegetarian.IsChecked; // setting whether the dish is vegeterian or not according to the checkbox
                        lbxDishes.Items.Refresh(); // making the changes show up in the listbox
                    }
                    catch (Exception excep)
                    {
                        MessageBox.Show(excep.Message);
                    }
                }
            }
        }
        private void btnAddDish_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtNewPrice.Text)) // checking that the price field is not blank
            {
                MessageBox.Show("Price field is empty!");
            }
            else
            {
                // using exception to validate whether the action can be performed
                try
                {
                    Dish newDish = new Dish(); // creating a temporary Dish object
                    newDish.Description = txtNewDescription.Text; // setting the temp Dish's description to the content of the textbox
                    newDish.Price = Convert.ToInt32(txtNewPrice.Text); // setting the price of the temp Dish to the content of the textbox
                    newDish.Vegetarian = (bool)ckbNewVegetarian.IsChecked; // setting whether the dish is vegeterian or not according to the checkbox
                    theManager.AddToDishes(newDish); // calling method, passing the temporary Dish

                    txtNewDescription.Text = ""; // clearing the contents of the textbox
                    txtNewPrice.Text = ""; // clearing the contents of the textbox
                    ckbNewVegetarian.IsChecked = false; // unchecking the checkbox
                }
                catch (Exception excep)
                {
                    MessageBox.Show(excep.Message);
                }
            }

        }
    }
}
