using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using GestionTâche.Properties;
using System.Data;
using System.Net;
using System.Net.Mail;
namespace GestionTâche
{
    public partial class ModifierTache : Form
    {
        public ModifierTache()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);

        int idTache;//id Tache;
        int idUtilisateur;//id Utilisateur connecter
        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;
        int idProjet;
       

        public ModifierTache(int id,int idU,int idP)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.idTache = id;
            this.idUtilisateur = idU;
            this.idProjet = idP;
        }

       

        private void labelClose_Click(object sender, EventArgs e)
        {
            this.Close();
       
       }



        private void ModifierTache_Load(object sender, EventArgs e)
        {

            ProjetA();
            Utilisateur();
            AfficherInfoTache();
            
           
        }


        public void AfficherInfoTache()
        {
            try
            {
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                String Query = "select Tache.TitreT,Tache.DescriptionT, Tache.Echéance, Projet.Titre, Utilisateur.Mail From Tache INNER JOIN Statut ON  Tache.id_Tache = Statut.id_Tache INNER JOIN Projet ON Statut.id_projet = Projet.id_projet  INNER JOIN journalisation ON Tache.id_Tache = Journalisation.id_Tache INNER JOIN Utilisateur ON journalisation.id_Utilisateur_aff = Utilisateur.id_Utilisateur where Tache.id_Tache= " + idTache + ";";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                cnx.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                DateTime date;
                if (rd.HasRows)
                {

                    while (rd.Read())
                    {
                        textTitreT.Text = (string)rd[0];
                        txtDescT.Text = (string)rd[1];
                        date = (DateTime)rd[2];
                        dateEch.Text = date.ToString("yyyy-MM-dd");
                        comboBoxProjet.SelectedItem = rd[3];
                        comboBoxMe.SelectedItem = (string)rd[4];


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
            }  catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        public void ProjetA()
        {
            try
            {
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                String Query = "select Titre from Projet;";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                cnx.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.HasRows)
                {

                    while (rd.Read())
                    {
                        comboBoxProjet.Items.Add(rd[0].ToString());

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


            string mail = " ";

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
        public void EnvoyerEmail(string email,string msg)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("ihssaneihssanita89@gmail.com");
                    mail.To.Add(email);
                    mail.Subject = "Modifier Tache";
                    mail.Body = "<h4 color=blue> " + MailUtiliConn(idUtilisateur) + " </h4><h4>"+msg+"</h4><br><h5 color=blue>" + textTitreT.Text + " de PROJET "+comboBoxProjet.Text+" </h5>";
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
        private void btnEnregister_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                string titre = textTitreT.Text;
                string Descr = txtDescT.Text;
                string email = comboBoxMe.Text;
                string titreProjet = comboBoxProjet.Text;
                int idUti;
                string Date = DateTime.Now.ToString("yyyy-MM-dd");
                String Query = "update Tache set TitreT= '" + titre + "',Echéance='" + this.dateEch.Text + "',DescriptionT='" + Descr + "' where id_Tache="+idTache+";";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                cnx.Open();
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                            idUti = IdUtilisatuer(email); 
                            MsgBox m = new MsgBox();
                            m.txtmsg.Text = "Tâche est bien  modifier ";
                            m.buttonOk.Hide();
                            m.Show();
                            m.timer();
                    IdProjetEnregistrer(IdProjet(titreProjet));
                        String Quer = "Update Journalisation SET id_Utilisateur_aff="+ idUti + " WHERE id_Tache="+idTache+ ";";
                        SqlCommand cmd1 = new SqlCommand(Quer, cnx);
                        cmd1.ExecuteNonQuery();
                       MessageU("Tache Modifier",idTache, idUtilisateur, idUti);
                           
                 
                       EnvoyerEmail(email, " A Modifier La Tache");
                       this.Hide();
                   
                    Form fc = Application.OpenForms["TacheProjet"];

                    if (fc != null)
                        fc.Close();
                    Panel p = this.Parent as Panel;
                    if (p != null)
                    {
                        fc = new TacheProjet(idProjet, idUtilisateur);

                        fc.TopLevel = false;
                        fc.AutoScroll = true;
                        p.Controls.Add(fc);
                        fc.Show();
                        fc.BringToFront();


                    }



                }
                    


                
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
        public int IdProjet(string titre)
        {
           
            int i = 0;
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = " select id_projet from Projet where Titre='" + titre + "';";
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
        public void IdProjetEnregistrer(int idP)
        {
            try
            {
                
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                String Query = " update Statut  set id_projet=" + idP + " where id_Tache='" + idTache + "';";
                cnx.Open();
                SqlCommand cmd = new SqlCommand(Query, cnx);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        public void MessageU(string Tache,int idTache, int envoyP, int attrA)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {
                    string Date = DateTime.Now.ToString("yyyy-MM-dd");
                    String Query = " insert into MessageU (titreM,tache,envoyerPar,attribuerA,dateM,etat ) VALUES ('"+Tache+"'," + idTache + "," + envoyP + "," + attrA + ",'"+Date+"',0);";
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxProjet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
