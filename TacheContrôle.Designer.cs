
namespace GestionTâche
{
    partial class TacheContrôle
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

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.IdTach = new System.Windows.Forms.Label();
            this.txtTitre = new System.Windows.Forms.Label();
            this.laAttribué = new System.Windows.Forms.Label();
            this.labelAttr = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.labelCree = new System.Windows.Forms.Label();
            this.btnTerminer = new System.Windows.Forms.Button();
            this.txtProjet = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.txtdate = new System.Windows.Forms.Label();
            this.pictureBook = new System.Windows.Forms.PictureBox();
            this.tacehToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aFaireToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enCoursToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.enRetardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ModifierMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBook)).BeginInit();
            this.SuspendLayout();
            // 
            // IdTach
            // 
            this.IdTach.AutoSize = true;
            this.IdTach.Location = new System.Drawing.Point(153, 17);
            this.IdTach.Name = "IdTach";
            this.IdTach.Size = new System.Drawing.Size(0, 13);
            this.IdTach.TabIndex = 2;
            this.IdTach.Click += new System.EventHandler(this.IdTach_Click);
            // 
            // txtTitre
            // 
            this.txtTitre.AutoSize = true;
            this.txtTitre.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
            this.txtTitre.Location = new System.Drawing.Point(28, 2);
            this.txtTitre.Name = "txtTitre";
            this.txtTitre.Size = new System.Drawing.Size(58, 22);
            this.txtTitre.TabIndex = 3;
            this.txtTitre.Text = "TitreT";
            this.txtTitre.Click += new System.EventHandler(this.txtTitre_Click);
            // 
            // laAttribué
            // 
            this.laAttribué.AutoSize = true;
            this.laAttribué.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laAttribué.Location = new System.Drawing.Point(5, 88);
            this.laAttribué.Name = "laAttribué";
            this.laAttribué.Size = new System.Drawing.Size(72, 18);
            this.laAttribué.TabIndex = 4;
            this.laAttribué.Text = "Attribué à:";
            // 
            // labelAttr
            // 
            this.labelAttr.AutoSize = true;
            this.labelAttr.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAttr.Location = new System.Drawing.Point(75, 88);
            this.labelAttr.Name = "labelAttr";
            this.labelAttr.Size = new System.Drawing.Size(148, 17);
            this.labelAttr.TabIndex = 5;
            this.labelAttr.Text = "email utilisateur_affecter";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Crée par :";
            // 
            // labelCree
            // 
            this.labelCree.AutoSize = true;
            this.labelCree.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCree.Location = new System.Drawing.Point(77, 113);
            this.labelCree.Name = "labelCree";
            this.labelCree.Size = new System.Drawing.Size(126, 17);
            this.labelCree.TabIndex = 7;
            this.labelCree.Text = "email utlisateur_crée";
            // 
            // btnTerminer
            // 
            this.btnTerminer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
            this.btnTerminer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTerminer.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.btnTerminer.ForeColor = System.Drawing.Color.White;
            this.btnTerminer.Location = new System.Drawing.Point(166, 166);
            this.btnTerminer.Name = "btnTerminer";
            this.btnTerminer.Size = new System.Drawing.Size(98, 31);
            this.btnTerminer.TabIndex = 8;
            this.btnTerminer.Text = "Terminer";
            this.btnTerminer.UseVisualStyleBackColor = false;
            this.btnTerminer.Click += new System.EventHandler(this.btnTerminer_Click);
            // 
            // txtProjet
            // 
            this.txtProjet.AutoSize = true;
            this.txtProjet.Font = new System.Drawing.Font("Palatino Linotype", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.txtProjet.Location = new System.Drawing.Point(62, 35);
            this.txtProjet.Name = "txtProjet";
            this.txtProjet.Size = new System.Drawing.Size(0, 21);
            this.txtProjet.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
            this.panel2.Location = new System.Drawing.Point(-10, 199);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(21, 11);
            this.panel2.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.pictureBook);
            this.panel3.Controls.Add(this.txtTitre);
            this.panel3.Controls.Add(this.menuStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(276, 30);
            this.panel3.TabIndex = 12;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.menuStrip1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tacehToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(276, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 142);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Echéance :";
            // 
            // txtdate
            // 
            this.txtdate.AutoSize = true;
            this.txtdate.Font = new System.Drawing.Font("Palatino Linotype", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtdate.ForeColor = System.Drawing.Color.Red;
            this.txtdate.Location = new System.Drawing.Point(77, 143);
            this.txtdate.Name = "txtdate";
            this.txtdate.Size = new System.Drawing.Size(64, 17);
            this.txtdate.TabIndex = 15;
            this.txtdate.Text = "30/05/2021";
            this.txtdate.Click += new System.EventHandler(this.txtdate_Click);
            // 
            // pictureBook
            // 
            this.pictureBook.Image = global::GestionTâche.Properties.Resources.bookmark__2_;
            this.pictureBook.Location = new System.Drawing.Point(3, -1);
            this.pictureBook.Name = "pictureBook";
            this.pictureBook.Size = new System.Drawing.Size(30, 35);
            this.pictureBook.TabIndex = 4;
            this.pictureBook.TabStop = false;
            // 
            // tacehToolStripMenuItem
            // 
            this.tacehToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tacehToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aFaireToolStripMenuItem,
            this.enCoursToolStripMenuItem,
            this.enRetardToolStripMenuItem,
            this.ModifierMenuItem1,
            this.supprimerToolStripMenuItem});
            this.tacehToolStripMenuItem.Image = global::GestionTâche.Properties.Resources.pin;
            this.tacehToolStripMenuItem.Name = "tacehToolStripMenuItem";
            this.tacehToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            this.tacehToolStripMenuItem.Click += new System.EventHandler(this.tacehToolStripMenuItem_Click);
            // 
            // aFaireToolStripMenuItem
            // 
            this.aFaireToolStripMenuItem.Image = global::GestionTâche.Properties.Resources.pin;
            this.aFaireToolStripMenuItem.Name = "aFaireToolStripMenuItem";
            this.aFaireToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.aFaireToolStripMenuItem.Text = "A faire";
            this.aFaireToolStripMenuItem.Click += new System.EventHandler(this.aFaireToolStripMenuItem_Click);
            // 
            // enCoursToolStripMenuItem
            // 
            this.enCoursToolStripMenuItem.Image = global::GestionTâche.Properties.Resources.solutions;
            this.enCoursToolStripMenuItem.Name = "enCoursToolStripMenuItem";
            this.enCoursToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.enCoursToolStripMenuItem.Text = "En cours";
            this.enCoursToolStripMenuItem.Click += new System.EventHandler(this.enCoursToolStripMenuItem_Click);
            // 
            // enRetardToolStripMenuItem
            // 
            this.enRetardToolStripMenuItem.Image = global::GestionTâche.Properties.Resources.timer;
            this.enRetardToolStripMenuItem.Name = "enRetardToolStripMenuItem";
            this.enRetardToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.enRetardToolStripMenuItem.Text = "En retard";
            this.enRetardToolStripMenuItem.Click += new System.EventHandler(this.enRetardToolStripMenuItem_Click);
            // 
            // ModifierMenuItem1
            // 
            this.ModifierMenuItem1.Name = "ModifierMenuItem1";
            this.ModifierMenuItem1.Size = new System.Drawing.Size(129, 22);
            this.ModifierMenuItem1.Text = "Modifier";
            this.ModifierMenuItem1.Click += new System.EventHandler(this.ModifierMenuItem1_Click);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.supprimerToolStripMenuItem.Text = "Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // TacheContrôle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtdate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtProjet);
            this.Controls.Add(this.btnTerminer);
            this.Controls.Add(this.labelCree);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelAttr);
            this.Controls.Add(this.laAttribué);
            this.Controls.Add(this.IdTach);
            this.Name = "TacheContrôle";
            this.Size = new System.Drawing.Size(276, 209);
            this.Load += new System.EventHandler(this.TacheContrôle_Load);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBook)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label IdTach;
        private System.Windows.Forms.Label txtTitre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label labelCree;
        private System.Windows.Forms.Label txtProjet;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.Button btnTerminer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        public System.Windows.Forms.ToolStripMenuItem tacehToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem aFaireToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem enCoursToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem enRetardToolStripMenuItem;
        public System.Windows.Forms.ToolStripMenuItem ModifierMenuItem1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label txtdate;
        public System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        public System.Windows.Forms.Label laAttribué;
        public System.Windows.Forms.Label labelAttr;
        public System.Windows.Forms.PictureBox pictureBook;
    }
}
