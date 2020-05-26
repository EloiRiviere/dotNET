using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PasswordsManager
{
    /// <summary>
    /// Logique d'interaction pour App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var fileExist = System.IO.File.Exists("passwords.db");
            await DataAccess.PasswordsDbContext.Initialize();
            if(! fileExist)
            {
                // ajouter données bdd
            }
        }

    }
}
