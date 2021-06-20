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
    public partial class TacheProjetTerminer : Form
    {
        public TacheProjetTerminer()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;

        public int id;//id projet
        public int idUti;//id UtilisateurConn


        public TacheProjetTerminer(int a, int idU)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.id = a;
            this.idUti = idU;
        }
        private void TacheProjetTerminer_Load(object sender, EventArgs e)
        {
            Projet();
            listTache(); 
        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {

            
        }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {
           
        }

        private void labelClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void Projet()
        {
            int idP = id;
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "SELECT * FROM Projet where id_projet='" + idP + "';";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    TitreP.Text = (string)rd[1];
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
            
            String Query = "SELECT Journalisation.id_Tache , Tache.TitreT From Projet INNER JOIN Statut ON Projet.id_projet = Statut.id_projet INNER JOIN Tache ON Statut.id_Tache = Tache.id_Tache INNER JOIN journalisation ON journalisation.id_Tache = Tache.id_Tache where Projet.id_projet = " + id + " and journalisation.Terminer = 1;";

            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            flowLayoutPanel1.Controls.Clear();
            if (rd.HasRows)//m
            {

                while (rd.Read())
                {


                    TacheContrôleTerminer t = new TacheContrôleTerminer(id);
                   // TacheContrôle t = new TacheContrôle(id, idUti);
                    t.ID = (int)rd[0];
                    t.Title = (string)rd[1];
                    flowLayoutPanel1.Controls.Add(t);

                }
                cnx.Close();
            }


        }

        private void linkTerminer_Click(object sender, EventArgs e)
        {

        }

        private void linkTerminer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Panel p = this.Parent as Panel;

            if (p != null)
            {

                TacheProjet myForm = new TacheProjet(id, idUti);

                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                p.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();

                this.Close();
            }

           
           
           
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
    }
}
