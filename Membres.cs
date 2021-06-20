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
    public partial class Membres : Form
    {
        public Membres()
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

        public Membres(int idU)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.idUti = idU;
        }
        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void listMembres()
        {
             string N,P,a;
          
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "select Utilisateur.id_Utilisateur,Utilisateur.Nom,Utilisateur.Prenom,Utilisateur.Mail,Rôle.TitreR from Utilisateur INNER JOIN Rôle ON Utilisateur.id_role=Rôle.id_role where id_Utilisateur!=" + idUti+" ;";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    MembresContrôle m = new MembresContrôle(idUti,(int)rd[0]);
                    if (rd[1]!=DBNull.Value||rd[2]!=DBNull.Value)
                    {
                        
                        N =(string)rd[1];
                        N = N.Substring(0, 1);
                        P = (string)rd[2];
                        P = P.Substring(0, 1);
                        a = N + P;
                        a = a.ToUpper();
                        m.NomPrenom = rd[1] + " " + rd[2];
                    }
                    else
                    {
                        m.NomPrenom = " ";
                    }
                    //  m.NomPrenom = (string)rd[1];
                   
                    m.Email = (string)rd[3];
                    m.Role = (string)rd[4];
                        





                    flowLayoutPanel1.Controls.Add(m);
                }

            }
            else
            {
               
            }
            cnx.Close();
        }

        private void Membres_Load(object sender, EventArgs e)
        {
            listMembres();
          
        }

        private void btnAjouterP_Click(object sender, EventArgs e)
        {
            Panel p = this.Parent as Panel;
            
            if (p != null)
            {

                AjouterMembre myForm = new AjouterMembre(idUti);

                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                p.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
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

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnminim_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string N, P, a;
            flowLayoutPanel1.Controls.Clear();
            string search = txtSearch.Text;
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "select Utilisateur.id_Utilisateur,Utilisateur.Nom,Utilisateur.Prenom,Utilisateur.Mail,Rôle.TitreR from Utilisateur INNER JOIN Rôle ON Utilisateur.id_role=Rôle.id_role where id_Utilisateur!=" + idUti + " and CONCAT(Utilisateur.Nom, Utilisateur.Prenom,Utilisateur.Mail,Rôle.TitreR) LIKE '%" + search + "%' ;";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    MembresContrôle m = new MembresContrôle(idUti,(int)rd[0]);
                    if (rd[1] != DBNull.Value || rd[2] != DBNull.Value)
                    {

                        N = (string)rd[1];
                        N = N.Substring(0, 1);
                        P = (string)rd[2];
                        P = P.Substring(0, 1);
                        a = N + P;
                        a = a.ToUpper();
                        m.NomPrenom = rd[1] + " " + rd[2];
                    }
                    else
                    {
                        m.NomPrenom = " ";
                    }
                    //  m.NomPrenom = (string)rd[1];

                    m.Email = (string)rd[3];
                    m.Role = (string)rd[4];






                    flowLayoutPanel1.Controls.Add(m);
                }

            }
            else
            {
                MsgBox m = new MsgBox();
                m.txtmsg.Text = "Aucun utilisateur avec ces information";
                m.picturemsg.Image = Resources.comp_3;
                m.Show();
                m.timer_display.Stop();

            }
            cnx.Close();

        }
    }
}
