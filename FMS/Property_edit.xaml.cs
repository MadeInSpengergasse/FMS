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
           
            p_area.Text = prop.p_area.ToString();
            
            foreach (var item in cb_farmer.Items)
            {
                var asd = item as f_farmer;
                if (asd.f_id == prop.f_farmer.f_id)
                {
                    cb_farmer.SelectedIndex = cb_farmer.Items.IndexOf(asd);
                }
            }
            foreach (var item in cb_corn.Items)
            {
                var asd = item as c_corn;
                if (asd.c_id == prop.c_corn.c_id)
                {
                    cb_corn.SelectedIndex = cb_corn.Items.IndexOf(asd);
                }
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            
            float area;
           

           
            bool barea = float.TryParse(p_area.Text, out area);
          

            if (p_name.Text == "" || p_description.Text == "" || !barea)
            {
                MessageBox.Show("Invalid entry", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            prop.p_name = p_name.Text;
            prop.p_description = p_description.Text;
            prop.p_f_farmer = (cb_farmer.SelectedItem as f_farmer).f_id;
            prop.p_area = area;
            prop.p_c_corn = (cb_corn.SelectedItem as c_corn).c_id;

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