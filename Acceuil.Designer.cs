
namespace GestionTâche
{
    partial class Acceuil
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.projetsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterProjetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mesTâcheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.terminerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterTâcheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.membresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ajouterMembreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnMessage = new System.Windows.Forms.ToolStripMenuItem();
            this.btnEnvoyer = new System.Windows.Forms.ToolStripMenuItem();
            this.labelUti = new System.Windows.Forms.ToolStripMenuItem();
            this.ProfiletoolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.déconnexionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statistiqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.planningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.BackColor = System.Drawing.Color.White;
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projetsToolStripMenuItem,
            this.mesTâcheToolStripMenuItem,
            this.membresToolStripMenuItem,
            this.btnMessage,
            this.labelUti,
            this.statistiqueToolStripMenuItem,
            this.planningToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(1370, 35);
            this.menuStrip1.Stretch = false;
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // projetsToolStripMenuItem
            // 
            this.projetsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterProjetToolStripMenuItem});
            this.projetsToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.projetsToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.projetsToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.projetsToolStripMenuItem.Name = "projetsToolStripMenuItem";
            this.projetsToolStripMenuItem.Size = new System.Drawing.Size(62, 31);
            this.projetsToolStripMenuItem.Text = "&Projets";
            this.projetsToolStripMenuItem.Click += new System.EventHandler(this.projetsToolStripMenuItem_Click_1);
            // 
            // ajouterProjetToolStripMenuItem
            // 
            this.ajouterProjetToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ajouterProjetToolStripMenuItem.Name = "ajouterProjetToolStripMenuItem";
            this.ajouterProjetToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.ajouterProjetToolStripMenuItem.Text = "Ajouter Projet";
            this.ajouterProjetToolStripMenuItem.Click += new System.EventHandler(this.ajouterProjetToolStripMenuItem_Click);
            // 
            // mesTâcheToolStripMenuItem
            // 
            this.mesTâcheToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.terminerToolStripMenuItem,
            this.ajouterTâcheToolStripMenuItem});
            this.mesTâcheToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mesTâcheToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.mesTâcheToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.mesTâcheToolStripMenuItem.Name = "mesTâcheToolStripMenuItem";
            this.mesTâcheToolStripMenuItem.Size = new System.Drawing.Size(88, 31);
            this.mesTâcheToolStripMenuItem.Text = "&Mes tâches";
            this.mesTâcheToolStripMenuItem.Click += new System.EventHandler(this.mesTâcheToolStripMenuItem_Click);
            // 
            // terminerToolStripMenuItem
            // 
            this.terminerToolStripMenuItem.CheckOnClick = true;
            this.terminerToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.terminerToolStripMenuItem.Name = "terminerToolStripMenuItem";
            this.terminerToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.terminerToolStripMenuItem.Text = "Mes tâches";
            this.terminerToolStripMenuItem.CheckedChanged += new System.EventHandler(this.terminerToolStripMenuItem_CheckedChanged);
            this.terminerToolStripMenuItem.Click += new System.EventHandler(this.terminerToolStripMenuItem_Click);
            // 
            // ajouterTâcheToolStripMenuItem
            // 
            this.ajouterTâcheToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ajouterTâcheToolStripMenuItem.Name = "ajouterTâcheToolStripMenuItem";
            this.ajouterTâcheToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.ajouterTâcheToolStripMenuItem.Text = "Ajouter Tâche";
            this.ajouterTâcheToolStripMenuItem.Click += new System.EventHandler(this.ajouterTâcheToolStripMenuItem_Click);
            // 
            // membresToolStripMenuItem
            // 
            this.membresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ajouterMembreToolStripMenuItem});
            this.membresToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.membresToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.membresToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.membresToolStripMenuItem.Name = "membresToolStripMenuItem";
            this.membresToolStripMenuItem.Size = new System.Drawing.Size(77, 31);
            this.membresToolStripMenuItem.Text = "&Membres";
            this.membresToolStripMenuItem.Click += new System.EventHandler(this.membresToolStripMenuItem_Click);
            // 
            // ajouterMembreToolStripMenuItem
            // 
            this.ajouterMembreToolStripMenuItem.Name = "ajouterMembreToolStripMenuItem";
            this.ajouterMembreToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.ajouterMembreToolStripMenuItem.Text = "Ajouter membre";
            this.ajouterMembreToolStripMenuItem.Click += new System.EventHandler(this.ajouterMembreToolStripMenuItem_Click);
            // 
            // btnMessage
            // 
            this.btnMessage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnMessage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnEnvoyer});
            this.btnMessage.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnMessage.ForeColor = System.Drawing.Color.Black;
            this.btnMessage.Image = global::GestionTâche.Properties.Resources.notifi;
            this.btnMessage.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.btnMessage.Name = "btnMessage";
            this.btnMessage.Size = new System.Drawing.Size(104, 31);
            this.btnMessage.Text = "&Messagerie";
            this.btnMessage.Click += new System.EventHandler(this.statistiqueToolStripMenuItem_Click);
            // 
            // btnEnvoyer
            // 
            this.btnEnvoyer.Name = "btnEnvoyer";
            this.btnEnvoyer.Size = new System.Drawing.Size(182, 22);
            this.btnEnvoyer.Text = "Envoyer Message";
            this.btnEnvoyer.Click += new System.EventHandler(this.btnEnvoyer_Click);
            // 
            // labelUti
            // 
            this.labelUti.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.labelUti.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ProfiletoolStripMenuItem1,
            this.déconnexionsToolStripMenuItem});
            this.labelUti.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.labelUti.Image = global::GestionTâche.Properties.Resources.membre;
            this.labelUti.Margin = new System.Windows.Forms.Padding(800, 0, 0, 0);
            this.labelUti.Name = "labelUti";
            this.labelUti.Size = new System.Drawing.Size(158, 31);
            this.labelUti.Text = "&toolStripMenuItem2";
            this.labelUti.Click += new System.EventHandler(this.labelUti_Click);
            // 
            // ProfiletoolStripMenuItem1
            // 
            this.ProfiletoolStripMenuItem1.Name = "ProfiletoolStripMenuItem1";
            this.ProfiletoolStripMenuItem1.Size = new System.Drawing.Size(155, 22);
            this.ProfiletoolStripMenuItem1.Text = "Profile";
            this.ProfiletoolStripMenuItem1.Click += new System.EventHandler(this.ProfiletoolStripMenuItem1_Click);
            // 
            // déconnexionsToolStripMenuItem
            // 
            this.déconnexionsToolStripMenuItem.Image = global::GestionTâche.Properties.Resources.logout1;
            this.déconnexionsToolStripMenuItem.Name = "déconnexionsToolStripMenuItem";
            this.déconnexionsToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.déconnexionsToolStripMenuItem.Text = "Déconnexion";
            this.déconnexionsToolStripMenuItem.Click += new System.EventHandler(this.déconnexionsToolStripMenuItem_Click);
            // 
            // statistiqueToolStripMenuItem
            // 
            this.statistiqueToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.statistiqueToolStripMenuItem.Name = "statistiqueToolStripMenuItem";
            this.statistiqueToolStripMenuItem.Size = new System.Drawing.Size(84, 31);
            this.statistiqueToolStripMenuItem.Text = "Statistique";
            this.statistiqueToolStripMenuItem.Click += new System.EventHandler(this.statistiqueToolStripMenuItem_Click_1);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::GestionTâche.Properties.Resources.Blue_and_White_Simple_Start_up_Business_Animated_Presentation__1_1;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1370, 714);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // planningToolStripMenuItem
            // 
            this.planningToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.planningToolStripMenuItem.Name = "planningToolStripMenuItem";
            this.planningToolStripMenuItem.Size = new System.Drawing.Size(77, 31);
            this.planningToolStripMenuItem.Text = "Planning ";
            this.planningToolStripMenuItem.Click += new System.EventHandler(this.planningToolStripMenuItem_Click);
            // 
            // Acceuil
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1370, 749);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Acceuil";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "     ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Acceuil_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem projetsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mesTâcheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem terminerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem membresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnMessage;
        private System.Windows.Forms.ToolStripMenuItem ajouterProjetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ajouterTâcheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem labelUti;
        private System.Windows.Forms.ToolStripMenuItem déconnexionsToolStripMenuItem;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem ajouterMembreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem btnEnvoyer;
        private System.Windows.Forms.ToolStripMenuItem statistiqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ProfiletoolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem planningToolStripMenuItem;
    }
}