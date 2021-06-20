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
    public partial class Projet : Form
    {
       
        
        public Projet()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
            private extern static void ReleaseCapture();
            [DllImport("user32.DLL", EntryPoint = "SendMessage")]
            private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;
        public int user;
        string role;
        private void Projet_Load(object sender, EventArgs e)
        {
            Role();
            listProject();
           


        }
          public Projet(int id )
           {
              InitializeComponent();

            this.CenterToScreen();
            this.user = id;
          }
      


        private void btnAjouterP_Click(object sender, EventArgs e)
        {
            Panel p = this.Parent as Panel;

            if (p != null)
            {

                AjouterProjet myForm = new AjouterProjet();

                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                p.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();
                
            }
        }

        private void listProject()
        {
            
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "SELECT * FROM Projet ;";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            
            if (rd.HasRows)
            {
                
                while (rd.Read())
                {
                    

                    ListProjet a = new ListProjet(user);
                    a.ID = (int)rd[0];
                    a.Title = (string)rd[1];
                    if (!(role.Equals("Responsable")))
                    {
                        a.lToolStripMenuItem.Visible = false;
                    }






                    flowLayoutPanel1.Controls.Add(a);
                }
               
            }
            cnx.Close();
        }

      

        private void pictureSearch_Click(object sender, EventArgs e)
        {
            

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        public void Role()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "  select Rôle.TitreR  from Rôle INNER JOIN Utilisateur ON Utilisateur.id_role=Rôle.id_role where Utilisateur.id_Utilisateur=" +user+ "; ";
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
        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            string search = txtSearch.Text;
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "SELECT * FROM Projet WHERE CONCAT(id_projet, Titre,DescriptionP) LIKE '%" + search + "%';";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    
                    ListProjet listP = new ListProjet(user);
                    listP.ID = (int)rd[0];
                    listP.Title = (string)rd[1];
                    if (!(role.Equals("Responsable")))
                    {
                        listP.lToolStripMenuItem.Visible = false;
                    }






                    flowLayoutPanel1.Controls.Add(listP);
                }
                cnx.Close();
            }
            else
            {
                MsgBox m = new MsgBox();
                m.txtmsg.Text = "Aucune Projet avec cette information";
                m.picturemsg.Image = Resources.comp_3;
                m.Show();
                m.timer_display.Stop();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
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
    }
}

        
  
          

            
            
        
        