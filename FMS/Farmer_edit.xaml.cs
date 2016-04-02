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

namespace FMS
{
    /// <summary>
    /// Interaction logic for Farmer_edit.xaml
    /// </summary>
    public partial class Farmer_edit : Window
    {
        FMSentities db;
        f_farmer fa;
        public Farmer_edit()
        {
            InitializeComponent();
            db = Application.Current.Properties["db"] as FMSentities;
             fa = Application.Current.Properties["selectedFarmer"] as f_farmer;
            tf_firstname.Text = fa.f_firstname;
            tf_lastname.Text = fa.f_lastname;
            tf_address.Text = fa.f_address;

           
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            if (tf_firstname.Text == "" || tf_lastname.Text == "" || tf_address.Text == "")
            {
                MessageBox.Show("Invalid ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                fa.f_firstname = tf_firstname.Text;
                fa.f_lastname = tf_lastname.Text;
                fa.f_address = tf_address.Text;

                var original = db.f_farmer.Find(fa.f_id);
                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(fa);
                    db.SaveChanges();
                    this.Close();
                }
                

                
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Properties.Remove("selectedFarmer");
        }
    }
}
