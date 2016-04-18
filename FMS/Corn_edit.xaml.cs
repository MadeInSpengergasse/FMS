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

        public ViewModel ViewModel;

        public Corn_edit()
        {
            InitializeComponent();
            db = Application.Current.Properties["db"] as FMSentities;
            corn = Application.Current.Properties["selectedCorn"] as c_corn;

            ObjectDataProvider odp = this.TryFindResource("viewmodel") as ObjectDataProvider;
            odp.InitialLoad();
            ViewModel = odp.Data as ViewModel;

            //TODO: Fix

            c_type.Text = corn.c_type;
            c_class.Text = corn.c_class.ToString();
            c_dour.Text = corn.c_dour.ToString();
            //c_pr_product.Text = corn.c_pr_product.ToString();

            foreach (var item in c_pr_product.Items)
            {
                var asd = item as pr_product;
                if (asd.pr_id == corn.pr_product.pr_id)
                {
                    c_pr_product.SelectedIndex = c_pr_product.Items.IndexOf(asd);
                    break;
                }
            }
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
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
