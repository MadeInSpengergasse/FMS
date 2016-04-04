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
    /// Interaction logic for Property_edit.xaml
    /// </summary>
    public partial class Property_edit : Window
    {
        private FMSentities db;
        private p_property prop;

        public Property_edit()
        {
            InitializeComponent();
            db = Application.Current.Properties["db"] as FMSentities;
            prop = Application.Current.Properties["selectedProperty"] as p_property;

            p_name.Text = prop.p_name;
            p_description.Text = prop.p_description;
            p_f_farmer.Text = prop.p_f_farmer.ToString();
            p_area.Text = prop.p_area.ToString();
            p_c_corn.Text = prop.p_c_corn.ToString();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            int farmer;
            float area;
            int corn;

            bool bfarmer = int.TryParse(p_f_farmer.Text, out farmer);
            bool barea = float.TryParse(p_area.Text, out area);
            bool bcorn = int.TryParse(p_c_corn.Text, out corn);

            if (p_name.Text == "" || p_description.Text == "" || !bfarmer || !barea || !bcorn)
            {
                MessageBox.Show("Invalid entry", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (db.f_farmer.Find(farmer) == null)
            {
                MessageBox.Show("Invalid farmer", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (db.c_corn.Find(corn) == null)
            {
                MessageBox.Show("Invalid corn", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            prop.p_name = p_name.Text;
            prop.p_description = p_description.Text;
            prop.p_f_farmer = farmer;
            prop.p_area = area;
            prop.p_c_corn = corn;

            var original = db.p_property.Find(prop.p_id);
            if (original != null)
            {
                db.Entry(original).CurrentValues.SetValues(prop);
                db.SaveChanges();
                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Properties.Remove("selectedProperty");
        }

        

    }
}
