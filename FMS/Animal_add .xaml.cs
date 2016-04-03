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
        
        public Animal_add()
        {
            InitializeComponent();
            db=Application.Current.Properties["db"] as FMSentities;
            
        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            a_animal an = new a_animal();
            int age;
            float weight;
            int classification;
            int farmer;
            int product;


            bool bage = Int32.TryParse(tf_age.Text, out age);
            bool bweight = float.TryParse(tf_weight.Text, out weight);
            bool bclassifcation = Int32.TryParse(tf_classification.Text, out classification);
            bool bfarmer = Int32.TryParse(tf_farmer.Text, out farmer);
            bool bproduct = Int32.TryParse(tf_product.Text, out product);

            if (product == 0)
            {
                product = 2;
            }
            if (db.pr_product.Find(product) == null)
            {
                MessageBox.Show("Invalid  product", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (db.f_farmer.Find(farmer) == null)
            {
                MessageBox.Show("Invalid  farmer", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (tf_species.Text == "" || !bage || !bweight || !bclassifcation || !bfarmer ) 
            {
                MessageBox.Show("Invalid ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }
            else
            {
 
                an.a_species = tf_species.Text;
                an.a_age = age;
                an.a_weight = weight;
                an.a_classification = classification;
                an.f_farmer_f_id = farmer;
                an.a_pr_product = product;
                db.a_animal.Add(an);

                db.SaveChanges();
                this.Close();
            }


        }
    }
}
