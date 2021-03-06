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
using System.Windows.Shapes;

namespace FMS
{
    /// <summary>
    /// Interaction logic for Farmer_Product.xaml
    /// </summary>
    public partial class Farmer_Product : Window
    {
        FMSentities db;
        f_farmer f;
        public Farmer_Product()
        {
            InitializeComponent();
            f = Application.Current.Properties["farmer"] as f_farmer;
            db = Application.Current.Properties["db"] as FMSentities;

            var a = from b in db.a_animal
                           where b.f_farmer.f_id == f.f_id
                           select b.pr_product;
            a.Load();
            products.ItemsSource = a.ToList();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Properties.Remove("farmer");
        }
    }
}
