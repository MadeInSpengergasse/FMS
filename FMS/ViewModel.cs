using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FMS
{
    public class ViewModel : INotifyPropertyChanged
    {
        FMSentities dbglobal;
        private ObservableCollection<f_farmer> OLFarmers;
        public ViewModel ()
        {
            dbglobal = new FMSentities();
        }
        
        public IEnumerable<f_farmer> AllFarmers
        {
            get
            {
                var f = dbglobal.f_farmer;
                f.Load();
                return f.Local;
            }

          
        }
        public IEnumerable<a_animal> AllAnimals
        {
            get
            {
                var a = dbglobal.a_animal;
                a.Load();
                return a.Local;
            }


        }

        public IEnumerable<p_property> AllProperties
        {
            get
            {
                var p = dbglobal.p_property;
                p.Load();
                return p.Local;
            }


        }

        public IEnumerable<c_corn> AllCorns
        {
            get
            {
                var c = dbglobal.c_corn;
                c.Load();
                return c.Local;
            }


        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
