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
    public partial class ListProjet : UserControl
    {
        public ListProjet()
        {
            InitializeComponent();
        }

        #region Properties
        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;
        private int count;
        
        private string _title;
       ///private string _descr;
        public int _id;//id projet
      //  private Color _iconBack;
        public int IDU;
        public ListProjet(int us)
        {
            InitializeComponent();
            this.IDU = us;
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; txtTitre.Text = value; }

        }
  
        public int ID
        {
            get { return _id; }
            set { _id = value; idProjet.Text =value.ToString(); }

        }
        /*public Color IconBackground
        {
            get { return _iconBack; }
            set { _iconBack = value; panel2.BackColor= value; }

        }*/






        #endregion

      public void Taux()
        {
            int total = TauxTacheP();
           
           int a;
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "select count(*) from Projet INNER join Statut ON Projet.id_projet=Statut.id_projet INNER JOIN journalisation ON Statut.id_Tache=journalisation.id_Tache Where Projet.id_projet="+_id+" and journalisation.Terminer=1; ";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    if (rd[0] != DBNull.Value)
                        count = (int)rd[0];
                }

                cnx.Close();
            }
            else
            {

                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (total == 0)
            {
                a = (count * 100) / 1;
            }
            else
            {
                a = (count*100)/total;
            }
            progressBar1.Value = a;
            txtProgress.Text = count + "/" +total;
            if (progressBar1.Value == 100)
            {
                //MessageU();
                //EnvoyerEmail();
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
        public void EnvoyerEmail()
        {
                try
                {
                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("ihssaneihssanita89@gmail.com");
                        mail.To.Add(MailUtiliConn(IDU));
                        mail.Subject = "Projet Terminer";
                        mail.Body = "<table><tr><th style='background-color:#ADD8E6'>LE Projet</th><th>" +_title+ "  Est Terminer</th></tr></table>";
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
        public void MessageU()
        {
            string date = DateTime.Now.ToString("yyyy-MM-dd");
            try
            {
                using (SqlConnection cnx = new SqlConnection(connectionString))
                {

                    String Query = " insert into MessageU (titreM,DetailsMsg,dateM,etat ) VALUES ('Projet Terminer','" +_title+ "','" + date + "',0);";
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
        public int TauxTacheP()
        {
            int tauxTache=1;
           SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "select count(*) from Projet INNER join Statut ON Projet.id_projet=Statut.id_projet Where Projet.id_projet=" + _id + "; ";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    if (rd[0] != DBNull.Value)
                        tauxTache = (int)rd[0];
                    
                }
                cnx.Close();
                return tauxTache;
            }
            else
            {

                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return tauxTache;
        }

        private void ListProjet_Load(object sender, EventArgs e)
        {
            idProjet.Hide();
            Taux();
            progressBar1.BackColor = Color.Red;

        }

        public void ListProjet_Click(object sender, EventArgs e)
        {
          
            Form fc = Application.OpenForms["TacheProjet"];

            if (fc != null)
                fc.Close();
            Panel p = this.Parent.Parent.Parent as Panel;
            if (p != null)
            {
                fc = new TacheProjet(ID, IDU);

                fc.TopLevel = false;
                fc.AutoScroll = true;
                p.Controls.Add(fc);
                fc.Show();
                fc.BringToFront();


            }


        }

        private void txtTitre_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void modifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ModifierProjet a = new ModifierProjet();
            Form fc = Application.OpenForms["ModifierProjet"];

            if (fc != null)
                fc.Close();
            Panel p = this.Parent.Parent.Parent as Panel;
            if (p != null)
            {
                fc = new ModifierProjet(ID,IDU);

                fc.TopLevel = false;
                fc.AutoScroll = true;
                p.Controls.Add(fc);
                fc.Show();
                fc.BringToFront();


            }
        }
        public void Supprimerprojet()
        {

            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "Delete from Projet where id_projet=" +ID+ ";";
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
        private void supprimerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Vous Voulez supprimer ce Projet", "Vérifier la suppression", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "Delete from Statut where id_projet=" +ID+ ";";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            if (cnx.State == ConnectionState.Open)
                cnx.Close();
            cnx.Open();

            if (result == DialogResult.OK)
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
    }
    public static class ModifyProgressBarColor
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
        static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
        public static void SetState(this ProgressBar pBar, int state)
        {
            SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
        }
    }
}
