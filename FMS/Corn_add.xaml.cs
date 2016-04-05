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
    /// Interaction logic for Corn_add.xaml
    /// </summary>
    public partial class Corn_add : Window
    {
        FMSentities db;
        
        public Corn_add()
        {
            InitializeComponent();
            db = Application.Current.Properties["db"] as FMSentities;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            c_corn corn = new c_corn();

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

            db.c_corn.Add(corn);
            db.SaveChanges();
            this.Close();
        }
    }
}
