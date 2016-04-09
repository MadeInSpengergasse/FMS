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
    /// Interaction logic for Corn_info.xaml
    /// </summary>
    public partial class Corn_info : Window
    {
        c_corn corn;
        public Corn_info()
        {
            InitializeComponent();
            corn = Application.Current.Properties["clickedCorn"] as c_corn;
            c_type.Text = corn.c_type;
            c_class.Text = corn.c_class.ToString();
            c_dour.Text = corn.c_dour.ToString();
            c_pr_product.Text = corn.pr_product.pr_type;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Properties.Remove("clickedCorn");
        }
    }
}
