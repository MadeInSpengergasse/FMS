using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        public ViewModel ViewModel;

        public MainWindow()
        {
            Application.Current.Properties.Add("db", db);

            InitializeComponent();

            ObjectDataProvider odp = this.TryFindResource("viewmodel") as ObjectDataProvider;
            odp.InitialLoad();
            ViewModel = odp.Data as ViewModel;
        }

        // ========== FARMERS ==========

        private void F_add_Click(object sender, RoutedEventArgs e)
        {
            var fa = new Farmer_add();
            fa.ShowDialog();

            ViewModel.RaisePropertyChanged("AllFarmers");
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

            ViewModel.RaisePropertyChanged("AllFarmers");
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
            var farmer_remove = (from x in db.f_farmer where x.f_id == farmer.f_id select x).First();

            db.f_farmer.Remove(farmer_remove);
            db.SaveChanges();

            ViewModel.RaisePropertyChanged("AllFarmers");
            ViewModel.RaisePropertyChanged("AllAnimals");
            ViewModel.RaisePropertyChanged("AllProperties");
        }

        // ========== ANIMALS ==========

        private void A_add_Click(object sender, RoutedEventArgs e)
        {
            var fa = new Animal_add();
            fa.ShowDialog();

            ViewModel.RaisePropertyChanged("AllAnimals");
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

            ViewModel.RaisePropertyChanged("AllAnimals");
        }

        private void A_delete_Click(object sender, RoutedEventArgs e)
        {
            var animal = animals.SelectedItem as a_animal;
            if (animal == null)
            {
                return;
            }
            var animal_remove = (from x in db.a_animal where x.a_id == animal.a_id select x).First();
            db.a_animal.Remove(animal_remove);
            db.SaveChanges();

            ViewModel.RaisePropertyChanged("AllAnimals");
        }

        // ========== PROPERTIES ==========

        private void P_add_Click(object sender, RoutedEventArgs e)
        {
            var propadd = new Property_add();
            propadd.ShowDialog();

            ViewModel.RaisePropertyChanged("AllProperties");
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

            ViewModel.RaisePropertyChanged("AllProperties");
        }

        private void P_delete_Click(object sender, RoutedEventArgs e)
        {
            var property = properties.SelectedItem as p_property;
            if (property == null)
            {
                return;
            }
            var property_remove = (from x in db.p_property where x.p_id == property.p_id select x).First();
            db.p_property.Remove(property_remove);
            db.SaveChanges();

            ViewModel.RaisePropertyChanged("AllProperties");
        }

        // ========== CORN ==========

        private void C_add_Click(object sender, RoutedEventArgs e)
        {
            var cornadd = new Corn_add();
            cornadd.ShowDialog();

            ViewModel.RaisePropertyChanged("AllCorns");
        }

        private void C_edit_Click(object sender, RoutedEventArgs e)
        {
            var corn = corns.SelectedItem as c_corn;
            if (corn == null)
            {
                return;
            }
            Application.Current.Properties.Add("selectedCorn", corn);
            var cornedit = new Corn_edit();
            cornedit.ShowDialog();

            ViewModel.RaisePropertyChanged("AllCorns");
        }

        private void C_delete_Click(object sender, RoutedEventArgs e)
        {
            var corn = corns.SelectedItem as c_corn;
            if (corn == null)
            {
                return;
            }
            var corn_remove = (from x in db.c_corn where x.c_id == corn.c_id select x).First();
            db.c_corn.Remove(corn_remove);
            db.SaveChanges();

            ViewModel.RaisePropertyChanged("AllCorns");
        }

        private void Farmers_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as f_farmer;
            if (item == null) return;
            Application.Current.Properties.Add("clickedFarmer", item);
            new Farmer_info().ShowDialog();
        }

        private void Animals_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as a_animal;
            if (item == null) return;
            Application.Current.Properties.Add("clickedAnimal", item);
            new Animal_info().ShowDialog();
        }

        private void Properties_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as p_property;
            if (item == null) return;
            Application.Current.Properties.Add("clickedProperty", item);
            new Property_info().ShowDialog();
        }

        private void Corns_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as c_corn;
            if (item == null) return;
            Application.Current.Properties.Add("clickedCorn", item);
            new Corn_info().ShowDialog();
        }
    }
}
