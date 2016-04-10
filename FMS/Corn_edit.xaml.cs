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
    /// Interaction logic for Corn_edit.xaml
    /// </summary>
    public partial class Corn_edit : Window
    {
        private FMSentities db;
        private c_corn corn;

        public Corn_edit()
        {
            InitializeComponent();
            db = Application.Current.Properties["db"] as FMSentities;
            corn = Application.Current.Properties["selectedCorn"] as c_corn;

            c_type.Text = corn.c_type;
            c_class.Text = corn.c_class.ToString();
            c_dour.Text = corn.c_dour.ToString();
            c_pr_product.Text = corn.c_pr_product.ToString();
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            int class_;
            int dour;
            int product;

            bool bclass = int.TryParse(c_class.Text, out class_);
            bool bdour = int.TryParse(c_dour.Text, out dour);
            bool bproduct = int.TryParse(c_pr_product.Text, out product);
            //TODO: Product can be null
            if (c_type.Text == "" || !bclass || !bdour || !bproduct)
            {
                MessageBox.Show("Invalid entry", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (db.pr_product.Find(product) == null)
            {
                MessageBox.Show("Invalid product", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            corn.c_type = c_type.Text;
            corn.c_class = class_;
            corn.c_dour = dour;
            corn.c_pr_product = product;

            var original = db.c_corn.Find(corn.c_id);
            if (original != null)
            {
                db.Entry(original).CurrentValues.SetValues(corn);
                db.SaveChanges();
                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Properties.Remove("selectedCorn");
        }

        

    }
}
