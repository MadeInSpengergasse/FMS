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
    /// Interaction logic for Property_add.xaml
    /// </summary>
    public partial class Property_add : Window
    {
        FMSentities db;
        
        public Property_add()
        {
            InitializeComponent();
            db = Application.Current.Properties["db"] as FMSentities;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            p_property prop = new p_property();

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

            db.p_property.Add(prop);

            db.SaveChanges();
            this.Close();
        }
    }
}
