
namespace GestionTâche
{
    partial class Messages
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.btnEnvoyer = new System.Windows.Forms.Button();
            this.TitreP = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.messagesEnvoyéesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messagesVuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messagesEnvoyéesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.btnminim = new System.Windows.Forms.Button();
            this.btnmaximazed = new System.Windows.Forms.Button();
            this.btnexit = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(762, 29);
            this.panel1.TabIndex = 20;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.btnEnvoyer);
            this.panel2.Controls.Add(this.TitreP);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(762, 545);
            this.panel2.TabIndex = 21;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.menuStrip1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(760, 26);
            this.panel3.TabIndex = 25;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(760, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // btnEnvoyer
            // 
            this.btnEnvoyer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(110)))), ((int)(((byte)(130)))));
            this.btnEnvoyer.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEnvoyer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEnvoyer.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold);
            this.btnEnvoyer.ForeColor = System.Drawing.Color.White;
            this.btnEnvoyer.Location = new System.Drawing.Point(65, 83);
            this.btnEnvoyer.Name = "btnEnvoyer";
            this.btnEnvoyer.Size = new System.Drawing.Size(107, 31);
            this.btnEnvoyer.TabIndex = 24;
            this.btnEnvoyer.Text = "Envoyer";
            this.btnEnvoyer.UseVisualStyleBackColor = false;
            this.btnEnvoyer.Click += new System.EventHandler(this.btnEnvoyer_Click);
            // 
            // TitreP
            // 
            this.TitreP.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TitreP.AutoSize = true;
            this.TitreP.Font = new System.Drawing.Font("Palatino Linotype", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitreP.ForeColor = System.Drawing.Color.Black;
            this.TitreP.Location = new System.Drawing.Point(75, 41);
            this.TitreP.Name = "TitreP";
            this.TitreP.Size = new System.Drawing.Size(143, 39);
            this.TitreP.TabIndex = 15;
            this.TitreP.Text = "Messages";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(65, 120);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(638, 389);
            this.flowLayoutPanel1.TabIndex = 0;
            this.flowLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messagesEnvoyéesToolStripMenuItem,
            this.messagesVuToolStripMenuItem,
            this.messagesEnvoyéesToolStripMenuItem1});
            this.toolStripMenuItem1.Image = global::GestionTâche.Properties.Resources.menu;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripMenuItem1.Size = new System.Drawing.Size(28, 20);
            // 
            // messagesEnvoyéesToolStripMenuItem
            // 
            this.messagesEnvoyéesToolStripMenuItem.Name = "messagesEnvoyéesToolStripMenuItem";
            this.messagesEnvoyéesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.messagesEnvoyéesToolStripMenuItem.Text = "Messages";
            this.messagesEnvoyéesToolStripMenuItem.Click += new System.EventHandler(this.messagesEnvoyéesToolStripMenuItem_Click_1);
            // 
            // messagesVuToolStripMenuItem
            // 
            this.messagesVuToolStripMenuItem.Name = "messagesVuToolStripMenuItem";
            this.messagesVuToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.messagesVuToolStripMenuItem.Text = "Messages vu";
            this.messagesVuToolStripMenuItem.Click += new System.EventHandler(this.messagesVuToolStripMenuItem_Click_1);
            // 
            // messagesEnvoyéesToolStripMenuItem1
            // 
            this.messagesEnvoyéesToolStripMenuItem1.Name = "messagesEnvoyéesToolStripMenuItem1";
            this.messagesEnvoyéesToolStripMenuItem1.Size = new System.Drawing.Size(177, 22);
            this.messagesEnvoyéesToolStripMenuItem1.Text = "Messages envoyées";
            this.messagesEnvoyéesToolStripMenuItem1.Click += new System.EventHandler(this.messagesEnvoyéesToolStripMenuItem1_Click_1);
            // 
            // btnminim
            // 
            this.btnminim.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnminim.FlatAppearance.BorderSize = 0;
            this.btnminim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnminim.ForeColor = System.Drawing.Color.White;
            this.btnminim.Image = global::GestionTâche.Properties.Resources.substract;
            this.btnminim.Location = new System.Drawing.Point(657, 0);
            this.btnminim.Name = "btnminim";
            this.btnminim.Size = new System.Drawing.Size(35, 29);
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
            this.btnmaximazed.Location = new System.Drawing.Point(692, 0);
            this.btnmaximazed.Name = "btnmaximazed";
            this.btnmaximazed.Size = new System.Drawing.Size(35, 29);
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
            this.btnexit.Location = new System.Drawing.Point(727, 0);
            this.btnexit.Name = "btnexit";
            this.btnexit.Size = new System.Drawing.Size(35, 29);
            this.btnexit.TabIndex = 20;
            this.btnexit.UseVisualStyleBackColor = true;
            this.btnexit.Click += new System.EventHandler(this.btnexit_Click);
            // 
            // Messages
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(216)))), ((int)(((byte)(227)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(762, 574);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Messages";
            this.Text = "Messages";
            this.Load += new System.EventHandler(this.Messages_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnminim;
        private System.Windows.Forms.Button btnmaximazed;
        private System.Windows.Forms.Button btnexit;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label TitreP;
        private System.Windows.Forms.Button btnEnvoyer;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem messagesEnvoyéesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messagesVuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messagesEnvoyéesToolStripMenuItem1;
    }
}