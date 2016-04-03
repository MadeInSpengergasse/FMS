﻿using System;
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



        }


        private void F_add_Click(object sender, RoutedEventArgs e)
        {
            var fa = new Farmer_add();
            fa.ShowDialog();
            var f = db.f_farmer;
            f.Load();
            farmers.ItemsSource = null;
            farmers.ItemsSource = f.Local;
        }

        private void F_edit_Click(object sender, RoutedEventArgs e)
        {
            if (farmers.SelectedItem == null)
            {

            }
            else
            {
                Application.Current.Properties.Add("selectedFarmer", farmers.SelectedItem);
                var fa = new Farmer_edit();
                
                fa.ShowDialog();
                var f = db.f_farmer;
                f.Load();
                farmers.ItemsSource = null;
                farmers.ItemsSource = f.Local;
                
                
            }
        }

 




        private void F_delete_Click(object sender, RoutedEventArgs e)
        {
            var test = farmers.SelectedItem as f_farmer;
            int id = test.f_id;
            var anim = from an in db.a_animal
                          where an.f_farmer_f_id == id
                          select an;

            var prop = from p in db.p_property
                              where p.p_f_farmer== id
                              select p;

            db.a_animal.RemoveRange(anim);
            db.p_property.RemoveRange(prop);
            db.SaveChanges();
            db.f_farmer.Remove(farmers.SelectedItem as f_farmer);
            db.SaveChanges();

            var a = db.a_animal;
            a.Load();
            animals.ItemsSource = null; // is this neccesary?
            animals.ItemsSource = a.Local;
        }

        private void A_add_Click(object sender, RoutedEventArgs e)
        {
            var fa = new Animal_add();
            fa.ShowDialog();
            var a = db.a_animal;
            a.Load();
            animals.ItemsSource = null; // is this neccesary?
            animals.ItemsSource = a.Local;
        }

        private void A_edit_Click(object sender, RoutedEventArgs e)
        {
            if (animals.SelectedItem == null)
            {

            }
            else
            {
                Application.Current.Properties.Add("selectedAnimal", animals.SelectedItem);
                var an = new Animal_edit();

                an.ShowDialog();
                var a = db.a_animal;
                a.Load();
                animals.ItemsSource = null; // is this neccesary?
                animals.ItemsSource = a.Local;
            }
        }

        private void A_delete_Click(object sender, RoutedEventArgs e)
        {
            db.a_animal.Remove(animals.SelectedItem as a_animal);
            db.SaveChanges();
        }

        private void P_add_Click(object sender, RoutedEventArgs e)

        {
            db.f_farmer.Remove(farmers.SelectedItem as f_farmer);
            db.SaveChanges();
        }






        private void P_edit_Click(object sender, RoutedEventArgs e)
        {
            if (animals.SelectedItem == null)
            {

            }
            else
            {
                Application.Current.Properties.Add("selectedAnimal", animals.SelectedItem);
                var an = new Animal_edit();

                an.ShowDialog();
                var a = db.a_animal;
                a.Load();
                animals.ItemsSource = null;
                animals.ItemsSource = a.Local;


            }
        }


 

       

        private void P_delete_Click(object sender, RoutedEventArgs e)
        {
            db.p_property.Remove(properties.SelectedItem as p_property);
            db.SaveChanges();
        }

        private void C_add_Click(object sender, RoutedEventArgs e)

        {

        }


  

 



        private void C_edit_Click(object sender, RoutedEventArgs e)
        {

        }

       

 

        private void C_delete_Click(object sender, RoutedEventArgs e)
        {
            db.c_corn.Remove(corns.SelectedItem as c_corn);
            db.SaveChanges();
        }
    }
}
