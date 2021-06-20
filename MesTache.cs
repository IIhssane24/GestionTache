using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using GestionTâche.Properties;
namespace GestionTâche
{
    public partial class MesTache : Form
    {
        public MesTache()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;

        int idUtili;//id utilisateur connecter
        
        private void linkTerminer_Click(object sender, EventArgs e)
        {
            Panel p = this.Parent as Panel;

            if (p != null)
            {

                MesTacheTerminer myForm = new MesTacheTerminer(idUtili);

                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                p.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();
                this.Close();
            }
            
        }
        public MesTache(int id)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.idUtili = id;
        }


        private void MesTache_Load(object sender, EventArgs e)
        {
            comboBoxStatut.SelectedIndex = 0;
            listTache();
        }
        public String MailUtiliConn()
        {


            string mail = " ";

            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            String Query = "select Utilisateur.Mail from Utilisateur where id_Utilisateur=" +idUtili + ";";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();//
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    mail = (string)rd[0];

                }
                cnx.Close();
            }

            return mail;
        }
        public void listTache()
        {
            
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            string titreProjet;
            string etq;
            DateTime date_1 = new DateTime();
            String Query = "SELECT Tache.id_Tache , Tache.TitreT, Utilisateur.Mail,journalisation.Etiquette,Tache.Echéance From Tache INNER JOIN Journalisation ON Tache.id_Tache = journalisation.id_Tache INNER JOIN Utilisateur ON journalisation.id_Utilisateur_Crée=Utilisateur.id_Utilisateur where journalisation.id_Utilisateur_aff = " + idUtili + " and journalisation.Terminer=0 ORDER BY Tache.Echéance ; ";
            DateTime da;
            string jour, mois;
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            flowLayoutPanel1.Controls.Clear();
            
            if (rd.HasRows)
            {

                while (rd.Read())
                {

                     

                    TacheContrôle t = new TacheContrôle();
                    t.ID = (int)rd[0];
                    titreProjet = TitreProjet((int)rd[0]);
                    t.Title = (string)rd[1];
                    t.CreePar = (string)rd[2];
                    t.AttribuéA = MailUtiliConn();
                    t.laAttribué.Hide();
                    t.labelAttr.Hide();
                     t.TitreProjet = titreProjet;
                    etq = (string)rd[3];
                   string mail = (string)rd[2];
                    if (!(mail.Equals(MailUtiliConn())))
                    {
                        t.supprimerToolStripMenuItem.Visible = false;
                        t.ModifierMenuItem1.Visible = false;
                    }
                    if (etq.Equals("A faire"))
                    {
                        t.tacehToolStripMenuItem.Image = Resources.pin;

                    }else if (etq.Equals("En cours"))
                    {
                        t.tacehToolStripMenuItem.Image = Resources.solutions;
                    }
                    else
                    {
                        t.tacehToolStripMenuItem.Image = Resources.timer;
                    }
                    if (rd[4] != DBNull.Value)
                    {
                        da = (DateTime)rd[4];
                        mois = da.ToString("MMM");
                        jour = da.ToString("dd");
                        date_1 = da;
                        DateTime date_3 = DateTime.Now;
                        t.Date = jour + " " + mois + "( " + (date_1 - date_3).Days + " Jour)";
                        if ((date_1 - date_3).Days < 0)
                        {
                            t.pictureBook.Image = Resources.bookma;
                            t.EnRetard();
                        }
                       
                    }
                   
                    flowLayoutPanel1.Controls.Add(t);

                }
                cnx.Close();
            }


        }
        public void listTacheAfaire()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            string titreProjet;
            string etq;
            DateTime date_1 = new DateTime();
            String Query = "SELECT Tache.id_Tache , Tache.TitreT, Utilisateur.Mail,journalisation.Etiquette,Tache.Echéance From Tache INNER JOIN Journalisation ON Tache.id_Tache = journalisation.id_Tache INNER JOIN Utilisateur ON journalisation.id_Utilisateur_Crée=Utilisateur.id_Utilisateur where journalisation.id_Utilisateur_aff = " + idUtili + " and journalisation.Terminer=0 and journalisation.Etiquette='A faire' ; ";
            DateTime da;
            string jour, mois;
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            flowLayoutPanel1.Controls.Clear();
            if (rd.HasRows)
            {

                while (rd.Read())
                {



                    TacheContrôle t = new TacheContrôle();
                    t.ID = (int)rd[0];
                    titreProjet = TitreProjet((int)rd[0]);
                    t.Title = (string)rd[1];
                    t.CreePar = (string)rd[2];
                    t.AttribuéA = MailUtiliConn();
                    t.laAttribué.Hide();
                    t.labelAttr.Hide();
                    t.TitreProjet = titreProjet;
                    etq = (string)rd[3];
                    string mail = (string)rd[2];
                    if (!(mail.Equals(MailUtiliConn())))
                    {
                        t.supprimerToolStripMenuItem.Visible = false;
                    }
                    if (etq.Equals("A faire"))
                    {
                        t.tacehToolStripMenuItem.Image = Resources.pin;

                    }
                    else if (etq.Equals("En cours"))
                    {
                        t.tacehToolStripMenuItem.Image = Resources.solutions;
                    }
                    else
                    {
                        t.tacehToolStripMenuItem.Image = Resources.timer;
                    }
                    da = (DateTime)rd[4];
                    mois = da.ToString("MMM");
                    jour = da.ToString("dd");
                    date_1 = da;
                    DateTime date_3 = DateTime.Now;
                    t.Date = jour + " " + mois + "( " + (date_1 - date_3).Days + " Jour)";
                    if ((date_1 - date_3).Days < 0)
                    {
                        t.pictureBook.Image = Resources.bookma;

                    }
                    t.ModifierMenuItem1.Visible = false;

                    flowLayoutPanel1.Controls.Add(t);

                }
                cnx.Close();
            }


        }
        public void listTacheEnCours()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            string titreProjet;
            string etq;
            DateTime date_1 = new DateTime();
            String Query = "SELECT Tache.id_Tache , Tache.TitreT, Utilisateur.Mail,journalisation.Etiquette,Tache.Echéance From Tache INNER JOIN Journalisation ON Tache.id_Tache = journalisation.id_Tache INNER JOIN Utilisateur ON journalisation.id_Utilisateur_Crée=Utilisateur.id_Utilisateur where journalisation.id_Utilisateur_aff = " + idUtili + " and journalisation.Terminer=0 and journalisation.Etiquette='En cours' ; ";
            DateTime da;
            string jour, mois;
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            flowLayoutPanel1.Controls.Clear();
            if (rd.HasRows)
            {

                while (rd.Read())
                {



                    TacheContrôle t = new TacheContrôle();
                    t.ID = (int)rd[0];
                    titreProjet = TitreProjet((int)rd[0]);
                    t.Title = (string)rd[1];
                    t.CreePar = (string)rd[2];
                    t.AttribuéA = MailUtiliConn();
                    t.laAttribué.Hide();
                    t.labelAttr.Hide();
                    t.TitreProjet = titreProjet;
                    etq = (string)rd[3];
                    string mail = (string)rd[2];
                    if (!(mail.Equals(MailUtiliConn())))
                    {
                        t.supprimerToolStripMenuItem.Visible = false;
                    }
                    if (etq.Equals("A faire"))
                    {
                        t.tacehToolStripMenuItem.Image = Resources.pin;

                    }
                    else if (etq.Equals("En cours"))
                    {
                        t.tacehToolStripMenuItem.Image = Resources.solutions;
                    }
                    else
                    {
                        t.tacehToolStripMenuItem.Image = Resources.timer;
                    }
                    da = (DateTime)rd[4];
                    mois = da.ToString("MMM");
                    jour = da.ToString("dd");
                    date_1 = da;
                    DateTime date_3 = DateTime.Now;
                    t.Date = jour + " " + mois + "( " + (date_1 - date_3).Days + " Jour)";
                    if ((date_1 - date_3).Days < 0)
                    {
                        t.pictureBook.Image = Resources.bookma;

                    }
                    t.ModifierMenuItem1.Visible = false;

                    flowLayoutPanel1.Controls.Add(t);

                }
                cnx.Close();
            }


        }
        public void listTacheEnretard()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            string titreProjet;
            string etq;
            DateTime date_1 = new DateTime();
            String Query = "SELECT Tache.id_Tache , Tache.TitreT, Utilisateur.Mail,journalisation.Etiquette,Tache.Echéance From Tache INNER JOIN Journalisation ON Tache.id_Tache = journalisation.id_Tache INNER JOIN Utilisateur ON journalisation.id_Utilisateur_Crée=Utilisateur.id_Utilisateur where journalisation.id_Utilisateur_aff = " + idUtili + " and journalisation.Terminer=0 and journalisation.Etiquette='En retard' ; ";
            DateTime da;
            string jour, mois;
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            flowLayoutPanel1.Controls.Clear();
            if (rd.HasRows)
            {

                while (rd.Read())
                {



                    TacheContrôle t = new TacheContrôle();
                    t.ID = (int)rd[0];
                    titreProjet = TitreProjet((int)rd[0]);
                    t.Title = (string)rd[1];
                    t.CreePar = (string)rd[2];
                    t.AttribuéA = MailUtiliConn();
                    t.laAttribué.Hide();
                    t.labelAttr.Hide();
                    t.TitreProjet = titreProjet;
                    etq = (string)rd[3];
                    string mail = (string)rd[2];
                    if (!(mail.Equals(MailUtiliConn())))
                    {
                        t.supprimerToolStripMenuItem.Visible = false;
                    }
                    if (etq.Equals("A faire"))
                    {
                        t.tacehToolStripMenuItem.Image = Resources.pin;

                    }
                    else if (etq.Equals("En cours"))
                    {
                        t.tacehToolStripMenuItem.Image = Resources.solutions;
                    }
                    else
                    {
                        t.tacehToolStripMenuItem.Image = Resources.timer;
                    }
                    da = (DateTime)rd[4];
                    mois = da.ToString("MMM");
                    jour = da.ToString("dd");
                    date_1 = da;
                    DateTime date_3 = DateTime.Now;
                    t.Date = jour + " " + mois + "( " + (date_1 - date_3).Days + " Jour)";
                    if ((date_1 - date_3).Days < 0)
                    {
                        t.pictureBook.Image = Resources.bookma;

                    }
                    t.ModifierMenuItem1.Visible = false;

                    flowLayoutPanel1.Controls.Add(t);

                }
                cnx.Close();
            }


        }
        public void listTacheTerminer()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            string titreProjet;
            String Query = "SELECT Tache.id_Tache , Tache.TitreT, Utilisateur.Mail,journalisation.Etiquette,Tache.Echéance From Tache INNER JOIN Journalisation ON Tache.id_Tache = journalisation.id_Tache INNER JOIN Utilisateur ON journalisation.id_Utilisateur_Crée=Utilisateur.id_Utilisateur where journalisation.id_Utilisateur_aff = " + idUtili + " and journalisation.Terminer=1 ; ";
          
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            flowLayoutPanel1.Controls.Clear();
            if (rd.HasRows)
            {

                while (rd.Read())
                {

                    TacheContrôleTerminer t = new TacheContrôleTerminer();
                    t.ID = (int)rd[0];
                    titreProjet = TitreProjet((int)rd[0]);
                    t.Title = (string)rd[1];


                    flowLayoutPanel1.Controls.Add(t);

                }
                cnx.Close();
            }


        }
        public String TitreProjet(int idT)
        {


            string titreP = " ";

            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            String Query = "select DISTINCT Projet.id_projet, Projet.Titre FROM Projet INNER JOIN Statut ON Projet.id_projet=Statut.id_projet INNER JOIN Tache ON Statut.id_Tache = Tache.id_Tache INNER JOIN journalisation ON Tache.id_Tache = journalisation.id_Tache where Tache.id_Tache =" + idT + " and  journalisation.id_Utilisateur_aff="+idUtili+";";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    titreP = (string)rd[1];

                }
                cnx.Close();
            }

            return titreP;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void linkTerminer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnmaximazed_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
                btnmaximazed.Image = Resources.size;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                btnmaximazed.Image = Resources.full_screen;
            }
        }

        private void btnminim_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxStatut_SelectedIndexChanged(object sender, EventArgs e)
        {
            string statut = comboBoxStatut.Text;
            if (statut.Equals("A faire"))
            {
                flowLayoutPanel1.Controls.Clear();
                listTacheAfaire();
            }
            else if (statut.Equals("En cours"))
            {
                flowLayoutPanel1.Controls.Clear();
                listTacheEnCours();
            }
            else if (statut.Equals("En retard"))
            {
                flowLayoutPanel1.Controls.Clear();
               listTacheEnretard();
            }
            else if (statut.Equals("Terminer"))
            {
                flowLayoutPanel1.Controls.Clear();
                listTacheTerminer();

            }
            else
            {
                flowLayoutPanel1.Controls.Clear();
                listTache();

            }
        }
    }
}
