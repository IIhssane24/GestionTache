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
using System.Threading;

namespace GestionTâche
{
    public partial class AjouterTache : Form
    {
        public AjouterTache()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        int idU;
        public string role;
        static readonly CancellationTokenSource s_cts = new CancellationTokenSource();
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        public AjouterTache(int idUt)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.idU = idUt;
        }
        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;

        public int VréifierDateExiste()
        {
            int i = 0;
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
           string mem = comboBoxMe.Text;
            int a= IdUtilisatuer(mem);
            String Query = "SELECT Tache.DateCreation,Tache.Echéance From Tache INNER JOIN Journalisation ON Tache.id_Tache = journalisation.id_Tache INNER JOIN Utilisateur ON journalisation.id_Utilisateur_aff=Utilisateur.id_Utilisateur where journalisation.id_Utilisateur_aff = " + a+ "  ; ";

            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            DateTime nouvelleDate = dateEch.Value;
            DateTime dateC, dateF = new DateTime();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    dateC = (DateTime)rd[0];
                    dateF= (DateTime)rd[1];
                    if (nouvelleDate > dateC && nouvelleDate < dateF || ((dateF- dateEch.Value).Days) == 0)
                        i = i + 1;


                }
               
                cnx.Close();
            }



            return i;
        }
        private void btnEnregister_Click(object sender, EventArgs e)
        {
            
            try {
                    SqlConnection cnx = new SqlConnection();
                    cnx.ConnectionString = connectionString;
                    string titre = textTitreT.Text;
                    string Descr = txtDescT.Text;
                    string mem = comboBoxMe.Text;
                    string titreProjet = comboBoxProjet.Text;  
                    int idUti, idTache,idProjet;
                    string Date = DateTime.Now.ToString("yyyy-MM-dd");
                     
               
                    String Query = "insert into Tache (TitreT,Echéance,DescriptionT,DateCreation) VALUES ('" + titre + "','" + this.dateEch.Text + "','" + Descr + "','" + Date + "');";
                    SqlCommand cmd = new SqlCommand(Query, cnx);
                    cnx.Open();
                    if (!checkInput())
                    {
                    
                    if (DateTime.Now < dateEch.Value ||((DateTime.Now - dateEch.Value).Days)==0)
                    {
                        if (VréifierDateExiste()< 3) {
                            if (cmd.ExecuteNonQuery() == 1)
                            {

                                idTache = IdTache(titre, Date, this.dateEch.Text);

                                if (!(titreProjet.Trim().Equals(string.Empty)))
                                {
                                    idProjet = IdProjet(titreProjet);

                                    ProjetTache(idTache, idProjet);

                                }
                                if ((mem.Trim().Equals(string.Empty)))
                                {
                                    String Quer ="insert into Journalisation (id_Tache,id_Utilisateur_Crée,id_Utilisateur_aff,Terminer, Etiquette) VALUES (" + idTache + "," + idU + "," + idU + "," + 0 + ",'A faire');";
                                    SqlCommand cmd1 = new SqlCommand(Quer, cnx);
                                    cmd1.ExecuteNonQuery();
                                    MessageU(idTache, idU, idU, Date);
                                    //MessageU(idTache,idU,idU,Date);
                                    
                                    



                                }
                                else
                                {
                                    idUti = IdUtilisatuer(mem);

                                    journalisationTache(idTache, idUti);
                                    //MessageU(int idTache, int envoyP, int attrA,string date)
                                    MessageU(idTache, idU, idUti, Date);
                                    




                                }
                            }

                            MessageBox.Show("Nouvelle tâche effectuer", "Nouvelle Tâche", MessageBoxButtons.OK, MessageBoxIcon.Information);
                          
                            EnvoyerEmail(mem, "A effectue pour vous une nouvelle tache ");
                            this.Hide();
                            //  EnvoyerEmail(mem, "A effectue pour vous une nouvelle tache ");

                            


                        }
                        else
                        {
                            MsgBox m = new MsgBox();
                            m.txtmsg.Text = mem+"  a déja "+VréifierDateExiste()+ " Tache  dans cette date ";
                            m.picturemsg.Image = Resources.comp_3;
                            m.Show();
                            m.timer_display.Stop();
                        }

                    }else
                    {
                        MsgBox m = new MsgBox();
                        m.txtmsg.Text = "Veuillez de choisir une date supérieure d'aujourd'hui";
                        m.picturemsg.Image = Resources.comp_3;
                        m.Show();
                        m.timer_display.Stop();
                       // MessageBox.Show("Veuillez insérer une date supérieure d'aujourd'hui", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else
                {
                    MsgBox m = new MsgBox();
                    m.txtmsg.Text = "Veuillez insérer les information important du Tache";
                    m.picturemsg.Image = Resources.comp_3;
                    m.Show();
                    m.timer_display.Stop();
                    // MessageBox.Show("Veuillez insérer les information important du Tache ", "Tache", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

             }
            catch (Exception ex)
                    {
                         
                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }

        public Boolean checkInput()
        {
            string Titre = textTitreT.Text;
            DateTime da = dateEch.Value;

            if (Titre.Trim().Equals(string.Empty) || da.Equals(""))
            {
                return true;

            }
            else
            {
                return false;
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
            }
            catch (Exception ex)
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
        public void EnvoyerEmail(string email, string msg)
        {
            string titre = textTitreT.Text;
            string mem = comboBoxMe.Text;
            if (mem.Trim().Equals(string.Empty))
            {
                return;
            }
            else {
                try
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("ihssaneihssanita89@gmail.com");
                        mail.To.Add(email);
                        mail.Subject = "Nouvelle Tache";
                        mail.Body = "<h4> <i style='color:#00008B'>" + MailUtiliConn(idU) + "</i>  "+msg+"</h4><br><table><tr><th style='background-color:#ADD8E6'>Tâche</th><th>" + titre + "</th></tr><tr><th style='background-color:#ADD8E6'> De PROJET</th><th>" + comboBoxProjet.Text + "</th></tr><tr><th style='background-color:#ADD8E6'>Echéance</th><th>" + this.dateEch.Text+ "</th></tr></table>";
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
        private void AjouterTache_Load(object sender, EventArgs e)
        {
            Utilisateur();
            ProjetA();
            Role();
            if (!(role.Equals("Responsable")||role.Equals("chef de projet")))
            {
                DeProjet.Hide();
                AttribueA.Hide();
                comboBoxMe.Hide();
                comboBoxProjet.Hide();
                txtDescT.Location=new Point(133,250) ;
                txtDescT.Height = 130;
                DescriptionT.Location = new Point(13, 250);


            }



        }
        public void Role()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "  select Rôle.TitreR  from Rôle INNER JOIN Utilisateur ON Utilisateur.id_role=Rôle.id_role where Utilisateur.id_Utilisateur=" + idU + "; ";
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
        public int IdTache(string titre,string dateCretion,string ech)
        {

            int i=0;
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = " select id_Tache from Tache where TitreT='"+titre+"' and Echéance='"+ ech + "' and DateCreation='"+ dateCretion + "';";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    i =(int)rd[0];
                    

                }
                
              }
           return i;
        }
        public int IdUtilisatuer(string Mail)
        {
            int i = 0;
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = " select id_Utilisateur from Utilisateur where Mail='"+Mail+"';";
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
            String Query = " select id_projet from Projet where Titre='"+titre+"';";
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
        public void ProjetTache(int idTache, int idProjet)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {

                    String Query = " insert into statut (id_Tache,id_projet) VALUES (" + idTache + "," + idProjet + ");";
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
        public void journalisationTache(int idTache,int idA)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {

                    String Query = "insert into Journalisation (id_Tache,id_Utilisateur_Crée,id_Utilisateur_aff,Terminer, Etiquette) VALUES ("+idTache+","+idU+","+idA+",0,'A faire');;";
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
        public void MessageU(int idTache, int envoyP, int attrA,string date)
        {
            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {

                    String Query = " insert into MessageU (titreM,tache,envoyerPar,attribuerA,dateM,etat ) VALUES ('Ajouter Tache'," + idTache+","+envoyP+","+attrA+",'"+date+"',0);";
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

        private void dateEch_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxMe_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AjouterTache_MouseDown(object sender, MouseEventArgs e)
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAjouterU_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
           

        }

        

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012,0);
        }
    }
}
