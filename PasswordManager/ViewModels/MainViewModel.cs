using System.Collections.ObjectModel;

namespace PasswordsManager
{
    class MainViewModel : cls_NotifyPropertyChanged
    {
        public string Recherche
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public ObservableCollection<UserControlListe> listeSauvegarde
        {
            get { return GetValue<ObservableCollection<UserControlListe>>(); }
            set { SetValue(value); }
        }

        public string FormulaireIdentifiant
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string FormulaireMotDePasse
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string FormulaireURL
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string FormulaireLabel
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string FormulaireTags
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public MainViewModel()
        {
            Recherche = string.Empty;
        }
    }
}
