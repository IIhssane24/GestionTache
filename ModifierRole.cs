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
using System.Net;
using System.Net.Mail;
using System.Runtime.InteropServices;
using GestionTâche.Properties;
namespace GestionTâche
{
    public partial class ModifierRole : Form
    {
        public ModifierRole()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

   
        public int idUtiM;
        public int idUtiConnect;

        public ModifierRole(int idC,int idM)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.idUtiConnect = idC;
            this.idUtiM = idM;
           
        }
        private void ModifierRole_Load(object sender, EventArgs e)
        {
            
            RôleU();
            AfficherRole();


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
        public void AfficherRole()
        {
            try
            {
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                String Query = "select Utilisateur.Mail, Rôle.TitreR from Utilisateur INNER JOIN Rôle ON Utilisateur.id_role=Rôle.id_role where Utilisateur.id_Utilisateur=" + idUtiM+";";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                cnx.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                
                if (rd.HasRows)
                {

                    while (rd.Read())
                    {

                        txtEmail.Text = (string)rd[0];
                        comboBoxRole.SelectedItem = (string)rd[1];


                    }
                    cnx.Close();
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnminim_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }
        public void RôleU()
        {
            try
            {
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                String Query = "select TitreR from Rôle;";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                cnx.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {

                    while (rd.Read())
                    {
                        comboBoxRole.Items.Add(rd[0].ToString());

                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTerminer_Click(object sender, EventArgs e)
        {
            
                try
                {

                    SqlConnection cnx = new SqlConnection();
                    cnx.ConnectionString = connectionString;
                    String Query = " Update Utilisateur Set id_role="+idR()+" where id_Utilisateur="+idUtiM+";";
                    cnx.Open();
                    SqlCommand cmd = new SqlCommand(Query, cnx);

                    cmd.ExecuteNonQuery();
                        MsgBox m = new MsgBox();
                        m.txtmsg.Text = "Le Rôle de ce Utilisateur est modifier";
                        m.buttonOk.Hide();
                        m.Show();
                        m.timer();
                        

                    MessageU();
                    EmailPa();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            



        }
        public void EmailPa()
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("ihssaneihssanita89@gmail.com");
                    mail.To.Add(MailUtiliConn(idUtiM));
                    mail.Subject = "Role changer";
                    mail.Body = "<h4>Votre Rôle est changer par:  <font color='blue'>" + MailUtiliConn(idUtiConnect) + " </font></h4><h4>Votre Nouveaux rôle  :<font color='red'>" +comboBoxRole.Text+ "</font></h4>";
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {


                        smtp.Credentials = new NetworkCredential("", "");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        MsgBox m = new MsgBox();
                        m.txtmsg.Text = "Email envoyées";
                        m.buttonOk.Hide();
                        m.Show();
                        m.timer();
                        this.Close();


                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        public String MailUtiliConn(int idUti)
        {


            string mail = " ";

            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            String Query = "select Utilisateur.Mail from Utilisateur where id_Utilisateur=" +idUti + ";";
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
        public int idR()
        {
            string titre = comboBoxRole.Text;
            int r = 0;
            try
            {
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                String Query = "select id_role from Rôle where TitreR='" + titre + "';";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                cnx.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {

                    while (rd.Read())
                    {
                        r = (int)rd[0];
                        return r;

                    }
                    return r;

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return r;

        }
        public void MessageU()
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    string Date = DateTime.Now.ToString("yyyy-MM-dd");
                    String Query = " insert into MessageU (titreM,envoyerPar,attribuerA,dateM,etat ) VALUES ('Votre Rôle est modifier'," +idUtiConnect+ "," +idUtiM+ ",'" + Date + "',0);";
                    SqlCommand cmd = new SqlCommand(Query, cnx);

                    if (cnx.State == ConnectionState.Open)
                        cnx.Close();
                    cnx.Open();

                    cmd.ExecuteNonQuery();

                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void txtEmail_Click(object sender, EventArgs e)
        {

        }
    }
}
