using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
using GestionTâche.Properties;
namespace GestionTâche
{
    public partial class Acceuil : Form
    {
        public Acceuil()
        {
            InitializeComponent();

        }
        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;
        public int id;//id Utilisateur
        public string role;
        string TextT;
        private void labelClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Acceuil(int idU)
        {
            InitializeComponent();
            this.id = idU;
        }

        private void labelClose_MouseEnter(object sender, EventArgs e)
        {

        }

        private void labelClose_MouseLeave(object sender, EventArgs e)
        {

        }
        public void TacheEnRetard()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            DateTime t;
            int totalT=0; 
            String Query = "SELECT Tache.id_Tache , Tache.TitreT,Tache.Echéance From Tache INNER JOIN Journalisation ON Tache.id_Tache = journalisation.id_Tache INNER JOIN Utilisateur ON journalisation.id_Utilisateur_Crée=Utilisateur.id_Utilisateur where journalisation.id_Utilisateur_aff = " + id+ " and journalisation.Terminer=0 ; ";
     
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();
            MsgBox m = new MsgBox();
            m.MdiParent = this;
            panel1.Controls.Add(m);
        
            if (rd.HasRows)
            {

                while (rd.Read())
                {
                        t=(DateTime)rd[2];
                    if (DateTime.Now > t) { 
                        totalT = totalT + 1;
                        TextT = (string)rd[1] + "," + TextT;
                        m.txtmsg.Text = totalT + " Tache en Retard : " + TextT;
                        m.picturemsg.Image = Resources.Alarm;
                        m.Show();
                        m.timer_display.Stop();
                    }
                  
                }
                m.BringToFront();
                cnx.Close();
            }




        }
        private void Acceuil_Load(object sender, EventArgs e)
        {
            UtilisateurConnecter();
            TacheEnRetard();
            Role();
            if (!(role.Equals("Responsable")))
            {
                ajouterProjetToolStripMenuItem.Visible = false;
                ajouterMembreToolStripMenuItem.Visible = false;
              
            }
            if(!(role.Equals("Responsable")||role.Equals("chef de projet"))){

                membresToolStripMenuItem.Visible = false;



            }
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "select *from MessageU where attribuerA='" + id+ "'  and etat=0 ;";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
                btnMessage.Image = Resources.msg;

                cnx.Close();
            }
            else
            {
               btnMessage.Image = Resources.notifi;
            }

        }




        public void UtilisateurConnecter()
        {
            int idP = id;
            string h;
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "select Nom,Prenom,Mail from Utilisateur where id_Utilisateur='" + idP + "';";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    if (rd[0] != DBNull.Value || rd[1] != DBNull.Value)
                    {
                        h = (string)rd[0] + " " + (string)rd[1];
                        labelUti.Text = h.ToUpper();
                    }
                    else
                    {
                        labelUti.Text = (string)rd[2];
                    }
                    
                    
                }
                cnx.Close();
            }
            else
            {
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }







        private void projetsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {


             
            Form fc = Application.OpenForms["Projet"];

            if (fc != null)
                fc.Close();
            fc = new Projet(id);
            fc.MdiParent = this;
            this.panel1.Controls.Add(fc);
            fc.Show();
            fc.BringToFront();

        }
      
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void terminerToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void ajouterProjetToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Form fc = Application.OpenForms["AjouterProjet"];

            if (fc != null)
                fc.Close();
            fc = new AjouterProjet(id);
            fc.MdiParent = this;
            this.panel1.Controls.Add(fc);
            fc.Show();
            fc.BringToFront();

                
             
            
        }

        private void ajouterTâcheToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fc = Application.OpenForms["AjouterTache"];

            if (fc != null)
                fc.Close();
            fc = new AjouterTache(id); 
            fc.MdiParent = this;
            this.panel1.Controls.Add(fc);
            fc.Show();
            fc.BringToFront();



        
            
        }

        private void mesTâcheToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void membresToolStripMenuItem_Click(object sender, EventArgs e)
        {


            Form fc = Application.OpenForms["Membres"];

            if (fc != null)
            fc.Close();
            fc = new Membres(id);
            fc.MdiParent = this;
            this.panel1.Controls.Add(fc);
            fc.Show();
            fc.BringToFront();
           



        }

        private void déconnexionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Authentification a = new Authentification();
            a.Show();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
 
        }

        private void ajouterMembreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form fc = Application.OpenForms["AjouterMembre"];

            if (fc != null)
                fc.Close();
            fc = new AjouterMembre(id);
            fc.MdiParent = this;
            this.panel1.Controls.Add(fc);
            fc.Show();
            fc.BringToFront();

       
        }

        private void terminerToolStripMenuItem_Click(object sender, EventArgs e)
        {
                terminerToolStripMenuItem.Checked = true;
            
            Form fc = Application.OpenForms["MesTache"];

            if (fc != null)
                fc.Close();
            fc = new MesTache(id);
            fc.MdiParent = this;
            this.panel1.Controls.Add(fc);
            fc.Show();
            fc.BringToFront();


            
        }

   

        private void statistiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnMessage.Image = Resources.notifi;

            Form fc = Application.OpenForms["Messages"];

            if (fc != null)
                fc.Close();
            fc = new Messages(id);
            fc.MdiParent = this;
            this.panel1.Controls.Add(fc);
            fc.Show();
            fc.BringToFront();

       

        }

        private void btnEnvoyer_Click(object sender, EventArgs e)
        {


            Form fc = Application.OpenForms["EnvoyerMessage"];

            if (fc != null)
                fc.Close();
            fc = new EnvoyerMessage(id);
            fc.MdiParent = this;
            this.panel1.Controls.Add(fc);
            fc.Show();
            fc.BringToFront();

           
        }

        private void statistiqueToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Form fc = Application.OpenForms["Statistique"];

            if (fc != null)
                fc.Close();
            fc = new Statistique(id);
            fc.MdiParent = this;
            this.panel1.Controls.Add(fc);
            fc.Show();
            fc.BringToFront();

        }

        public void Role()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "  select Rôle.TitreR  from Rôle INNER JOIN Utilisateur ON Utilisateur.id_role=Rôle.id_role where Utilisateur.id_Utilisateur="+id+"; ";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    if(rd[0]!=DBNull.Value)
                    role = (string)rd[0];
                }
                cnx.Close();
            }
            else
            {
               
                MessageBox.Show("Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ProfiletoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form fc = Application.OpenForms["Profile"];

            if (fc != null)
                fc.Close();
            fc = new Profile(id);
            fc.MdiParent = this;
            this.panel1.Controls.Add(fc);
            fc.Show();
            fc.BringToFront();

           
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelUti_Click(object sender, EventArgs e)
        {

        }

        private void planningToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
            Form fc = Application.OpenForms["CalendarT"];

            if (fc != null)
                fc.Close();
            fc = new CalendarT(id);
            fc.MdiParent = this;
            this.panel1.Controls.Add(fc);
            fc.Show();
            fc.BringToFront();

        }
    }
}
