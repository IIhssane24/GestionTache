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
    public partial class AjouterProjet : Form
    {
        public AjouterProjet()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        public int idUti;
        public AjouterProjet(int id)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.idUti = id;
        }
        public const string motif = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;

        public bool VerfierNom(string nom)
        {
            Regex check = new Regex(@"^([A-Z][a-z-A-z]+)$");
            bool valid = false;
            valid = check.IsMatch(nom);

            return valid;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                string titre = textTitreP.Text;
                string Descr = txtDescP.Text;
                string[] NomNonValide = { "LOLO","ZOZO","HAHAHa","ggggg","AAAAA","BBBBB", "CCcCC", "DDDDD", "FFFFF", "GGGGG", "EEEEE", "HHHHH", "JJJJJ", "KKKKK", "LLLLL", "MMMMM", "ZZZZZ", "TOTO", "KIKI", "HELLO WORLD", "MIMI", "KIKI" };
                string Date = DateTime.Now.ToString("yyyy-MM-dd");
                String Query = "insert into Projet(Titre,Descriptionp) VALUES ('" + titre + "','" + Descr + "')SELECT @@IDENTITY AS 'Identity';";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                if (cnx.State == ConnectionState.Open)
                    cnx.Close();
                cnx.Open();
                if (!checkInput())
                {
                    if (titre.Length<5||NomNonValide.Contains(titre))
                    {

                        MsgBox m = new MsgBox();
                        m.txtmsg.Text = "Veuillez d'insérer un nom de projet  valide ";
                        m.picturemsg.Image = Resources.comp_3;
                        m.Show();
                        m.timer_display.Stop();
                        // MessageBox.Show("Veuillez d'insérer un nom professionnel ", "Prenom nom valide", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }else if(cmd.ExecuteNonQuery() == 1)
                    {
                        MsgBox m = new MsgBox();
                        m.txtmsg.Text = "Nouveau Projet Ajouter";
                        m.Show();
                        m.buttonOk.Hide();
                        m.timer();
                        this.Close();

                       
                        // EmailAjouterProjet();
                      
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
        public void EmailAjouterProjet()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            String Query = "select Utilisateur.Mail from Utilisateur ;";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();//
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    EnvoyerEmail((string)rd[0]);

                }
                cnx.Close();
            }
        }
    
        public void EnvoyerEmail(string email)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("ihssaneihssanita89@gmail.com");
                    mail.To.Add(email);
                    mail.Subject = "Nouvelle Projet";
                    mail.Body = "<h4 color=blue> " +MailUtiliConn(idUti) +" </h4><h4> A Ajouter une nouvelle Projet</h4><br><h5 color=blue>PROJET:</h5><h5>"+textTitreP.Text+"</h5>";
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {


                        smtp.Credentials = new NetworkCredential("", "");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                       
                       
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public String MailUtiliConn(int id)
        {


            string mail = " ";

            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            String Query = "select Utilisateur.Mail from Utilisateur where id_Utilisateur=" +id+ ";";
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
        private void txtDescP_TextChanged(object sender, EventArgs e)
        {

        }

        private void AjouterProjet_Load(object sender, EventArgs e)
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

        private void textTitreP_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
