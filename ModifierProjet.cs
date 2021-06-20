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
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace GestionTâche
{
    public partial class ModifierProjet : Form
    {
        public ModifierProjet()
        {
            InitializeComponent();
        }
        public int idProjet;
        public int IDU;
        public const string motif = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;

        public ModifierProjet(int idP,int idUticon)
        {
            InitializeComponent();
            this.idProjet = idP;
            this.IDU = idUticon;
        }
        public bool VerfierNom(string nom)
        {
            Regex check = new Regex(@"^([A-Z][a-z-A-z]+)$");
            bool valid = false;
            valid = check.IsMatch(nom);

            return valid;

        }
        public Boolean checkInput()
        {
            string Titre = textTitreP.Text;


            if (Titre.Trim().Equals(string.Empty))
            {
                return true;

            }
            else
            {
                return false;
            }

        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
        private void inforProjet()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "select * from Projet where id_projet="+idProjet+";";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                while (rd.Read())
                {

                    textTitreP.Text = (string)rd[1];
                    txtDescP.Text = (string)rd[2];
                }
               
            }
            cnx.Close();
        }
        private void btnTerminer_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                string titre = textTitreP.Text;
                string Descr = txtDescP.Text;
                string[] NomNonValide = { "LOLO", "ZOZO", "TOTO", "KIKI", "HELLO WORLD", "MIMI", "KIKI" };
                string Date = DateTime.Now.ToString("yyyy-MM-dd");
                String Query = "Update Projet set Titre='" + titre + "' ,Descriptionp='" + Descr + "' where id_projet="+idProjet+";";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                if (cnx.State == ConnectionState.Open)
                    cnx.Close();
                cnx.Open();
                if (!checkInput())
                {
                    
                   if (cmd.ExecuteNonQuery() == 1)
                    {
                        MsgBox m = new MsgBox();
                        m.txtmsg.Text = "Projet Modifier";
                        m.Show();
                        m.buttonOk.Hide();
                        m.timer();

                        this.Hide();
                        
                        Form fc = Application.OpenForms["Projet"];

                        if (fc != null)
                            fc.Close();
                        Panel p = this.Parent as Panel;
                        if (p != null)
                        {
                            fc = new Projet(IDU);

                            fc.TopLevel = false;
                            fc.AutoScroll = true;
                            p.Controls.Add(fc);
                            fc.Show();
                            fc.BringToFront();


                        }

                    }

                    
                    

                }
                else
                {
                    MsgBox m = new MsgBox();
                    m.txtmsg.Text = "Veuillez insérer les information important du Projet";
                    m.picturemsg.Image = Resources.comp_3;
                    m.Show();
                    m.timer_display.Stop();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textTitreP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDescP_TextChanged(object sender, EventArgs e)
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

        private void ModifierProjet_Load(object sender, EventArgs e)
        {
            inforProjet();
        }
    }
}
