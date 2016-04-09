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
    /// Interaction logic for Farmer_info.xaml
    /// </summary>
    public partial class Farmer_info : Window
    {
        f_farmer fa;
        public Farmer_info()
        {
            InitializeComponent();
            fa = Application.Current.Properties["clickedFarmer"] as f_farmer;
            f_firstname.Text = fa.f_firstname;
            f_lastname.Text = fa.f_lastname;
            f_address.Text = fa.f_address;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Properties.Remove("clickedFarmer");
        }
    }
}
