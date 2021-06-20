
namespace GestionTâche
{
    partial class TacheProjet
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
            this.TitreP = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBoxStatut = new System.Windows.Forms.ComboBox();
            this.txtDescp = new System.Windows.Forms.Label();
            this.btnexit = new System.Windows.Forms.Button();
            this.btnmaximazed = new System.Windows.Forms.Button();
            this.btnminim = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TitreP
            // 
            this.TitreP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitreP.AutoSize = true;
            this.TitreP.Font = new System.Drawing.Font("Palatino Linotype", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitreP.ForeColor = System.Drawing.Color.Black;
            this.TitreP.Location = new System.Drawing.Point(44, 47);
            this.TitreP.Name = "TitreP";
            this.TitreP.Size = new System.Drawing.Size(177, 39);
            this.TitreP.TabIndex = 14;
            this.TitreP.Text = "Titre_Projet";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(31, 171);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(601, 314);
            this.flowLayoutPanel1.TabIndex = 15;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(660, 544);
            this.panel2.TabIndex = 23;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.comboBoxStatut);
            this.panel3.Controls.Add(this.txtDescp);
            this.panel3.Controls.Add(this.TitreP);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(660, 544);
            this.panel3.TabIndex = 22;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // comboBoxStatut
            // 
            this.comboBoxStatut.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxStatut.FormattingEnabled = true;
            this.comboBoxStatut.Items.AddRange(new object[] {
            "Tout",
            "A faire",
            "En cours",
            "En retard",
            "Terminer"});
            this.comboBoxStatut.Location = new System.Drawing.Point(30, 129);
            this.comboBoxStatut.Name = "comboBoxStatut";
            this.comboBoxStatut.Size = new System.Drawing.Size(152, 30);
            this.comboBoxStatut.TabIndex = 22;
            this.comboBoxStatut.SelectedIndexChanged += new System.EventHandler(this.comboBoxStatut_SelectedIndexChanged);
            // 
            // txtDescp
            // 
            this.txtDescp.AutoSize = true;
            this.txtDescp.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescp.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(19)))), ((int)(((byte)(44)))), ((int)(((byte)(51)))));
            this.txtDescp.Location = new System.Drawing.Point(88, 86);
            this.txtDescp.Name = "txtDescp";
            this.txtDescp.Size = new System.Drawing.Size(133, 22);
            this.txtDescp.TabIndex = 15;
            this.txtDescp.Text = "Description Text";
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
            this.btnexit.Location = new System.Drawing.Point(625, 0);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(35, 28);
            this.btnexit.TabIndex = 20;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // btnmaximazed
            // 
            this.btnmaximazed.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnmaximazed.FlatAppearance.BorderSize = 0;
            this.btnmaximazed.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnmaximazed.ForeColor = System.Drawing.Color.White;
            this.btnmaximazed.Image = global::GestionTâche.Properties.Resources.full_screen;
            this.btnmaximazed.Location = new System.Drawing.Point(590, 0);
            this.btnmaximazed.Name = "btnmaximazed";
            this.btnmaximazed.Size = new System.Drawing.Size(35, 28);
            this.btnmaximazed.TabIndex = 21;
            this.btnmaximazed.UseVisualStyleBackColor = true;
            this.btnmaximazed.Click += new System.EventHandler(this.btnmaximazed_Click);
            // 
            // btnminim
            // 
            this.btnminim.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnminim.FlatAppearance.BorderSize = 0;
            this.btnminim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnminim.ForeColor = System.Drawing.Color.White;
            this.btnminim.Image = global::GestionTâche.Properties.Resources.substract;
            this.btnminim.Location = new System.Drawing.Point(555, 0);
            this.btnminim.Name = "btnminim";
            this.btnminim.Size = new System.Drawing.Size(35, 28);
            this.btnminim.TabIndex = 22;
            this.btnminim.UseVisualStyleBackColor = true;
            this.btnminim.Click += new System.EventHandler(this.btnminim_Click);
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
            this.panel1.Size = new System.Drawing.Size(660, 28);
            this.panel1.TabIndex = 22;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // TacheProjet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(660, 544);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.panel2);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TacheProjet";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TacheProjet";
            this.TransparencyKey = System.Drawing.Color.White;
            this.Load += new System.EventHandler(this.TacheProjet_Load);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label TitreP;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label txtDescp;
        private System.Windows.Forms.ComboBox comboBoxStatut;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Button btnmaximazed;
        private System.Windows.Forms.Button btnminim;
        private System.Windows.Forms.Panel panel1;
    }
}