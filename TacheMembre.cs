using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Runtime.InteropServices;
using GestionTâche.Properties;
namespace GestionTâche
{
    public partial class TacheMembre : Form
    {
        public TacheMembre()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;

        public int idUti;

        public TacheMembre(int idU)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.idUti = idU;
        }
        private void TacheMembre_Load(object sender, EventArgs e)
        {
            Membre();
            listTache();
        }
        public void Membre()
        {
            
            
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "select Utilisateur.Nom,Utilisateur.Prenom,Utilisateur.Mail,Rôle.TitreR from Utilisateur INNER JOIN Rôle ON Utilisateur.id_role=Rôle.id_role where id_Utilisateur='" + idUti+ "';";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    txtNomPr.Text=(string)(rd[0]+" "+rd[1])+ " (" + (string)rd[3] + ")";
                    txtemail.Text = (string)rd[2];
                  
                }
                cnx.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        public void listTache()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;


            String Query = "select Tache.TitreT,Tache.id_Tache,journalisation.id_Utilisateur_Crée,journalisation.Terminer From Tache  INNER JOIN journalisation ON Tache.id_Tache=journalisation.id_Tache where journalisation.id_Utilisateur_aff="+idUti+";";

            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            flowLayoutPanel1.Controls.Clear();
            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    Tache t = new Tache(idUti);
                    t.TitreT = (string)rd[0];
                    t.TitreP = Titreprojet((int)rd[1]);
                    t.MailCree = MailUtiliCrr((int)rd[2]);
                    t.Terminer = Terminer((bool)rd[3]);
                    flowLayoutPanel1.Controls.Add(t);

                }
                cnx.Close();
            }


        }
        public string Titreprojet(int idtache)
        {
            string titrep = " ";

            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            String Query = "select Titre from Projet INNER JOIN Statut ON Projet.id_projet=Statut.id_projet where Statut.id_Tache="+idtache+";";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    titrep = (string)rd[0];

                }
                cnx.Close();
            }

            return titrep;

        }
        public String MailUtiliCrr(int idMem)
        {


            string mail = " ";

            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            String Query = "select Utilisateur.Mail from Utilisateur where id_Utilisateur=" + idMem + ";";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
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
        public String Terminer(bool t)
        {
            string terminer;
            if (t == false)
            {
                terminer="Non Terminer";
            }else
            {
                terminer = "Terminer";
            }

            return terminer;
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TacheMembre_MouseDown(object sender, MouseEventArgs e)
        {
         
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

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
