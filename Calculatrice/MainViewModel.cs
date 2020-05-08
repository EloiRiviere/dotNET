using System;
using System.Collections.ObjectModel;

namespace Calculatrice
{
    class MainViewModel : cls_NotifyPropertyChanged
    {
        public string StrAffichageTbx
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string NbInUser
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string AffichagesHistoriqueCalcAD
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string AffichagesHistoriqueResAD
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string AffichagesHistoriqueCalcD
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string AffichagesHistoriqueResD
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public ObservableCollection<string> historiqueObservable
        {
            get { return GetValue<ObservableCollection<string>>(); }
            set { SetValue(value); }
        }

        public MainViewModel()
        {
            StrAffichageTbx = string.Empty;
            NbInUser = string.Empty;
            historiqueObservable = new ObservableCollection<string>();
        }
    }
}
