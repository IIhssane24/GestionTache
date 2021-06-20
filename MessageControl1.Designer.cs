
namespace GestionTâche
{
    partial class MessageControl1
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
            this.txtTache = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panelmsg = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtDate = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.Label();
            this.titreMessage = new System.Windows.Forms.Label();
            this.btnvu = new System.Windows.Forms.Button();
            this.btnSupprimer = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtTache
            // 
            this.txtTache.AutoSize = true;
            this.txtTache.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTache.ForeColor = System.Drawing.Color.Black;
            this.txtTache.Location = new System.Drawing.Point(37, 70);
            this.txtTache.Name = "txtTache";
            this.txtTache.Size = new System.Drawing.Size(111, 18);
            this.txtTache.TabIndex = 3;
            this.txtTache.Text = "DetaMessage";
            this.txtTache.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.txtTache.Click += new System.EventHandler(this.txtTache_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.richTextBox1.ForeColor = System.Drawing.Color.Black;
            this.richTextBox1.Location = new System.Drawing.Point(54, 70);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(174, 36);
            this.richTextBox1.TabIndex = 9;
            this.richTextBox1.Text = "DetailsMessage";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel2.Controls.Add(this.panelmsg);
            this.panel2.Controls.Add(this.txtTache);
            this.panel2.Controls.Add(this.panel1);
            this.panel2.Controls.Add(this.txtDate);
            this.panel2.Controls.Add(this.txtEmail);
            this.panel2.Controls.Add(this.titreMessage);
            this.panel2.Controls.Add(this.richTextBox1);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(287, 131);
            this.panel2.TabIndex = 10;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panelmsg
            // 
            this.panelmsg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelmsg.Location = new System.Drawing.Point(0, 0);
            this.panelmsg.Name = "panelmsg";
            this.panelmsg.Size = new System.Drawing.Size(10, 142);
            this.panelmsg.TabIndex = 13;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnvu);
            this.panel1.Controls.Add(this.btnSupprimer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 98);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(283, 29);
            this.panel1.TabIndex = 12;
            // 
            // txtDate
            // 
            this.txtDate.AutoSize = true;
            this.txtDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.txtDate.ForeColor = System.Drawing.Color.Black;
            this.txtDate.Location = new System.Drawing.Point(206, 13);
            this.txtDate.Name = "txtDate";
            this.txtDate.Size = new System.Drawing.Size(41, 16);
            this.txtDate.TabIndex = 11;
            this.txtDate.Text = "Date";
            // 
            // txtEmail
            // 
            this.txtEmail.AutoSize = true;
            this.txtEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmail.ForeColor = System.Drawing.Color.Black;
            this.txtEmail.Location = new System.Drawing.Point(16, 0);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(98, 13);
            this.txtEmail.TabIndex = 1;
            this.txtEmail.Text = "email_utilisateur";
            // 
            // titreMessage
            // 
            this.titreMessage.AutoSize = true;
            this.titreMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titreMessage.ForeColor = System.Drawing.Color.Black;
            this.titreMessage.Location = new System.Drawing.Point(74, 38);
            this.titreMessage.Name = "titreMessage";
            this.titreMessage.Size = new System.Drawing.Size(122, 20);
            this.titreMessage.TabIndex = 0;
            this.titreMessage.Text = "Titre Message";
            this.titreMessage.Click += new System.EventHandler(this.titreMessage_Click_1);
            // 
            // btnvu
            // 
            this.btnvu.FlatAppearance.BorderSize = 0;
            this.btnvu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnvu.Image = global::GestionTâche.Properties.Resources.check;
            this.btnvu.Location = new System.Drawing.Point(253, 0);
            this.btnvu.Name = "btnvu";
            this.btnvu.Size = new System.Drawing.Size(35, 31);
            this.btnvu.TabIndex = 6;
            this.btnvu.UseVisualStyleBackColor = true;
            this.btnvu.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSupprimer
            // 
            this.btnSupprimer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSupprimer.FlatAppearance.BorderSize = 0;
            this.btnSupprimer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSupprimer.Image = global::GestionTâche.Properties.Resources.trash_bin;
            this.btnSupprimer.Location = new System.Drawing.Point(223, 1);
            this.btnSupprimer.Name = "btnSupprimer";
            this.btnSupprimer.Size = new System.Drawing.Size(24, 31);
            this.btnSupprimer.TabIndex = 7;
            this.btnSupprimer.UseVisualStyleBackColor = true;
            this.btnSupprimer.Click += new System.EventHandler(this.btnSupprimer_Click);
            // 
            // MessageControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel2);
            this.Name = "MessageControl1";
            this.Size = new System.Drawing.Size(287, 132);
            this.Load += new System.EventHandler(this.MessageControl1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.RichTextBox richTextBox1;
        public System.Windows.Forms.Label txtTache;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label titreMessage;
        private System.Windows.Forms.Label txtDate;
        private System.Windows.Forms.Label txtEmail;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button btnSupprimer;
        public System.Windows.Forms.Button btnvu;
        public System.Windows.Forms.Panel panelmsg;
    }
}
