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
using System.IO;
using GestionTâche.Properties;
using System.Runtime.InteropServices;


namespace GestionTâche
{
    public partial class Authentification : Form

    {

        public Authentification()
        {
            InitializeComponent();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        public string serveur;
        public  string baseDonnee;
        public List<string> mylist = new List<string>();
        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;
      

        private void Authentification_Load(object sender, EventArgs e)
        {
           
              LoadConnection();
            var connectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", serveur, baseDonnee);
            try
            {
                SqlServer sqlS = new SqlServer(connectionString);
                if (sqlS.IsConnection)
                {

                    AppSetting setting = new AppSetting();
                    setting.SaveConnectionString("cnxSqlServer", connectionString);
                  //MessageBox.Show(" La Connexion est bien établie", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                     


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }

        }



        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            string mail = txtemail.Text;
            String pass = txtpasswd.Text;
            String Query = "Select * from Utilisateur where Mail='"+mail+"' and Passwd='"+pass+"';";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {
                while (rd.Read()) {
                    
                   this.Hide();
                    Acceuil p = new Acceuil((int)rd[0]);
                    

                    p.Show();
                }
            }
            else
            {
                if (mail.Equals(""))
                {
                    MsgBox m = new MsgBox();
                    m.txtmsg.Text = "E-mail vide: Entrez votre E-mail pour vous connecter";
                    m.picturemsg.Image = Resources.comp_3;
                    m.Show();
                    m.timer_display.Stop();
                }
                else if (pass.Equals(""))
                {
                    MsgBox m = new MsgBox();
                    m.txtmsg.Text = "Mot de passe vide : Entrez votre Mot de passe pour vous connecter";
                    m.picturemsg.Image = Resources.comp_3;
                    m.Show();
                    m.timer_display.Stop();
                }
                else
                {
                    MsgBox m = new MsgBox();
                    m.txtmsg.Text = "Mot de passe ou E-mail incorrect";
                    m.picturemsg.Image = Resources.comp_3;
                    m.Show();
                    m.timer_display.Stop();
                }

            }

            cnx.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

     
        private void txtpasswd_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }


        public void LoadConnection()
        {
            try
            {
                var fileStream = new FileStream(@"C:\Users\hp\source\repos\GestionTâche\db.ini", FileMode.Open, FileAccess.Read);
                using(var streamReader= new StreamReader(fileStream, Encoding.UTF8))
                {
                    string line;
                    while((line= streamReader.ReadLine()) != null)
                    {
                        if (line.ToLower().StartsWith("serveur"))
                        {
                            string[] fullName = line.Split('=');
                            mylist.Add(fullName[1]);
                            
                        }
                        if (line.ToLower().StartsWith("basedonnee"))
                        {
                            string[] fullName = line.Split('=');
                            mylist.Add(fullName[1]);

                        }

                    }
                    serveur = mylist[0].ToString();
                    baseDonnee = mylist[1].ToString();
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBox_visible_CheckedChanged(object sender, EventArgs e)
        {
           /* if (checkBox_visible.Checked)
            {
                txtpasswd.UseSystemPasswordChar = false;

            }
            else
            {
                txtpasswd.UseSystemPasswordChar = true;
            }*/
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
        }

        private void btnexit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtpasswd.UseSystemPasswordChar == false)
            {
                txtpasswd.UseSystemPasswordChar = true;
                button1.Image = Resources.NonVisible;

            }
            else
            {
                txtpasswd.UseSystemPasswordChar = false;
                button1.Image = Resources.Visible;
            }
        }
    }
}
