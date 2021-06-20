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
using System.Text.RegularExpressions;

namespace GestionTâche
{
    public partial class AjouterMembre : Form
    {
        public AjouterMembre()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;
        int idUtiConne;
        public const string motif = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        public AjouterMembre(int id)
        {
            InitializeComponent();
            this.idUtiConne = id;
            this.CenterToScreen();
        }
        public static bool IsEmail(string email)
        {
            if (email != null) return Regex.IsMatch(email, motif);
            else return false;
        }
        private void btnTerminer_Click(object sender, EventArgs e)
        {

            AjouterM();



        }
        
        public Boolean checkInput()
        {
            string Mail= txtEmail.Text;
            string roleUti = comboBoxRole.Text;

            if (Mail.Trim().Equals(string.Empty)|| roleUti.Trim().Equals(string.Empty))
            {
                return true;

            }
            else
            {
                return false;
            }

        }


        public String MailUtiliConn()
        {


            string mail =" ";

            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            String Query = "select Utilisateur.Mail from Utilisateur where id_Utilisateur=" + idUtiConne + ";";
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

        public void AjouterM()
        {
            string pass;
            pass = RandomPassword();
            
            
            int a;
            string ru = comboBoxRole.Text;
            try
            {
                
                    SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                
                if (!checkInput())
                {
                    a = idR();

                    if (checkEmail())
                    {
                        MsgBox m = new MsgBox();
                        m.txtmsg.Text = "ce Utilisateur existe déja, Veuillez sasie un autre";
                        m.picturemsg.Image = Resources.comp_3;
                        m.Show();
                        m.timer_display.Stop();
                    }
                    else
                    {
                        if (AjouterMembre.IsEmail(txtEmail.Text)){
                   
                            String Query = "insert into Utilisateur (Mail,id_role,Passwd) VALUES ('" + txtEmail.Text + "'," + a + ",'" + pass + "');";
                            SqlCommand cmd = new SqlCommand(Query, cnx);
                            if (cnx.State == ConnectionState.Open)
                                cnx.Close();
                            cnx.Open();

                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                MsgBox m = new MsgBox();
                                m.txtmsg.Text = "Nouveau Utilisateur ajouter";
                                m.Show();
                                m.buttonOk.Hide();
                                m.timer();
                                EmailPa(pass);
                                this.Close();
                            }


                        } else
                        {
                            MsgBox m = new MsgBox();
                            m.txtmsg.Text = "Veuillez d'insérer un email correct";
                            m.picturemsg.Image = Resources.comp_3;
                            m.Show();
                            m.timer_display.Stop();

                        }
                    }



                }
                else
                {
                    MsgBox m = new MsgBox();
                    m.txtmsg.Text = "Saisissez les information d'utilisteurs";
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
        public void EmailPa(string pass)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("ihssaneihssanita89@gmail.com");
                    mail.To.Add(txtEmail.Text);
                    mail.Subject = "Invitation";
                    mail.Body = "<h4> <font color='blue'>" + MailUtiliConn() + " </font> vous a invité à le rejoindre </h4><h4> votre mot de passe est :<font color='red'>" + pass + "</font></h4>";
                    mail.IsBodyHtml = true;
                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {


                        smtp.Credentials = new NetworkCredential("", "");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                        MessageBox.Show("Email envoyées");
                        this.Close();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        public Boolean checkEmail()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            string mail = txtEmail.Text;
            
            String Query = "Select * from Utilisateur where Mail='" + mail + "' and Passwd is NOT NULL;";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                // MessageBox.Show("ce email existe déja");
                return true;
            }
            else
            {
                return false;

            }
        }
        private void txtNom_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txtPrenom_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void AjouterMembre_Load(object sender, EventArgs e)
        {
            RôleU();
            comboBoxRole.SelectedIndex = 1;
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
        public int idR()
        {
            string titre = comboBoxRole.Text;
            int r = 0;
            try
            {
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                String Query = "select id_role from Rôle where TitreR='" + titre+"';";
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

        public int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        // Generate a random string with a given size and case.   
        // If second parameter is true, the return string is lowercase  
        public string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }

        // Generate a random password of a given length (optional)  
        public string RandomPassword(int size = 0)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

    }
}
