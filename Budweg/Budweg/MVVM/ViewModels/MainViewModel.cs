using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Budweg.MVVM.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {

        private int myVar;

        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged(string propertyName)

        {
            PropertyChangedEventHandler propertyChanged = this.PropertyChanged;

            if (propertyChanged != null)

            {
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
