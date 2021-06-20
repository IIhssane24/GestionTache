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
using GestionTâche.Properties;
using System.Net;
using System.Net.Mail;
namespace GestionTâche
{
    public partial class TacheContrôle : UserControl
    {
        public TacheContrôle()
        {
            InitializeComponent();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;
        private string _titre;
        private int idProjet;
        private int _id;//id tache
        public int IDUliCon;//id d'utilisateur connecter
        private string _utilisAttribu;
        private string _utilisateurCree;
        private string _titreProjet;
       // private string _eti;
        private string _date;
        public TacheContrôle(int a, int p)
        {
            InitializeComponent();
            this.IDUliCon = a;
            this.idProjet = p;
        }
        public TacheContrôle(int a)
        {
            InitializeComponent();
            this.IDUliCon = a;
       
        }

        public string Title
        {
            get { return _titre; }
            set { _titre = value; txtTitre.Text = value; }

        }
        public string Date
        {
            get { return _date; }
            set { _date = value; txtdate.Text = value; }

        }
      
        public string TitreProjet
        {
            get { return _titreProjet; }
            set { _titreProjet = value; txtProjet.Text = value; }

        }
        public string AttribuéA
        {
            get { return _utilisAttribu; }
            set { _utilisAttribu = value; labelAttr.Text = value; }

        }
       
        public string CreePar
        {
            get { return _utilisateurCree; }
            set { _utilisateurCree = value; labelCree.Text = value; }

        }
        public int ID
        {
            get { return _id; }
            set { _id = value; IdTach.Text = value.ToString(); }

        }
     


        private void TacheContrôle_Load(object sender, EventArgs e)
        {
            IdTach.Hide();
        }

        private void panelGreen_MouseEnter(object sender, EventArgs e)
        {
           // panelGreen.BackColor=Color.FromArgb(0, 158, 15);
        }

        

     

        private void IdTach_Click(object sender, EventArgs e)
        {

        }

        public void btnTerminer_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;

                String Query = "update journalisation set Terminer=1 where id_Tache=" + _id + ";";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                if (cnx.State == ConnectionState.Open)
                    cnx.Close();
                cnx.Open();


                if (cmd.ExecuteNonQuery() == 1)
                {
                        MsgBox m = new MsgBox();
                        m.txtmsg.Text = "Tâche terminer ";
                        m.buttonOk.Hide();
                        m.picturemsg.Image = Resources.terminerS;
                        m.Show();
                        m.timer();
                   
                  //  MessageBox.Show("Tâche terminer ", "Tâche", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                   
                    

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }



        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTitre_Click(object sender, EventArgs e)
        {

        }

        private void tacehToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aFaireToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
              
                string Date = DateTime.Now.ToString("yyyy-MM-dd");
                String Query = "update journalisation set Etiquette='A faire' where id_Tache=" + _id + ";";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                cnx.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {


                    tacehToolStripMenuItem.Image = Resources.pin;


                }





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void enCoursToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;

                string Date = DateTime.Now.ToString("yyyy-MM-dd");
                String Query = "update journalisation set Etiquette='En cours' where id_Tache=" + _id + ";";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                cnx.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {


                    tacehToolStripMenuItem.Image = Resources.solutions;


                }





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void enRetardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EnRetard();
        }

        public void EnRetard()
        {

            try
            {
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;

                string Date = DateTime.Now.ToString("yyyy-MM-dd");
                String Query = "update journalisation set Etiquette='En retard' where id_Tache=" + _id + ";";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                cnx.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {


                    tacehToolStripMenuItem.Image = Resources.timer;


                }





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ModifierMenuItem1_Click(object sender, EventArgs e)
        {
           

            

                Form fc = Application.OpenForms["ModifierTache"];

                if (fc != null)
                    fc.Close();
                Panel p = this.Parent.Parent.Parent as Panel;
            if (p != null)
            {
                fc = new ModifierTache(_id, IDUliCon,idProjet);

                fc.TopLevel = false;
                fc.AutoScroll = true;
                p.Controls.Add(fc);
                fc.Show();
                fc.BringToFront();
               

            }
        }

        private void txtdate_Click(object sender, EventArgs e)
        {

        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Vous Voulez supprimer cette Tâche", "Vérifier la suppression", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);


            try
            {
                
               
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                String Query = " DELETE FROM Journalisation where id_Tache='" + _id + "';";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                cnx.Open();
                if (result == DialogResult.OK)
                {

                    if (cmd.ExecuteNonQuery() == 1)
                    {

                        EnvoyerEmail(_utilisAttribu, " A Supprimer La Tache " + _titre + " de projet" + _titreProjet);

                        supprimerTacheStatut();
                        supprimerTacheMessage();
                        supprimerTache();
                        MsgBox m = new MsgBox();
                        m.txtmsg.Text = "Tâche  supprimer ";
                        m.buttonOk.Hide();
                        m.Show();
                        m.timer();
                        this.Hide();

                    }

                }
                else
                {
                    MsgBox m = new MsgBox();
                    m.txtmsg.Text = "Tâche non Supprimer";
                    m.picturemsg.Image = Resources.comp_3;
                    m.buttonOk.Hide();
                    m.Show();
                    m.timer();
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void supprimerTacheStatut()
        {
            try
            {

                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                String Query = " DELETE FROM Statut where id_Tache='" +_id+ "';";
                cnx.Open();
                SqlCommand cmd = new SqlCommand(Query, cnx);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void supprimerTacheMessage()
        {
            try
            {

                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                String Query = "Delete from MessageU where tache='" + _id + "';";
                cnx.Open();
                SqlCommand cmd = new SqlCommand(Query, cnx);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void supprimerTache()
        {
            try
            {

                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                String Query = " DELETE FROM Tache where id_Tache='" +_id+ "';";
                cnx.Open();
                SqlCommand cmd = new SqlCommand(Query, cnx);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void EnvoyerEmail(string email, string msg)
        {
            try
            {
                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("ihssaneihssanita89@gmail.com");
                    mail.To.Add(email);
                    mail.Subject = "Supprimer Tache";
                    mail.Body = "<h4 color=blue> " + MailUtiliConn(IDUliCon) + " </h4><h4>" + msg + "</h4><br><h5 color=blue> Tache " +_titre + " de PROJET " +_titreProjet + " </h5>";
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
    }
}
