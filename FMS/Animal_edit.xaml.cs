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
    /// Interaction logic for Animal_edit.xaml
    /// </summary>
    public partial class Animal_edit : Window
    {
        FMSentities db;
        a_animal an;
        public Animal_edit()
        {
            InitializeComponent();
            db = Application.Current.Properties["db"] as FMSentities;
             an = Application.Current.Properties["selectedAnimal"] as a_animal;

            tf_species.Text = an.a_species;
            tf_age.Text = an.a_age.ToString(); 
            tf_weight.Text =an.a_weight.ToString();
            tf_classification.Text = an.a_classification.ToString();
            tf_farmer.Text = an.f_farmer_f_id.ToString();
            tf_product.Text = an.a_pr_product.ToString();

           
        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
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
            if (tf_species.Text == "" || !bage || !bweight || !bclassifcation || !bfarmer)
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

                var original = db.a_animal.Find(an.a_id);
                if (original != null)
                {
                    db.Entry(original).CurrentValues.SetValues(an);
                    db.SaveChanges();
                    this.Close();
                }
                

                
            } 
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Properties.Remove("selectedAnimal");
        }

        

    }
}
