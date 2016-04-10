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
    /// Interaction logic for Animal_info.xaml
    /// </summary>
    public partial class Animal_info : Window
    {
        a_animal animal;
        public Animal_info()
        {
            InitializeComponent();
            animal = Application.Current.Properties["clickedAnimal"] as a_animal;
            a_species.Text = animal.a_species;
            a_age.Text = animal.a_age.ToString();
            a_weight.Text = animal.a_weight.ToString();
            a_classification.Text = animal.a_classification.ToString();
            f_farmer_f_id.Text = animal.f_farmer.f_lastname + ", " + animal.f_farmer.f_firstname;
            a_pr_product.Text = animal.pr_product.pr_type;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Properties.Remove("clickedAnimal");
        }
    }
}
