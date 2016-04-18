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

        public ViewModel ViewModel;

        public Corn_add()
        {
            InitializeComponent();
            db = Application.Current.Properties["db"] as FMSentities;

            ObjectDataProvider odp = this.TryFindResource("viewmodel") as ObjectDataProvider;
            odp.InitialLoad();
            ViewModel = odp.Data as ViewModel;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            c_corn corn = new c_corn();

            int class_;
            int dour;

            bool bclass = int.TryParse(c_class.Text, out class_);
            bool bdour = int.TryParse(c_dour.Text, out dour);

            if (c_type.Text == "" || !bclass || !bdour)
            {
                MessageBox.Show("Invalid entry", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            corn.c_type = c_type.Text;
            corn.c_class = class_;
            corn.c_dour = dour;
            corn.c_pr_product = (c_pr_product.SelectedItem as pr_product).pr_id;

            db.c_corn.Add(corn);
            db.SaveChanges();
            this.Close();
        }
    }
}
