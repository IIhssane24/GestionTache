using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using GestionTâche.Properties;
using System.Data.SqlClient;
using System.Configuration;
using System.Net;
using System.Net.Mail;
namespace GestionTâche
{
    public partial class EnvoyerMessage : Form
    {
        public EnvoyerMessage()
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
        string role;
        public EnvoyerMessage(int id)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.idUti = id;
        }
        public void Role()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "  select Rôle.TitreR  from Rôle INNER JOIN Utilisateur ON Utilisateur.id_role=Rôle.id_role where Utilisateur.id_Utilisateur=" +idUti+ "; ";
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
        private void EnvoyerMessage_Load(object sender, EventArgs e)
        {
            Utilisateur();
            Role();
            if (!(role.Equals("Responsable")))
            {
                comboBoxMe.Items.Clear();
                comboBoxMe.Text = "ihssaneidaazzi89@gmail.com";
               

            }
            
        }

        private void EnvoyerMessage_MouseDown(object sender, MouseEventArgs e)
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
        public int IdUtilisatuer(string Mail)
        {
            int i = 0;
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = " select id_Utilisateur from Utilisateur where Mail='" + Mail + "';";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    i = (int)rd[0];


                }

            }
            return i;
        }
        public void Utilisateur()
        {
            try
            {
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                String Query = "select Mail from Utilisateur;";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                cnx.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {

                    while (rd.Read())
                    {
                        comboBoxMe.Items.Add(rd[0].ToString());

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public String MailUtiliConn(int id)
        {


            string mail="";

            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            String Query = "select Utilisateur.Mail from Utilisateur where id_Utilisateur=" + id + ";";
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
        public void EnvoyerEmail(string email)
        {
            string objet = txtMessage.Text;
            string message = txtmsg.Text;
            if (message.Trim().Equals(string.Empty))
            {
                return;
            }
            else
            {
                try
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("ihssaneihssanita89@gmail.com");
                        mail.To.Add(email);
                        mail.Subject = "Nouvelle Message";
                        mail.Body = "<h4> <i style='color:#00008B'>" + MailUtiliConn(idUti) + "</i> A envoyez Pour vous une nouvelle message </h4><br><table><tr><th style='background-color:#ADD8E6'> Objet: </th><th>" +objet+ "</th></tr><tr><th style='background-color:#ADD8E6'>Message:</th><th>" +message + "</th></tr></table>";
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
        }
        private void btnEnvoyer_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                string mem = comboBoxMe.Text;
                string msg = txtmsg.Text;
                string TitreM = txtMessage.Text;
                int idmem = IdUtilisatuer(mem);
                string Date = DateTime.Now.ToString("yyyy-MM-dd");
                String Query = "insert into MessageU (titreM,envoyerPar,attribuerA,dateM,etat,DetailsMsg) VALUES ('"+ TitreM + "',"+idUti+ "," + idmem + ",'" + Date + "',0,'"+msg+"');";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                cnx.Open();
                if (!checkInput())
                {

                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MsgBox m = new MsgBox();
                        m.txtmsg.Text = "Message envoyer";
                        m.buttonOk.Hide();
                       
                        m.Show();
                        
                       
                        EnvoyerEmail(mem);
                        this.Close();
                    }

                }
                else
                {
                    MsgBox m = new MsgBox();
                    m.txtmsg.Text = "Veuillez insérer les information important du Tacher";
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
         
            string membre = comboBoxMe.Text;
            string msg= txtmsg.Text;
            string TitreM = txtMessage.Text;


            if (msg.Trim().Equals(string.Empty) || membre.Trim().Equals(string.Empty)|| TitreM.Trim().Equals(string.Empty))
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        private void btnminim_MouseDown(object sender, MouseEventArgs e)
        {

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
