
namespace GestionTâche
{
    partial class MembresContrôle
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.NomPr = new System.Windows.Forms.Label();
            this.emailMembre = new System.Windows.Forms.Label();
            this.txtRole = new System.Windows.Forms.Label();
            this.menuStripMembre = new System.Windows.Forms.MenuStrip();
            this.taToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.supprimerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.menuStripMembre.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.NomPr);
            this.panel1.Location = new System.Drawing.Point(40, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 22);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // NomPr
            // 
            this.NomPr.AutoSize = true;
            this.NomPr.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NomPr.ForeColor = System.Drawing.Color.White;
            this.NomPr.Location = new System.Drawing.Point(3, 2);
            this.NomPr.Name = "NomPr";
            this.NomPr.Size = new System.Drawing.Size(32, 19);
            this.NomPr.TabIndex = 0;
            this.NomPr.Text = "NP";
            this.NomPr.Click += new System.EventHandler(this.NomPr_Click);
            // 
            // emailMembre
            // 
            this.emailMembre.AutoSize = true;
            this.emailMembre.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailMembre.ForeColor = System.Drawing.Color.Black;
            this.emailMembre.Location = new System.Drawing.Point(3, 50);
            this.emailMembre.Name = "emailMembre";
            this.emailMembre.Size = new System.Drawing.Size(49, 15);
            this.emailMembre.TabIndex = 1;
            this.emailMembre.Text = "E-mail";
            this.emailMembre.Click += new System.EventHandler(this.emailMembre_Click);
            // 
            // txtRole
            // 
            this.txtRole.AutoSize = true;
            this.txtRole.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRole.ForeColor = System.Drawing.Color.Black;
            this.txtRole.Location = new System.Drawing.Point(3, 83);
            this.txtRole.Name = "txtRole";
            this.txtRole.Size = new System.Drawing.Size(37, 15);
            this.txtRole.TabIndex = 2;
            this.txtRole.Text = "Rôle";
            // 
            // menuStripMembre
            // 
            this.menuStripMembre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.menuStripMembre.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.menuStripMembre.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taToolStripMenuItem});
            this.menuStripMembre.Location = new System.Drawing.Point(0, 0);
            this.menuStripMembre.Name = "menuStripMembre";
            this.menuStripMembre.Size = new System.Drawing.Size(249, 24);
            this.menuStripMembre.TabIndex = 3;
            this.menuStripMembre.Text = "menuStrip1";
            // 
            // taToolStripMenuItem
            // 
            this.taToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.taToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.modifierToolStripMenuItem,
            this.supprimerToolStripMenuItem});
            this.taToolStripMenuItem.Image = global::GestionTâche.Properties.Resources.menu;
            this.taToolStripMenuItem.Name = "taToolStripMenuItem";
            this.taToolStripMenuItem.Size = new System.Drawing.Size(28, 20);
            // 
            // modifierToolStripMenuItem
            // 
            this.modifierToolStripMenuItem.Name = "modifierToolStripMenuItem";
            this.modifierToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modifierToolStripMenuItem.Text = "Modifier";
            this.modifierToolStripMenuItem.Click += new System.EventHandler(this.modifierToolStripMenuItem_Click);
            // 
            // supprimerToolStripMenuItem
            // 
            this.supprimerToolStripMenuItem.Name = "supprimerToolStripMenuItem";
            this.supprimerToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.supprimerToolStripMenuItem.Text = "Supprimer";
            this.supprimerToolStripMenuItem.Click += new System.EventHandler(this.supprimerToolStripMenuItem_Click);
            // 
            // MembresContrôle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.txtRole);
            this.Controls.Add(this.emailMembre);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStripMembre);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Name = "MembresContrôle";
            this.Size = new System.Drawing.Size(249, 155);
            this.Load += new System.EventHandler(this.MembresContrôle_Load);
            this.Click += new System.EventHandler(this.MembresContrôle_Click);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStripMembre.ResumeLayout(false);
            this.menuStripMembre.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label NomPr;
        private System.Windows.Forms.Label emailMembre;
        private System.Windows.Forms.Label txtRole;
        public System.Windows.Forms.ToolStripMenuItem taToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem supprimerToolStripMenuItem;
        public System.Windows.Forms.MenuStrip menuStripMembre;
        public System.Windows.Forms.ToolStripMenuItem modifierToolStripMenuItem;
    }
}
