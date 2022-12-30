using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Meeter_gibb.Models
{
    public class ListenElement : INotifyPropertyChanged
    {
        DateTime _Id;
        string _Titel;
        string _Beschreibung;
        public DateTime Id
        {
            get
            {
                return _Id;
            }

            set
            {
                if (value != _Id)
                {
                    _Id = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Titel
        {
            get
            {
                return _Titel;
            }

            set
            {
                if (value != _Titel)
                {
                    _Titel = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public string Beschreibung
        {
            get
            {
                return _Beschreibung;
            }

            set
            {
                if (value != _Beschreibung)
                {
                    _Beschreibung = value;
                    NotifyPropertyChanged();
                }
            }
        }
        
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
    }
}
