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
namespace GestionTâche
{
    public partial class Messages : Form
    {
        public Messages()
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
       
        public Messages(int idU)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.idUti = idU;
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Messages_Load(object sender, EventArgs e)
        {
            listMessage();
            listMessageUtili();

        }

        public void listMessage()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            string mailCree;
            string tache;
            int idM;
           
            String Query = "select id_Message,titreM,tache,envoyerPar,dateM from MessageU where attribuerA=" + idUti + " and etat=0 and tache is NOT NULL ;";

            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
           
            if (rd.HasRows)
            {

                while (rd.Read())
                {

                    idM = (int)rd[0];
                    MessageControl1 m = new MessageControl1(idUti, idM);
                    m.richTextBox1.Hide();
                    m.TitreMessage = (string)rd[1] + " : ";
                    tache = TacheM((int)rd[2]);
                    mailCree = MailUtiliCrr((int)rd[3]);
                    m.TacheT = tache;
                    m.Email = "par: " + mailCree;
                    m.panelmsg.BackColor= Color.FromArgb(81, 196, 211); 
                    m.DateT = rd[4].ToString();
                    m.btnSupprimer.Hide();
                   

                    flowLayoutPanel1.Controls.Add(m);

                }
                cnx.Close();
               
            }
        }
        public void listMessageVU()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            string mailCree;
            string tache;
            int idM;

            String Query = "select id_Message,titreM,tache,envoyerPar,dateM from MessageU where attribuerA=" + idUti + " and etat=1 and tache is NOT NULL;";

            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {

                    idM = (int)rd[0];
                    MessageControl1 m = new MessageControl1(idUti, idM);
                    m.richTextBox1.Hide();
                    m.TitreMessage = (string)rd[1] + " : ";
                    tache = TacheM((int)rd[2]);
                    mailCree = MailUtiliCrr((int)rd[3]);
                    m.TacheT = tache;
                    m.Email = "par: " + mailCree;
                    m.panelmsg.BackColor = Color.FromArgb(81, 196, 211);
                    m.DateT = rd[4].ToString();
                    m.btnvu.Hide();
                    m.btnSupprimer.Dock = DockStyle.Right;

                    flowLayoutPanel1.Controls.Add(m);

                }
                cnx.Close();
               
            }
        }
        public void listMessageUtili()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            string mailCree;
            
            int idM;
            String Query = "select id_Message,titreM,DetailsMsg,envoyerPar,dateM from MessageU where attribuerA=" + idUti + " and etat=0 and  tache is NULL;";

            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            
            if (rd.HasRows)
            {

                while (rd.Read())
                {

                    idM = (int)rd[0];
                    MessageControl1 m = new MessageControl1(idUti, idM);
                    m.txtTache.Hide();
                    m.TitreMessage = (string)rd[1] + " : ";
                    m.TextM = (string)(rd[2]);
                    mailCree = MailUtiliCrr((int)rd[3]);
                    m.Email = "par: " + mailCree;
                    m.DateT = rd[4].ToString();
                    m.panelmsg.BackColor = Color.FromArgb(18, 110, 130);
                    m.btnSupprimer.Hide();
                    
                    flowLayoutPanel1.Controls.Add(m);

                }
                cnx.Close();
                
            }
            
        }
        public void listMessageUtiliVU()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            string mailCree;

            int idM;
            String Query = "select id_Message,titreM,DetailsMsg,envoyerPar,dateM from MessageU where attribuerA=" + idUti + " and etat=1 and  tache is NULL;";

            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {

                    idM = (int)rd[0];
                    MessageControl1 m = new MessageControl1(idUti, idM);
                    m.txtTache.Hide();
                    m.TitreMessage = (string)rd[1] + " : ";
                    m.TextM = (string)(rd[2]);
                    mailCree = MailUtiliCrr((int)rd[3]);
                    m.Email ="par: "+mailCree;
                    m.DateT = rd[4].ToString();
                    m.panelmsg.BackColor = Color.FromArgb(18, 110, 130);
                    m.btnvu.Hide();
                    m.btnSupprimer.Dock = DockStyle.Right;
                    
                    flowLayoutPanel1.Controls.Add(m);

                }
                cnx.Close();
                
            }
        }
        public String MailUtiliCrr(int id)
        {


            string mail = " ";

            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            String Query = "select Utilisateur.Mail from Utilisateur where id_Utilisateur=" +id+ ";";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
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
        public String TacheM(int id)
        {


            string titre = " ";

            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            String Query = "select TitreT from Tache where id_Tache=" + id + ";";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            
            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    titre = (string)rd[0];

                }
                cnx.Close();
            }

            return titre;
        }

        private void btnEnvoyer_Click(object sender, EventArgs e)
        {
            Panel p = this.Parent as Panel;

            if (p != null)
            {

                EnvoyerMessage myForm = new EnvoyerMessage(idUti);

                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                p.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();
                


            }
        }
        public void MessageEnvoyes()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            string mailCree;

            int idM;
            String Query = "select id_Message,titreM,DetailsMsg,attribuerA,dateM from MessageU where envoyerPar=" + idUti + " and etat=0 and  tache is NULL;";

            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {

                    idM = (int)rd[0];
                    MessageControl1 m = new MessageControl1(idUti, idM);
                    m.txtTache.Hide();
                    m.TitreMessage = (string)rd[1] + " : ";
                    m.TextM = (string)(rd[2]);
                    mailCree = MailUtiliCrr((int)rd[3]);
                    m.Email = "A:" + mailCree;
                    m.DateT = rd[4].ToString();
                    m.panelmsg.BackColor = Color.FromArgb(18, 110, 130);
                    m.btnSupprimer.Hide();
                   
                    flowLayoutPanel1.Controls.Add(m);

                }
                cnx.Close();
              
            }

        }
     

        private void messagesEnvoyéesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            MessageEnvoyes();
        }

      

        private void messagesEnvoyéesToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            listMessage();
            listMessageUtili();
            
            //
        }

        private void messagesVuToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            listMessageVU();
            listMessageUtiliVU();
        }

        private void messagesEnvoyéesToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            MessageEnvoyes();
        }
    }
}
