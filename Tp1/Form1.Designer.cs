namespace Tp1
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBoxRepertoire = new System.Windows.Forms.TextBox();
            this.Répertoire = new System.Windows.Forms.Label();
            this.Bouton = new System.Windows.Forms.Button();
            this.Fichier = new System.Windows.Forms.Label();
            this.TextBoxFichier = new System.Windows.Forms.TextBox();
            this.TreeView = new System.Windows.Forms.TreeView();
            this.ListView = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // TextBoxRepertoire
            // 
            this.TextBoxRepertoire.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TextBoxRepertoire.Location = new System.Drawing.Point(35, 57);
            this.TextBoxRepertoire.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextBoxRepertoire.Name = "TextBoxRepertoire";
            this.TextBoxRepertoire.Size = new System.Drawing.Size(655, 22);
            this.TextBoxRepertoire.TabIndex = 0;
            this.TextBoxRepertoire.Text = "C:\\Users\\EloiRivière\\Documents\\DevOps\\dotNET\\Tp1\\Tp1";
            // 
            // Répertoire
            // 
            this.Répertoire.AutoSize = true;
            this.Répertoire.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.Répertoire.Location = new System.Drawing.Point(31, 26);
            this.Répertoire.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Répertoire.Name = "Répertoire";
            this.Répertoire.Size = new System.Drawing.Size(75, 17);
            this.Répertoire.TabIndex = 1;
            this.Répertoire.Text = "Répertoire";
            // 
            // Bouton
            // 
            this.Bouton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.Bouton.Location = new System.Drawing.Point(1167, 142);
            this.Bouton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Bouton.Name = "Bouton";
            this.Bouton.Size = new System.Drawing.Size(100, 28);
            this.Bouton.TabIndex = 2;
            this.Bouton.Text = "Valider";
            this.Bouton.UseVisualStyleBackColor = true;
            this.Bouton.Click += new System.EventHandler(this.Bouton_Click);
            // 
            // Fichier
            // 
            this.Fichier.AutoSize = true;
            this.Fichier.Location = new System.Drawing.Point(31, 111);
            this.Fichier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Fichier.Name = "Fichier";
            this.Fichier.Size = new System.Drawing.Size(50, 17);
            this.Fichier.TabIndex = 3;
            this.Fichier.Text = "Fichier";
            // 
            // TextBoxFichier
            // 
            this.TextBoxFichier.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TextBoxFichier.Location = new System.Drawing.Point(35, 145);
            this.TextBoxFichier.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TextBoxFichier.Name = "TextBoxFichier";
            this.TextBoxFichier.Size = new System.Drawing.Size(655, 22);
            this.TextBoxFichier.TabIndex = 4;
            this.TextBoxFichier.Text = "C:\\Users\\EloiRivière\\Documents\\DevOps\\dotNET\\Tp1\\Tp1\\sortie.txt";
            // 
            // TreeView
            // 
            this.TreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.TreeView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TreeView.Location = new System.Drawing.Point(35, 192);
            this.TreeView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TreeView.Name = "TreeView";
            this.TreeView.Size = new System.Drawing.Size(1231, 357);
            this.TreeView.TabIndex = 5;
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView_AfterSelect);
            // 
            // ListView
            // 
            this.ListView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.ListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ListView.HideSelection = false;
            this.ListView.Location = new System.Drawing.Point(35, 576);
            this.ListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(1231, 345);
            this.ListView.TabIndex = 6;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.List;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1312, 937);
            this.Controls.Add(this.ListView);
            this.Controls.Add(this.TreeView);
            this.Controls.Add(this.TextBoxFichier);
            this.Controls.Add(this.Fichier);
            this.Controls.Add(this.Bouton);
            this.Controls.Add(this.Répertoire);
            this.Controls.Add(this.TextBoxRepertoire);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "TP1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxRepertoire;
        private System.Windows.Forms.Label Répertoire;
        private System.Windows.Forms.Button Bouton;
        private System.Windows.Forms.Label Fichier;
        private System.Windows.Forms.TextBox TextBoxFichier;
        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.ListView ListView;
    }
}

