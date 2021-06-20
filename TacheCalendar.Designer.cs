
namespace GestionTâche
{
    partial class TacheCalendar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtMembre = new System.Windows.Forms.Label();
            this.TxtTache = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDate = new System.Windows.Forms.Label();
            this.txtStatut = new System.Windows.Forms.Label();
            this.labelProjet = new System.Windows.Forms.Label();
            this.txtProjet = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtMembre
            // 
            this.txtMembre.AutoSize = true;
            this.txtMembre.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMembre.Location = new System.Drawing.Point(107, 76);
            this.txtMembre.Name = "txtMembre";
            this.txtMembre.Size = new System.Drawing.Size(61, 19);
            this.txtMembre.TabIndex = 1;
            this.txtMembre.Text = "Membre";
            // 
            // TxtTache
            // 
            this.TxtTache.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtTache.AutoSize = true;
            this.TxtTache.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtTache.Location = new System.Drawing.Point(24, 19);
            this.TxtTache.Name = "TxtTache";
            this.TxtTache.Size = new System.Drawing.Size(144, 28);
            this.TxtTache.TabIndex = 40;
            this.TxtTache.Text = "Détails Tache";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 19);
            this.label2.TabIndex = 41;
            this.label2.Text = "Attribué a : ";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 19);
            this.label3.TabIndex = 42;
            this.label3.Text = "Date Creation : ";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 150);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 19);
            this.label4.TabIndex = 43;
            this.label4.Text = "Statut : ";
            // 
            // txtDate
            // 
            this.txtDate.AutoSize = true;
            this.txtDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDate.Location = new System.Drawing.Point(135, 111);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(94, 19);
            this.txtDate.TabIndex = 44;
            this.txtDate.Text = "Date_creation";
            // 
            // txtStatut
            // 
            this.txtStatut.AutoSize = true;
            this.txtStatut.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtStatut.Location = new System.Drawing.Point(85, 150);
            this.txtStatut.Name = "txtStatut";
            this.txtStatut.Size = new System.Drawing.Size(44, 19);
            this.txtStatut.TabIndex = 45;
            this.txtStatut.Text = "Statut";
            // 
            // labelProjet
            // 
            this.labelProjet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelProjet.AutoSize = true;
            this.labelProjet.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelProjet.Location = new System.Drawing.Point(12, 187);
            this.labelProjet.Name = "labelProjet";
            this.labelProjet.Size = new System.Drawing.Size(62, 19);
            this.labelProjet.TabIndex = 46;
            this.labelProjet.Text = "Projet : ";
            this.labelProjet.Visible = false;
            // 
            // txtProjet
            // 
            this.txtProjet.AutoSize = true;
            this.txtProjet.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProjet.Location = new System.Drawing.Point(85, 187);
            this.txtProjet.Name = "txtProjet";
            this.txtProjet.Size = new System.Drawing.Size(63, 19);
            this.txtProjet.TabIndex = 47;
            this.txtProjet.Text = "Deprojet";
            // 
            // TacheCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(339, 242);
            this.Controls.Add(this.txtProjet);
            this.Controls.Add(this.labelProjet);
            this.Controls.Add(this.txtStatut);
            this.Controls.Add(this.txtDate);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtTache);
            this.Controls.Add(this.txtMembre);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "TacheCalendar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TacheCalendar";
            this.Load += new System.EventHandler(this.TacheCalendar_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public System.Windows.Forms.Label txtMembre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label txtDate;
        public System.Windows.Forms.Label txtStatut;
        public System.Windows.Forms.Label TxtTache;
        public System.Windows.Forms.Label labelProjet;
        public System.Windows.Forms.Label txtProjet;
    }
}