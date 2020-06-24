using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PasswordsManager
{
    class MainViewModel : cls_NotifyPropertyChanged
    {
        public string Recherche
        {
            get { return GetValue<string>(); }
            set { SetValue(value); }
        }

        public ObservableCollection<Models.Password> listeSauvegarde
        {
            get { return GetValue<ObservableCollection<Models.Password>>(); }
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
            listeSauvegarde = new ObservableCollection<Models.Password>();
            var l = DataAccess.PasswordsDbContext.Current.Passwords.Include(p => p.Tags).ThenInclude(pt => pt.Tag).ToList();
            foreach(var pass in l)
            {
                listeSauvegarde.Add(pass);
                Console.WriteLine(pass);
            }
            

            /*
            var t = new Models.Tag()
            {
                Label = "tag"
            };

            var p = new Models.Password()
            {
                Label = "label1",
                Login = "login1",
                Pass = "pass1",
                Url = "url1"
            };

            p.Tags = new List<PasswordTag>();
            p.Tags.Add(new PasswordTag()
            {
                Tag = t
            });

            DataAccess.PasswordsDbContext.Current.Add(p);
            DataAccess.PasswordsDbContext.Current.SaveChanges();
            */

        }
    }
}
