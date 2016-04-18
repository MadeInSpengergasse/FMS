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
            tf_weight.Text = an.a_weight.ToString();
            tf_classification.Text = an.a_classification.ToString();
           
            foreach(var item in cb_farmer.Items) {
                var asd = item as f_farmer;
                if(asd.f_id == an.f_farmer.f_id)
                {
                    cb_farmer.SelectedIndex = cb_farmer.Items.IndexOf(asd);
                    break;
                }
            }
            foreach (var item in cb_product.Items)
            {
                var asd = item as pr_product;
                if (asd.pr_id == an.pr_product.pr_id)
                {
                    cb_product.SelectedIndex = cb_product.Items.IndexOf(asd);
                    break;
                }
            }


        }

        private void edit_Click(object sender, RoutedEventArgs e)
        {
            int age;
            float weight;
            int classification;
            
            int product;

            bool bage = int.TryParse(tf_age.Text, out age);
            bool bweight = float.TryParse(tf_weight.Text, out weight);
            bool bclassifcation = int.TryParse(tf_classification.Text, out classification);

            if (tf_species.Text == "" || !bage || !bweight || !bclassifcation)
            {
                MessageBox.Show("Invalid ", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            an.a_species = tf_species.Text;
            an.a_age = age;
            an.a_weight = weight;
            an.a_classification = classification;
            an.f_farmer_f_id = (cb_farmer.SelectedItem as f_farmer).f_id;
            an.a_pr_product = (cb_product.SelectedItem as pr_product).pr_id;

            var original = db.a_animal.Find(an.a_id);
            if (original != null)
            {
                db.Entry(original).CurrentValues.SetValues(an);
                db.SaveChanges();
                this.Close();
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Properties.Remove("selectedAnimal");
        }
    }
}
