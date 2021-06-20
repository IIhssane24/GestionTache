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

using System.Text.RegularExpressions;



namespace GestionTâche
{
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        public const string motif = @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;
        public int idUti;

        public Profile(int id )
        {
            InitializeComponent();
            this.CenterToScreen();
            this.idUti = id;
        }
        public static bool IsEmail(string email)
        {
            if (email != null) return Regex.IsMatch(email, motif);
            else return false;
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

        private void Profile_Load(object sender, EventArgs e)
        {
            AfficheProfile();
       

        }
        public void AfficheProfile()
        {

            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "select Utilisateur.Nom,Utilisateur.Prenom,Utilisateur.Mail,Rôle.TitreR,Utilisateur.Passwd from Utilisateur INNER JOIN Rôle ON Utilisateur.id_role=Rôle.id_role where id_Utilisateur=" + idUti + " ;";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    if (rd[0] != DBNull.Value || rd[1] != DBNull.Value)
                    {
                        txtNom.Text = (string)rd[0];
                        txtPrenom.Text = (string)rd[1];
                    }

                    txtEmail.Text = (string)rd[2];
                    txtRole.Text = (string)rd[3];
                    txtPassw.Text = (string)rd[4];

                }
            }


        }
            private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            AjouterM();
        }
        public Boolean checkInput()
        {
            string Mail = txtEmail.Text;
            string nom =txtNom.Text ;
            string prenom = txtPrenom.Text;
            string motPasse = txtPassw.Text;

            if (Mail.Trim().Equals(string.Empty) || nom.Trim().Equals(string.Empty)|| prenom.Trim().Equals(string.Empty) || motPasse.Trim().Equals(string.Empty))
            {
                return true;

            }
            else
            {
                return false;
            }

        }

        public void AjouterM()
        {
            string nom = txtNom.Text;
            string prenom = txtPrenom.Text;
            string email = txtEmail.Text;
            string Pass = txtPassw.Text;
            string[] NomNonValide ={ "LOLO", "TOTO" , "KIKI" , "HELLO WORLD" , "MIMI" , "KIKI" };



            try
            {
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                if (!checkInput())
                {
                    if (NomNonValide.Contains(txtNom.Text))
                    {

                        MsgBox m = new MsgBox();
                        m.txtmsg.Text = "Veuillez d'insérer un nom professionnel ";
                        m.picturemsg.Image = Resources.comp_3;
                        m.Show();
                        m.timer_display.Stop();
                        // MessageBox.Show("Veuillez d'insérer un nom professionnel ", "Prenom nom valide", MessageBoxButtons.OK, MessageBoxIcon.Error);


                    }
                    if (NomNonValide.Contains(txtPrenom.Text))
                    {
                        MsgBox m = new MsgBox();
                        m.txtmsg.Text = "Veuillez d'insérer un prenom professionnel ";
                        m.picturemsg.Image = Resources.comp_3;
                        m.Show();
                        m.timer_display.Stop();
                        //  MessageBox.Show("Veuillez d'insérer un prenom professionnel ", "Prenom nom valide", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

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
                        if (Profile.IsEmail(txtEmail.Text))
                        {
                            String Query = "Update Utilisateur set Nom='" + nom + "',Prenom='" + prenom + "',Mail='" + email + "',Passwd='" + Pass + "' where id_Utilisateur=" + idUti + ";";
                            SqlCommand cmd = new SqlCommand(Query, cnx);
                            if (cnx.State == ConnectionState.Open)
                                cnx.Close();
                            cnx.Open();

                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                MsgBox m = new MsgBox();
                                m.txtmsg.Text = "La modification est enregistrer";
                                m.buttonOk.Hide();
                                m.Show();
                                m.timer();
                                //MessageBox.Show("La modification est enregistrer ", "Ajouter Membre", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close();
                            }
                        }
                        else
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
                    m.txtmsg.Text = "Saisissez Tout vous information";
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

        public bool VerfierNom(string nom)
        {
            Regex check = new Regex(@"^([A-Z][a-z-A-z]+)$");
            bool valid = false;
            valid = check.IsMatch(nom);
           
                return valid;
           
        }
        public Boolean checkEmail()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            string mail = txtEmail.Text;

            String Query = "Select * from Utilisateur where Mail='" + mail + "' and id_Utilisateur!="+idUti+";";
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
        private void panel2_Paint(object sender, PaintEventArgs e)
        {
             //nfgjdldz,& e @&é((gea&èbça&h"à 


        }

        private void checkBox_visible_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtPassw.UseSystemPasswordChar == false)
            {

                txtPassw.UseSystemPasswordChar = true;
                button1.Image = Resources.NonVisible;

            }
            else
            {
                txtPassw.UseSystemPasswordChar = false;
                button1.Image = Resources.Visible;
            }
        }
    }
}
