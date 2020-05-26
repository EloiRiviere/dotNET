using PasswordsManager.Models;
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

            // Si la base de données n'existe pas, on insère des données test
            if(! fileExist)
            {
                List<Models.Tag> listeTags = new List<Models.Tag>
                {
                    new Models.Tag()
                    {
                        Label = "tag1"
                    },
                    new Models.Tag()
                    {
                        Label = "tag2"
                    },
                    new Models.Tag()
                    {
                        Label = "tag3"
                    },
                    new Models.Tag()
                    {
                        Label = "tag4"
                    },
                    new Models.Tag()
                    {
                        Label = "tag5"
                    }
                };

                List<Models.Password> listePasswords = new List<Models.Password>
                {
                    new Models.Password()
                    {
                        Label = "label1",
                        Login = "login1",
                        Pass = "pass1",
                        Url = "url1"
                    },
                    new Models.Password()
                    {
                        Label = "label2",
                        Login = "login2",
                        Pass = "pass2",
                        Url = "url2"
                    },
                    new Models.Password()
                    {
                        Label = "label3",
                        Login = "login3",
                        Pass = "pass3",
                        Url = "url3"
                    },
                    new Models.Password()
                    {
                        Label = "label4",
                        Login = "login4",
                        Pass = "pass4",
                        Url = "url4"
                    },
                    new Models.Password()
                    {
                        Label = "label5",
                        Login = "login5",
                        Pass = "pass5",
                        Url = "url5"
                    }
                };

                for(int i=0; i<5; i++)
                {
                    listePasswords[i].Tags = new List<PasswordTag>();
                    listePasswords[i].Tags.Add(new PasswordTag()
                    {
                        Tag = listeTags[i]
                    });
                    DataAccess.PasswordsDbContext.Current.Add(listePasswords[i]);
                }

                DataAccess.PasswordsDbContext.Current.SaveChanges();

                Console.WriteLine(listePasswords);
                foreach(Password p in listePasswords)
                {
                    Console.WriteLine(p);
                }
            }
        }

    }
}
