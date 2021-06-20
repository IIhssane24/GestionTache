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
    public partial class Statistique : Form
    {
        public Statistique()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        public int idUti;
        string role;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;

        public Statistique(int id )
        {
            InitializeComponent();
            this.CenterToScreen();
            this.idUti = id;
        }
        public void Role()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "  select Rôle.TitreR  from Rôle INNER JOIN Utilisateur ON Utilisateur.id_role=Rôle.id_role where Utilisateur.id_Utilisateur=" + idUti + "; ";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    if (rd[0] != DBNull.Value)
                        role = (string)rd[0];
                }
                cnx.Close();
            }
            else
            {

                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Statistique_Load(object sender, EventArgs e)
        {
            TauxTacheTerminer();
            TauxTacheNonTerminer();
            TauxTacheEnRetard();
            Role();
            if (!(role.Equals("Responsable")))
            {
                chartU();

            }
            else
            {
                chart();
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

        public void TauxTacheTerminer()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            String Query = "select count(*) from journalisation where Terminer=1 and id_Utilisateur_aff="+idUti+";";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    StatistiqueControl s = new StatistiqueControl();
                    s.Taux = (int)rd[0] + " Tache Terminer";
                    flowLayoutPanel1.Controls.Add(s);

                }
                cnx.Close();
            }
        }
        public void TauxTacheNonTerminer()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            String Query = "select count(*) from journalisation where Terminer=0 and id_Utilisateur_aff=" + idUti + ";";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    StatistiqueControl s = new StatistiqueControl();
                    s.Taux = (int)rd[0] + " Tache Non Terminer";
                    flowLayoutPanel1.Controls.Add(s);

                }
                cnx.Close();
            }
        }
        public void TauxTacheEnRetard()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            String Query = "select count(*) from journalisation where Etiquette='En retard' and id_Utilisateur_aff=" + idUti + ";";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    StatistiqueControl s = new StatistiqueControl();
                    s.Taux = (int)rd[0] + " Tache En Retard";
                    flowLayoutPanel1.Controls.Add(s);

                }
                cnx.Close();
            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        public void chart()
        {
            int idC;
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            String Query = "select count(journalisation.Terminer),Utilisateur.Nom,Utilisateur.Prenom,Utilisateur.id_Utilisateur from Utilisateur INNER JOIN journalisation ON Utilisateur.id_Utilisateur = journalisation.id_Utilisateur_aff where journalisation.Terminer = 0 group by Utilisateur.Nom,Utilisateur.Prenom,Utilisateur.id_Utilisateur; ";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    if(rd[1]!=DBNull.Value || rd[2]!=DBNull.Value)
                    {
                        this.chart1.Series["Non Terminer"].Points.AddXY((string)rd[1]+" "+ (string)rd[2], (int)rd[0]);
                        idC = chartTerminer((int)rd[3]);
                        this.chart1.Series["Terminer"].Points.AddXY((string)rd[1] + " " + (string)rd[2], idC);
                    }
                }
                cnx.Close();
            }
        }
        public void chartU()
        {
            int idC;
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            String Query = "select count(journalisation.Terminer),Utilisateur.Nom,Utilisateur.Prenom,Utilisateur.id_Utilisateur from Utilisateur INNER JOIN journalisation ON Utilisateur.id_Utilisateur = journalisation.id_Utilisateur_aff where journalisation.Terminer = 0 and Utilisateur.id_Utilisateur="+idUti+"  group by Utilisateur.Nom,Utilisateur.Prenom,Utilisateur.id_Utilisateur; ";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    if (rd[1] != DBNull.Value || rd[2] != DBNull.Value)
                    {
                        this.chart1.Series["Non Terminer"].Points.AddXY((string)rd[1] + " " + (string)rd[2], (int)rd[0]);
                        idC = chartTerminer((int)rd[3]);
                        this.chart1.Series["Terminer"].Points.AddXY((string)rd[1] + " " + (string)rd[2], idC);
                    }
                }
                cnx.Close();
            }
        }
        public int chartTerminer(int id)
        {
            int t=0;
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            String Query = "select count(journalisation.Terminer) from Utilisateur INNER JOIN journalisation ON Utilisateur.id_Utilisateur = journalisation.id_Utilisateur_aff where journalisation.Terminer = 1 and Utilisateur.id_Utilisateur ="+id+" ";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    t = (int)rd[0];

                }
                cnx.Close();
                return t;
                
            }
           return t;
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
