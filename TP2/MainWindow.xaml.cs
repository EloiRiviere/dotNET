using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;

namespace TP2
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        private Dictionary<string, object> _propertyValues = new Dictionary<string, object>();

        public T GetValue<T>([CallerMemberName] string propertyName = null)
        {
            if (_propertyValues.ContainsKey(propertyName))
                return (T)_propertyValues[propertyName];
            return default(T);
        }
        public bool SetValue<T>(T newValue, [CallerMemberName] string propertyName = null)
        {
            var currentValue = GetValue<T>(propertyName);
            if (currentValue == null && newValue != null
             || currentValue != null && !currentValue.Equals(newValue))
            {
                _propertyValues[propertyName] = newValue;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
                return true;
            }
            return false;
        }

        #endregion

        public string MonTexte
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public string TexteSelectionne
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public ObservableCollection<string> MaListe
        {
            get { return GetValue<ObservableCollection<string>>(); }
            set { SetValue(value); }
        }

        public MainWindow()
        {
            InitializeComponent();
            MonTexte = "Un texte issu du databinding.";
            TexteSelectionne = "";
            this.DataContext = this;
            MaListe = new ObservableCollection<string>();
            MaListe.Add("Element n°1");
            MaListe.Add("Element n°2");
            MaListe.Add("Element n°3");
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            MonTexte = "Un autre texte !";
            MaListe.Add("Element n°" + (MaListe.Count() + 1));
        }

        private void Delete_Button_Click(object sender, RoutedEventArgs e)
        {
            MonTexte = "Un autre texte !";
            MaListe.Remove(TexteSelectionne);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MonTexte = "Un autre texte !";
        }
    }
}