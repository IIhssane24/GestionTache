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

namespace GestionTâche
{
    public partial class TacheProjet : Form
    {
        public TacheProjet()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;
        public int id;//id projet
        public int idUti;//id UtilisateurConn
       
        public TacheProjet(int a,int idU)
        {
            InitializeComponent();
            this.CenterToScreen();
            this.id = a;
            this.idUti = idU;
        }
       

      

        private void TacheProjet_Load(object sender, EventArgs e)
        {
            Projet();
            comboBoxStatut.SelectedIndex=0;
            
            listTache();
            
        }

        public void TacheContrôle_Click(object sender, EventArgs e)
        {
          
        }

        public void Projet()
        {
            int idP = id;
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "SELECT * FROM Projet where id_projet='" +idP+ "';";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    TitreP.Text = (string)rd[1];
                    txtDescp.Text= (string)rd[2];
                }
                cnx.Close();
            }
            else
            {
                MessageBox.Show("Error");
            }

        }
        public void listTache()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
          
            string mailAtt ;
            string mailCree ;
            string etiquette;

            DateTime date_1 = new DateTime();
            DateTime date_2 = new DateTime();
            DateTime date_3 = DateTime.Now;
            String Query = "SELECT DISTINCT Tache.id_Tache , Tache.TitreT,journalisation.Etiquette,Tache.Echéance,journalisation.id_Utilisateur_Crée ,journalisation.id_Utilisateur_aff,Tache.DateCreation   From Projet INNER JOIN Statut ON Projet.id_projet = Statut.id_projet INNER JOIN Tache ON Statut.id_Tache = Tache.id_Tache INNER JOIN journalisation ON journalisation.id_Tache = Tache.id_Tache  where Projet.id_projet = " + id + " and  journalisation.Terminer =0;";
           
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            DateTime da;
            string jour, mois;
            SqlDataReader rd = cmd.ExecuteReader();
            flowLayoutPanel1.Controls.Clear();
            if (rd.HasRows)
            {

                while (rd.Read())
                {


                    TacheContrôle t = new TacheContrôle(idUti,id);
                    t.ID = (int)rd[0];
                    t.Title = (string)rd[1];
                    mailCree = MailUtiliAttri((int)rd[4]);
                    t.CreePar = mailCree;
                    mailAtt = MailUtiliAttri((int)rd[5]);
                    t.AttribuéA = mailAtt;
                    //t.AttribuéA = mailAtt + "," + t.AttribuéA;
                       

                    
                     etiquette = (string)rd[2];
                     da =(DateTime)rd[3];// ToString("yyyy-MM-dd"); dateTime.ToString("MMMM");
                    mois =da.ToString("MMM");
                    jour = da.ToString("dd");
                    date_1 = (DateTime)rd[3];
                    date_2 = (DateTime)rd[6];
                  
                        t.Date = jour + " " + mois + "( " + (date_1 - date_3).Days + " Jour)";
                    if((date_1 - date_3).Days < 0)
                    {
                        t.pictureBook.Image = Resources.bookma;
                        
                        
                    }
                   
                    t.tacehToolStripMenuItem.Image = Resources.menu;
                    t.aFaireToolStripMenuItem.Visible = false;
                    t.enCoursToolStripMenuItem.Visible = false;
                    t.enRetardToolStripMenuItem.Visible = false;
                     t.btnTerminer.Hide();
                    flowLayoutPanel1.Controls.Add(t);

                }
                cnx.Close();
            }


        }
        public void listTacheTerminer()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            DateTime date_1 = new DateTime();
            DateTime date_2 = new DateTime();
            DateTime date_3 = DateTime.Now;
            string mailAtt;
            string mailCree;
            string etiquette;
            String Query = "SELECT Tache.id_Tache , Tache.TitreT,journalisation.Etiquette,Tache.Echéance,journalisation.id_Utilisateur_Crée ,journalisation.id_Utilisateur_aff,Tache.DateCreation  From Projet INNER JOIN Statut ON Projet.id_projet = Statut.id_projet INNER JOIN Tache ON Statut.id_Tache = Tache.id_Tache INNER JOIN journalisation ON journalisation.id_Tache = Tache.id_Tache  where Projet.id_projet = " + id + " and journalisation.Terminer =1;";

            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            DateTime da;
            string jour, mois;
            SqlDataReader rd = cmd.ExecuteReader();
            flowLayoutPanel1.Controls.Clear();
            if (rd.HasRows)
            {

                while (rd.Read())
                {



                    TacheContrôle t = new TacheContrôle(idUti, id);
                    t.ID = (int)rd[0];
                    t.Title = (string)rd[1];
                    mailCree = MailUtiliAttri((int)rd[4]);
                    t.CreePar = mailCree;
                    mailAtt = MailUtiliAttri((int)rd[5]);
                    t.AttribuéA = mailAtt;
                    etiquette = (string)rd[2];
                    da = (DateTime)rd[3];// ToString("yyyy-MM-dd"); dateTime.ToString("MMMM");
                    mois = da.ToString("MMM");
                    jour = da.ToString("dd");
                    date_1 = (DateTime)rd[3];
                    date_2 = (DateTime)rd[6];

                    t.Date = jour + " " + mois;
                  
                    t.tacehToolStripMenuItem.Image = Resources.menu;
                    t.aFaireToolStripMenuItem.Visible = false;
                    t.enCoursToolStripMenuItem.Visible = false;
                    t.enRetardToolStripMenuItem.Visible = false;
                    t.btnTerminer.Hide();
                    flowLayoutPanel1.Controls.Add(t);

                }
                cnx.Close();
            }


        }
        public void listTacheAfaire()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            string mailAtt;
            string mailCree;
            string etiquette;

            DateTime date_1 = new DateTime();
            DateTime date_2 = new DateTime();
            String Query = "SELECT Tache.id_Tache , Tache.TitreT,journalisation.Etiquette,Tache.Echéance,journalisation.id_Utilisateur_Crée ,journalisation.id_Utilisateur_aff,Tache.DateCreation  From Projet INNER JOIN Statut ON Projet.id_projet = Statut.id_projet INNER JOIN Tache ON Statut.id_Tache = Tache.id_Tache INNER JOIN journalisation ON journalisation.id_Tache = Tache.id_Tache   where Projet.id_projet = " + id + " and journalisation.Etiquette='A faire' and journalisation.Terminer =0;";

            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            DateTime da;
            DateTime date_3 = DateTime.Now;
            string jour, mois;
            SqlDataReader rd = cmd.ExecuteReader();
            flowLayoutPanel1.Controls.Clear();
            if (rd.HasRows)
            {

                while (rd.Read())
                {



                    TacheContrôle t = new TacheContrôle(idUti, id);
                    t.ID = (int)rd[0];
                    t.Title = (string)rd[1];
                    mailCree = MailUtiliAttri((int)rd[4]);
                    t.CreePar = mailCree;
                    mailAtt = MailUtiliAttri((int)rd[5]);
                    t.AttribuéA = mailAtt;
                    etiquette = (string)rd[2];
                    da = (DateTime)rd[3];// ToString("yyyy-MM-dd"); dateTime.ToString("MMMM");
                    mois = da.ToString("MMM");
                    jour = da.ToString("dd");
                    date_1 = (DateTime)rd[3];
                    date_2 = (DateTime)rd[6];
                   
                    t.Date = jour + " " + mois + "( " + (date_1 - date_3).Days + " Jour)";
                    if ((date_1 - date_3).Days < 0)
                    {
                        t.pictureBook.Image = Resources.bookma;

                    }
                    t.tacehToolStripMenuItem.Image = Resources.menu;
                    t.aFaireToolStripMenuItem.Visible = false;
                    t.enCoursToolStripMenuItem.Visible = false;
                    t.enRetardToolStripMenuItem.Visible = false;
                    t.btnTerminer.Hide();
                    flowLayoutPanel1.Controls.Add(t);

                }
                cnx.Close();
            }


        }
        public void listTacheEnCours()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            
            string mailAtt;
            string mailCree;
            string etiquette;

            DateTime date_1 = new DateTime();
            DateTime date_2 = new DateTime();
            String Query = "SELECT Tache.id_Tache , Tache.TitreT,journalisation.Etiquette,Tache.Echéance,journalisation.id_Utilisateur_Crée ,journalisation.id_Utilisateur_aff,Tache.DateCreation  From Projet INNER JOIN Statut ON Projet.id_projet = Statut.id_projet INNER JOIN Tache ON Statut.id_Tache = Tache.id_Tache INNER JOIN journalisation ON journalisation.id_Tache = Tache.id_Tache   where Projet.id_projet = " + id + " and journalisation.Etiquette='En cours' and journalisation.Terminer =0;";

            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            DateTime da;
            string jour, mois;
            SqlDataReader rd = cmd.ExecuteReader();
            flowLayoutPanel1.Controls.Clear();
            if (rd.HasRows)
            {

                while (rd.Read())
                {

                 

                    TacheContrôle t = new TacheContrôle(idUti, id);
                    
                    t.ID = (int)rd[0];
                    t.Title = (string)rd[1];
                    mailCree = MailUtiliAttri((int)rd[4]);
                    t.CreePar = mailCree;
                    mailAtt = MailUtiliAttri((int)rd[5]);
                    t.AttribuéA = mailAtt;
                    date_1 = (DateTime)rd[3];
                    date_2 = (DateTime)rd[6];
                    
                    etiquette = (string)rd[2];
                    da = (DateTime)rd[3];// ToString("yyyy-MM-dd"); dateTime.ToString("MMMM");
                    mois = da.ToString("MMM");
                    jour = da.ToString("dd");
                    DateTime date_3 = DateTime.Now;
                    t.Date = jour + " " + mois + "( " + (date_1 - date_3).Days + " Jour)";
                    if ((date_1 - date_3).Days < 0)
                    {
                        t.pictureBook.Image = Resources.bookma;

                    }
                    t.tacehToolStripMenuItem.Image = Resources.menu;
                    t.aFaireToolStripMenuItem.Visible = false;
                    t.enCoursToolStripMenuItem.Visible = false;
                    t.enRetardToolStripMenuItem.Visible = false;
                    t.btnTerminer.Hide();
                    flowLayoutPanel1.Controls.Add(t);

                }
                cnx.Close();
            }


        }
        public void listTacheEnretard()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            string mailAtt;
            string mailCree;
            string etiquette;
            DateTime date_1 = new DateTime();
            DateTime date_2 = new DateTime();
     
            String Query = "SELECT Tache.id_Tache , Tache.TitreT,journalisation.Etiquette,Tache.Echéance,journalisation.id_Utilisateur_Crée ,journalisation.id_Utilisateur_aff,Tache.DateCreation  From Projet INNER JOIN Statut ON Projet.id_projet = Statut.id_projet INNER JOIN Tache ON Statut.id_Tache = Tache.id_Tache INNER JOIN journalisation ON journalisation.id_Tache = Tache.id_Tache   where Projet.id_projet =" + id+" and journalisation.Etiquette='En retard' and journalisation.Terminer =0;";

            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            DateTime da;
            string jour, mois;
            SqlDataReader rd = cmd.ExecuteReader();
            flowLayoutPanel1.Controls.Clear();
            if (rd.HasRows)
            {

                while (rd.Read())
                {


                    TacheContrôle t = new TacheContrôle(idUti,id);
                    t.ID = (int)rd[0];
                    t.Title = (string)rd[1];
                     mailCree = MailUtiliAttri((int)rd[4]);
                      t.CreePar = mailCree;
                     mailAtt = MailUtiliAttri((int)rd[5]);
;                    date_1 = (DateTime)rd[3];
                      date_2= (DateTime)rd[6];
                    t.AttribuéA = mailAtt;
                     etiquette = (string)rd[2];
                     da =(DateTime)rd[3];// ToString("yyyy-MM-dd"); dateTime.ToString("MMMM");
                    mois =da.ToString("MMM");
                    jour = da.ToString("dd");
                    DateTime date_3 = DateTime.Now;
                    t.Date = jour + " " + mois + "( " + (date_1 - date_3).Days + " Jour)";
                    if ((date_1 - date_3).Days < 0)
                    {
                        t.pictureBook.Image = Resources.bookma;

                    }
                    t.tacehToolStripMenuItem.Image = Resources.menu;
                    t.aFaireToolStripMenuItem.Visible = false;
                    t.enCoursToolStripMenuItem.Visible = false;
                    t.enRetardToolStripMenuItem.Visible = false;
                     t.btnTerminer.Hide();
                    flowLayoutPanel1.Controls.Add(t);

                }
                cnx.Close();
            }


        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAjouterT_Click(object sender, EventArgs e)
        {
            Panel p = this.Parent as Panel;

            if (p != null)
            {

                AjouterTache myForm = new AjouterTache(idUti);

                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                p.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();

                
            }
           
           
        }
       
     
        public String MailUtiliAttri(int a)
        {
           
            string mail = " ";

            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

                String Query = "select  Mail from Utilisateur Where id_Utilisateur=" + a + ";";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                cnx.Open();
                SqlDataReader rd = cmd.ExecuteReader();

                if (rd.HasRows)
                {

                    while (rd.Read())
                    {
                        mail = (string)rd[0];
                        return mail;
                    }
                    cnx.Close();
                }
             
            return mail;
        }
      
        
        public String MailUtiliCrr()
        {

           
            string mail = " ";

            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

                String Query = "select Utilisateur.Mail from Utilisateur where id_Utilisateur=" + idUti + ";";
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

   
        
  
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Vous Voulez supprimer ce Projet", "Vérifier la suppression",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning);
         
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "Delete from Statut where id_projet=" + id + ";";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            if (cnx.State == ConnectionState.Open)
                cnx.Close();
            cnx.Open();
            
            if (result==DialogResult.OK)
            {
                cmd.ExecuteNonQuery();
                Supprimerprojet();
                MsgBox m = new MsgBox();
                m.txtmsg.Text = "Projet est supprimer ";
                m.buttonOk.Hide();
                m.Show();
                m.timer();
                this.Hide();
                // MessageBox.Show("Projet est supprimer ", "Projet", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
            {
                MsgBox m = new MsgBox();
                m.txtmsg.Text = "Projet non Supprimer";
                m.picturemsg.Image = Resources.comp_3;
                m.buttonOk.Hide();
                m.Show();
                m.timer();

            }
         
        }

      
        public void Supprimerprojet()
        {

            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "Delete from Projet where id_projet=" + id + ";";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            if (cnx.State == ConnectionState.Open)
                cnx.Close();
            cnx.Open();
         
                if (cmd.ExecuteNonQuery() == 1)
                {
                
                }
                else
                {
                    MessageBox.Show("ERROR");
                }
          
        }
        
        private void linkTerminer_Click(object sender, EventArgs e)
        {

            Panel p = this.Parent as Panel;

            if (p != null)
            {

                TacheProjetTerminer myForm = new TacheProjetTerminer(id, idUti);

                myForm.TopLevel = false;
                myForm.AutoScroll = true;
                p.Controls.Add(myForm);
                myForm.Show();
                myForm.BringToFront();

                this.Close();
            }
            
           
           

        }

        private void linkTerminer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBoxStatut_SelectedIndexChanged(object sender, EventArgs e)
        {
            string statut = comboBoxStatut.Text;
            if(statut.Equals("A faire"))
            {
                flowLayoutPanel1.Controls.Clear();
                listTacheAfaire();
            }else if(statut.Equals("En cours"))
            {
                flowLayoutPanel1.Controls.Clear();
                listTacheEnCours();
            }
            else if (statut.Equals("En retard"))
            {
                flowLayoutPanel1.Controls.Clear();
                listTacheEnretard();
            }else if(statut.Equals("Terminer"))
            {
                flowLayoutPanel1.Controls.Clear();
                listTacheTerminer();

            }
            else
            {
                flowLayoutPanel1.Controls.Clear();
                listTache();

            }
           
        }
    }
}
