
namespace GestionTâche
{
    partial class AjouterTache
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
            this.btnEnregister = new System.Windows.Forms.Button();
            this.dateEch = new System.Windows.Forms.DateTimePicker();
            this.comboBoxMe = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.AttribueA = new System.Windows.Forms.Label();
            this.txtDescT = new System.Windows.Forms.RichTextBox();
            this.DescriptionT = new System.Windows.Forms.Label();
            this.textTitreT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxProjet = new System.Windows.Forms.ComboBox();
            this.DeProjet = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnminim = new System.Windows.Forms.Button();
            this.btnmaximazed = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEnregister
            // 
            this.btnEnregister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
            this.btnEnregister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnregister.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnregister.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.btnEnregister.ForeColor = System.Drawing.Color.White;
            this.btnEnregister.Location = new System.Drawing.Point(307, 440);
            this.btnEnregister.Name = "btnEnregister";
            this.btnEnregister.Size = new System.Drawing.Size(107, 31);
            this.btnEnregister.TabIndex = 23;
            this.btnEnregister.Text = "Ajouter";
            this.btnEnregister.UseVisualStyleBackColor = false;
            this.btnEnregister.Click += new System.EventHandler(this.btnEnregister_Click);
            // 
            // dateEch
            // 
            this.dateEch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateEch.CustomFormat = "yyyy-MM-dd";
            this.dateEch.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.dateEch.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateEch.Location = new System.Drawing.Point(132, 178);
            this.dateEch.MinDate = new System.DateTime(2021, 5, 11, 0, 0, 0, 0);
            this.dateEch.Name = "dateEch";
            this.dateEch.Size = new System.Drawing.Size(213, 33);
            this.dateEch.TabIndex = 22;
            this.dateEch.ValueChanged += new System.EventHandler(this.dateEch_ValueChanged);
            // 
            // comboBoxMe
            // 
            this.comboBoxMe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxMe.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.comboBoxMe.FormattingEnabled = true;
            this.comboBoxMe.Location = new System.Drawing.Point(133, 293);
            this.comboBoxMe.Name = "comboBoxMe";
            this.comboBoxMe.Size = new System.Drawing.Size(212, 34);
            this.comboBoxMe.TabIndex = 21;
            this.comboBoxMe.SelectedIndexChanged += new System.EventHandler(this.comboBoxMe_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(13, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 22);
            this.label5.TabIndex = 20;
            this.label5.Text = "Echéance";
            // 
            // AttribueA
            // 
            this.AttribueA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AttribueA.AutoSize = true;
            this.AttribueA.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.AttribueA.Location = new System.Drawing.Point(13, 299);
            this.AttribueA.Name = "AttribueA";
            this.AttribueA.Size = new System.Drawing.Size(85, 22);
            this.AttribueA.TabIndex = 19;
            this.AttribueA.Text = "Attribué à";
            // 
            // txtDescT
            // 
            this.txtDescT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescT.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtDescT.Location = new System.Drawing.Point(133, 354);
            this.txtDescT.Name = "txtDescT";
            this.txtDescT.Size = new System.Drawing.Size(213, 68);
            this.txtDescT.TabIndex = 18;
            this.txtDescT.Text = "";
            // 
            // DescriptionT
            // 
            this.DescriptionT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescriptionT.AutoSize = true;
            this.DescriptionT.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.DescriptionT.Location = new System.Drawing.Point(11, 354);
            this.DescriptionT.Name = "DescriptionT";
            this.DescriptionT.Size = new System.Drawing.Size(101, 44);
            this.DescriptionT.TabIndex = 17;
            this.DescriptionT.Text = "Description \r\ntâche";
            // 
            // textTitreT
            // 
            this.textTitreT.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textTitreT.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.textTitreT.Location = new System.Drawing.Point(132, 127);
            this.textTitreT.Multiline = true;
            this.textTitreT.Name = "textTitreT";
            this.textTitreT.Size = new System.Drawing.Size(213, 29);
            this.textTitreT.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(11, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 22);
            this.label2.TabIndex = 15;
            this.label2.Text = "Nom du tâche";
            // 
            // comboBoxProjet
            // 
            this.comboBoxProjet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxProjet.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Bold);
            this.comboBoxProjet.FormattingEnabled = true;
            this.comboBoxProjet.Location = new System.Drawing.Point(133, 234);
            this.comboBoxProjet.Name = "comboBoxProjet";
            this.comboBoxProjet.Size = new System.Drawing.Size(212, 34);
            this.comboBoxProjet.TabIndex = 25;
            // 
            // DeProjet
            // 
            this.DeProjet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeProjet.AutoSize = true;
            this.DeProjet.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.DeProjet.Location = new System.Drawing.Point(11, 240);
            this.DeProjet.Name = "DeProjet";
            this.DeProjet.Size = new System.Drawing.Size(80, 22);
            this.DeProjet.TabIndex = 26;
            this.DeProjet.Text = "De projet";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 28);
            this.label1.TabIndex = 38;
            this.label1.Text = "Nouvelle Tâche";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
            this.panel1.Controls.Add(this.btnminim);
            this.panel1.Controls.Add(this.btnmaximazed);
            this.panel1.Controls.Add(this.btnexit);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(427, 28);
            this.panel1.TabIndex = 39;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // btnminim
            // 
            this.btnminim.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnminim.FlatAppearance.BorderSize = 0;
            this.btnminim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnminim.ForeColor = System.Drawing.Color.White;
            this.btnminim.Image = global::GestionTâche.Properties.Resources.substract;
            this.btnminim.Location = new System.Drawing.Point(322, 0);
            this.btnminim.Name = "btnminim";
            this.btnminim.Size = new System.Drawing.Size(35, 28);
            this.btnminim.TabIndex = 22;
            this.btnminim.UseVisualStyleBackColor = true;
            this.btnminim.Click += new System.EventHandler(this.btnminim_Click);
            // 
            // btnmaximazed
            // 
            this.btnmaximazed.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnmaximazed.FlatAppearance.BorderSize = 0;
            this.btnmaximazed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmaximazed.ForeColor = System.Drawing.Color.White;
            this.btnmaximazed.Image = global::GestionTâche.Properties.Resources.full_screen;
            this.btnmaximazed.Location = new System.Drawing.Point(357, 0);
            this.btnmaximazed.Name = "btnmaximazed";
            this.btnmaximazed.Size = new System.Drawing.Size(35, 28);
            this.btnmaximazed.TabIndex = 21;
            this.btnmaximazed.UseVisualStyleBackColor = true;
            this.btnmaximazed.Click += new System.EventHandler(this.btnmaximazed_Click);
            // 
            // btnexit
            // 
            this.btnexit.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnexit.FlatAppearance.BorderSize = 0;
            this.btnexit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnexit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.btnexit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnexit.ForeColor = System.Drawing.Color.White;
            this.btnexit.Image = global::GestionTâche.Properties.Resources.cancel__1_;
            this.btnexit.Location = new System.Drawing.Point(392, 0);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(35, 28);
            this.btnexit.TabIndex = 20;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtDescT);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.DeProjet);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.DescriptionT);
            this.panel2.Controls.Add(this.btnEnregister);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.AttribueA);
            this.panel2.Controls.Add(this.textTitreT);
            this.panel2.Controls.Add(this.comboBoxMe);
            this.panel2.Controls.Add(this.dateEch);
            this.panel2.Controls.Add(this.comboBoxProjet);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(427, 497);
            this.panel2.TabIndex = 40;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // AjouterTache
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(427, 497);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AjouterTache";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AjouterTache_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AjouterTache_MouseDown);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textTitreT;
        private System.Windows.Forms.Label DescriptionT;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label AttribueA;
        private System.Windows.Forms.RichTextBox txtDescT;
        private System.Windows.Forms.ComboBox comboBoxMe;
        private System.Windows.Forms.Button btnEnregister;
        private System.Windows.Forms.Label DeProjet;
        private System.Windows.Forms.ComboBox comboBoxProjet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnminim;
        private System.Windows.Forms.Button btnmaximazed;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Panel panel2;
        public System.Windows.Forms.DateTimePicker dateEch;
    }
}