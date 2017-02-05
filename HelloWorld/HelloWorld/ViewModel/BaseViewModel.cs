using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        private bool isBusy = false;
        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; OnProperyChange(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnProperyChange([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
