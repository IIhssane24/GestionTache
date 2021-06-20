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
    public partial class MesTacheTerminer : Form
    {
        public MesTacheTerminer()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;
        int idUtili;
        public MesTacheTerminer(int id)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.idUtili = id;
        }
        private void linkTerminer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Panel p = this.Parent as Panel;

            if (p != null)
            {

                MesTache myForm = new MesTache(idUtili);

                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                p.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();
                this.Close();

            }
       
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void listTache()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            string titreProjet;
            String Query = "SELECT Tache.id_Tache , Tache.TitreT From Tache INNER JOIN Journalisation ON Tache.id_Tache = journalisation.id_Tache INNER JOIN Utilisateur ON journalisation.id_Utilisateur_Crée=Utilisateur.id_Utilisateur where journalisation.id_Utilisateur_aff = " + idUtili + " and journalisation.Terminer=1; ";

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

            String Query = "select DISTINCT Projet.id_projet, Projet.Titre FROM Projet INNER JOIN Statut ON Projet.id_projet=Statut.id_projet INNER JOIN Tache ON Statut.id_Tache = Tache.id_Tache INNER JOIN journalisation ON Tache.id_Tache = journalisation.id_Tache where Tache.id_Tache =" + idT + " and  journalisation.id_Utilisateur_aff=" + idUtili + ";";
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

        private void MesTacheTerminer_Load(object sender, EventArgs e)
        {
            listTache();
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
    }
}
