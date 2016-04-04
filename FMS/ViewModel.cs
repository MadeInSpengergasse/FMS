using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FMS
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        FMSentities dbglobal;

        public ViewModel()
        {
            dbglobal = new FMSentities();
        }

        public IEnumerable<f_farmer> AllFarmers
        {
            get
            {
                return dbglobal.f_farmer.ToList();
            }
        }

        public IEnumerable<a_animal> AllAnimals
        {
            get
            {
                return dbglobal.a_animal.ToList();
            }
        }

        public IEnumerable<p_property> AllProperties
        {
            get
            {
                return dbglobal.p_property.ToList();
            }
        }

        public IEnumerable<c_corn> AllCorns
        {
            get
            {
                return dbglobal.c_corn.ToList();
            }
        }

        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
