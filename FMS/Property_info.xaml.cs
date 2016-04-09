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
    /// Interaction logic for Property_info.xaml
    /// </summary>
    public partial class Property_info : Window
    {
        p_property property;
        public Property_info()
        {
            InitializeComponent();
            property = Application.Current.Properties["clickedProperty"] as p_property;
            p_name.Text = property.p_name;
            p_description.Text = property.p_description;
            p_f_farmer.Text = property.f_farmer.f_lastname + ", " + property.f_farmer.f_firstname;
            p_area.Text = property.p_area.ToString();
            p_c_corn.Text = property.c_corn.c_type;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Properties.Remove("clickedProperty");
        }
    }
}
