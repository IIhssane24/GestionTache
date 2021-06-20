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
using GestionTâche.Properties;
namespace GestionTâche
{
    public partial class MembresContrôle : UserControl
    {
        public MembresContrôle()
        {
            InitializeComponent();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;

        public int idU;
        private string _email;
        private string _nomPre;
        private string _role;
        public string role;
        public int idConnect;
        public MembresContrôle(int idUC,int id)
        {
            InitializeComponent();
            this.idU = id;
            this.idConnect=idUC;
        }



        public string Email
        {
            get { return _email; }
            set { _email = value; emailMembre.Text = value; }

        }
        public string NomPrenom
        {
            get { return _nomPre; }
            set { _nomPre = value; NomPr.Text = value; }

        }
        public string Role
        {
            get { return _role; }
            set { _role = value; txtRole.Text = value; }

        }
        private void MembresContrôle_Load(object sender, EventArgs e)
        {
            RoleR();
            if (!(role.Equals("Responsable")))
            {
                menuStripMembre.Hide();

            }
        }

        private void NomPr_Click(object sender, EventArgs e)
        {

        }

        private void emailMembre_Click(object sender, EventArgs e)
        {

        }
        public void RoleR()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "  select Rôle.TitreR  from Rôle INNER JOIN Utilisateur ON Utilisateur.id_role=Rôle.id_role where Utilisateur.id_Utilisateur=" +idConnect+ "; ";
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
        private void MembresContrôle_Click(object sender, EventArgs e)
        {
           
           Form fc = Application.OpenForms["TacheMembre"];

            if (fc != null)
                fc.Close();
            Panel p = this.Parent.Parent.Parent.Parent as Panel;
            if (p != null)
            {
                fc = new TacheMembre(idU);

                fc.TopLevel = false;
                fc.AutoScroll = true;
                p.Controls.Add(fc);
                fc.Show();
                fc.BringToFront();


            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
          

            Form fc = Application.OpenForms["ModifierRole"];

            if (fc != null)
                fc.Close();
            Panel p = this.Parent.Parent.Parent.Parent as Panel;
            if (p != null)
            {
                fc = new ModifierRole(idConnect, idU);

                fc.TopLevel = false;
                fc.AutoScroll = true;
                p.Controls.Add(fc);
                fc.Show();
                fc.BringToFront();

                
            }


          
        }

        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Vous Voulez supprimer ce Utilisateur", "Vérifier la suppression", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            try
            {


                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                String Query = "Delete from journalisation where id_Utilisateur_aff="+idU + " or id_Utilisateur_Crée=" +idU+ ";";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                cnx.Open();
                if (result == DialogResult.OK)
                {

                    if (cmd.ExecuteNonQuery() >= 0)
                    {

                        supprimerUtilisateurMessage();
                        supprimerUtilisateur();

                       
                        MsgBox m = new MsgBox();
                        m.txtmsg.Text = "Utilisateur Supprimer";
                        m.buttonOk.Hide();
                        m.Show();
                        m.timer();
                       // MessageBox.Show("Utilisateur Supprimer ");
                        this.Hide();
                        EnvoyerEmail(_email, " A Supprimer vous ");

                    }
                }
                else
                {
                    MsgBox m = new MsgBox();
                    m.txtmsg.Text = "Utilisateur non Supprimer";
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
        public void supprimerUtilisateur()
        {
            try
            {

                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                String Query = "Delete from Utilisateur where id_Utilisateur='" +idU+ "';";
                cnx.Open();
                SqlCommand cmd = new SqlCommand(Query, cnx);

                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void supprimerUtilisateurMessage()
        {
            try
            {

                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                String Query = " Delete from MessageU where envoyerPar="+idU+" or attribuerA=" +idU+ ";";
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
                    mail.Subject = "Retirer de groupe";
                    mail.Body = "<h4 color=blue> " + MailUtiliConn(idConnect) + " </h4><h4>" + msg + "</h4><br>";
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

