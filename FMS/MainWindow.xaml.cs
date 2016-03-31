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

            var f = db.f_farmer;
            f.Load();
            farmers.ItemsSource = f.Local;
            var a = db.a_animal;
            a.Load();
            animals.ItemsSource = a.Local;
            var p = db.p_property;
            p.Load();
            properties.ItemsSource = p.Local;
            var c = db.c_corn;
            c.Load();
            corns.ItemsSource = c.Local;
        }

        private void Farmer_Click(object sender, RoutedEventArgs e)
        {
            //content1.Children.Clear();
            //content1.Children.Add(new Farmer());
        }

        private void Animal_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Property_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Corn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void F_add_Click(object sender, RoutedEventArgs e)
        {
            var fa = new Farmer_add();
            fa.ShowDialog();
        }

        private void F_edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void F_delete_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
