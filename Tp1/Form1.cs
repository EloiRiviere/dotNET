using System;
using System.IO;
using System.Windows.Forms;

namespace Tp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Bouton_Click(object sender, EventArgs e)
        {

            string chemin = TextBoxRepertoire.Text;
            string fichier = TextBoxFichier.Text;

            EcrireContenuRepertoireDansFichier(chemin, fichier);

            RemplissageRecursifTreeView(chemin, TreeView.Nodes);

        }

        private void RemplissageRecursifTreeView(string chemin, TreeNodeCollection nodes)
        {
            foreach ( var repertoire in Directory.EnumerateDirectories(chemin))
            {
                var node = nodes.Add(repertoire);

                RemplissageRecursifTreeView(repertoire, node.Nodes);

                //foreach (var fichier in Directory.EnumerateFiles(repertoire))
                //{
                //    nodes.Add(fichier);
                //}
            }
        }

        private void EcrireContenuRepertoireDansFichier(string cheminRepertoire, string fichier)
        {

            var fichiers = Directory.EnumerateFiles(cheminRepertoire, "*", SearchOption.AllDirectories);

            using (StreamWriter sw = File.CreateText(fichier))
            {
                foreach (string tmp_fichier in fichiers)
                {
                    sw.WriteLine(tmp_fichier);
                }

            }
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            ListView.Items.Clear();

            string texteNode = e.Node.Text;

            try
            {
                var fichiers = Directory.EnumerateFiles(texteNode);

                foreach (string fichier in fichiers)
                {
                    ListView.Items.Add(fichier);
                }
            }
            catch (IOException e2) { Console.WriteLine(e2); }
            
        }
    }
}
