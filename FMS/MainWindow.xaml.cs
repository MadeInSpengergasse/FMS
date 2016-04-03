using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FMS
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FMSentities db = new FMSentities();

        public MainWindow()
        {
            Application.Current.Properties.Add("db", db);

            InitializeComponent();
        }

        // ========== FARMERS ==========

        private void F_add_Click(object sender, RoutedEventArgs e)
        {
            var fa = new Farmer_add();
            fa.ShowDialog();
        }

        private void F_edit_Click(object sender, RoutedEventArgs e)
        {
            if (farmers.SelectedItem == null)
            {
                return;
            }
            Application.Current.Properties.Add("selectedFarmer", farmers.SelectedItem);
            var fa = new Farmer_edit();
            fa.ShowDialog();
        }

        private void F_delete_Click(object sender, RoutedEventArgs e)
        {
            var farmer = farmers.SelectedItem as f_farmer;
            if (farmer == null)
            {
                return;
            }
            int id = farmer.f_id;
            var anim = from an in db.a_animal
                       where an.f_farmer_f_id == id
                       select an;

            var prop = from p in db.p_property
                       where p.p_f_farmer == id
                       select p;

            db.a_animal.RemoveRange(anim);
            db.p_property.RemoveRange(prop);

            db.f_farmer.Remove(farmer);
            db.SaveChanges();
        }

        // ========== ANIMALS ==========

        private void A_add_Click(object sender, RoutedEventArgs e)
        {
            var fa = new Animal_add();
            fa.ShowDialog();
        }

        private void A_edit_Click(object sender, RoutedEventArgs e)
        {
            var animal = animals.SelectedItem;
            if (animal == null)
            {
                return;
            }
            Application.Current.Properties.Add("selectedAnimal", animal);
            var an = new Animal_edit();
            an.ShowDialog();
        }

        private void A_delete_Click(object sender, RoutedEventArgs e)
        {
            var animal = animals.SelectedItem as a_animal;
            if (animal == null)
            {
                return;
            }
            db.a_animal.Remove(animal);
            db.SaveChanges();
        }

        // ========== PROPERTIES ==========

        private void P_add_Click(object sender, RoutedEventArgs e)
        {
            var propadd = new Property_add();
            propadd.ShowDialog();
        }

        private void P_edit_Click(object sender, RoutedEventArgs e)
        {
            var property = properties.SelectedItem;
            if (property == null)
            {
                return;
            }
            Application.Current.Properties.Add("selectedProperty", property);
            var propedit = new Property_edit();
            propedit.ShowDialog();
        }

        private void P_delete_Click(object sender, RoutedEventArgs e)
        {
            var property = properties.SelectedItem as p_property;
            if (property == null)
            {
                return;
            }
            db.p_property.Remove(property);
            db.SaveChanges();
        }

        // ========== CORN ==========

        private void C_add_Click(object sender, RoutedEventArgs e)
        {
            //var cornadd = new Corn_add();
            //cornadd.ShowDialog();
        }

        private void C_edit_Click(object sender, RoutedEventArgs e)
        {
            var corn = corns.SelectedItem as c_corn;
            if (corn == null)
            {
                return;
            }
            Application.Current.Properties.Add("selectedCorn", corn);
            //var cornedit = new Corn_edit();
            //cornedit.ShowDialog();
        }

        private void C_delete_Click(object sender, RoutedEventArgs e)
        {
            var corn = corns.SelectedItem as c_corn;
            if (corn == null)
            {
                return;
            }
            db.c_corn.Remove(corn);
            db.SaveChanges();
        }
    }
}
