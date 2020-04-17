using System;

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

        public string AffichagesHistorique
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }

        }

        public MainViewModel()
        {
            StrAffichageTbx = string.Empty;
            NbInUser = string.Empty;
        }
    }
}
