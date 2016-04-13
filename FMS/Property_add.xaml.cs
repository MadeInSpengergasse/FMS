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
       public  ViewModel ViewModel;
        
        public Property_add()
        {
            InitializeComponent();
            db = Application.Current.Properties["db"] as FMSentities;

            ObjectDataProvider odp = this.TryFindResource("viewmodel") as ObjectDataProvider;
            odp.InitialLoad();
            ViewModel = odp.Data as ViewModel;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            p_property prop = new p_property();

            
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

            db.p_property.Add(prop);

            db.SaveChanges();
            this.Close();
        }
    }
}
