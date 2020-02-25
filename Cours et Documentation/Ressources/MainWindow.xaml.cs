using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
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

        public MainWindow()
        {
            InitializeComponent();
            MonTexte = "Un texte issu du databinding.";
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MonTexte = "Un autre texte !";
        }
    }
}
