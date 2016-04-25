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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Animal_add : Window
    {
        FMSentities db;

        public ViewModel ViewModel;

        public Animal_add()
        {
            InitializeComponent();
            db = Application.Current.Properties["db"] as FMSentities;

            ObjectDataProvider odp = this.TryFindResource("viewmodel") as ObjectDataProvider;
            odp.InitialLoad();
            ViewModel = odp.Data as ViewModel;
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            a_animal an = new a_animal();
            int age;
            float weight;
            int classification;
            int product;

            bool bage = int.TryParse(tf_age.Text, out age);
            bool bweight = float.TryParse(tf_weight.Text, out weight);
            bool bclassifcation = int.TryParse(tf_classification.Text, out classification);
           
            if (tf_species.Text == "" || !bage || !bweight || !bclassifcation || cb_farmer.SelectedItem == null)
            {
                MessageBox.Show("Invalid", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            an.a_species = tf_species.Text;
            an.a_age = age;
            an.a_weight = weight;
            an.a_classification = classification;
            an.f_farmer_f_id = (cb_farmer.SelectedItem as f_farmer).f_id;
            an.a_pr_product = cb_product.SelectedItem == null ? 2 : (cb_product.SelectedItem as pr_product).pr_id;
            db.a_animal.Add(an);

            db.SaveChanges();
            this.Close();
        }
    }
}
