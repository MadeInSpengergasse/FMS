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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Farmer_add : Window
    {
        FMSentities db;
        
        public Farmer_add()
        {
            InitializeComponent();
            db=Application.Current.Properties["db"] as FMSentities;
            
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            f_farmer f = new f_farmer();
            if (tf_firstname.Text == "" || tf_lastname.Text == "" || tf_address.Text == "")
            {
                MessageBox.Show("Invalid ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
                f.f_firstname = tf_firstname.Text;
                f.f_lastname = tf_lastname.Text;
                f.f_address = tf_address.Text;
                db.f_farmer.Add(f);
                db.SaveChanges();
                this.Close();
            }


        }
    }
}
