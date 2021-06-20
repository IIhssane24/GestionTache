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
    public partial class CalendarT : Form
    {
        public CalendarT()
        {
            InitializeComponent();
            this.CenterToScreen();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;
        int idUti;
        string role;
        private List<FlowLayoutPanel> listFlDay = new List<FlowLayoutPanel>();
        private DateTime currentDate = DateTime.Today;
       public  Panel a = new Panel();
        public CalendarT(int id)
        {
            InitializeComponent();
            this.idUti = id;
            this.CenterToScreen();
        }
        static readonly CancellationTokenSource s_cts = new CancellationTokenSource();
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr one, int two, int three, int four);
        private void CalendarT_Load(object sender, EventArgs e)
        {
            GenerateDayPanel(42);
            DisplayCurrentDate();
            comboBoxetat.SelectedIndex = 0;
            Role();
            if (!(role.Equals("Responsable")|| role.Equals("chef de projet")))
            {
                comboBoxetat.Hide();

            }

        }
        public void Role()
        {
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            String Query = "  select Rôle.TitreR  from Rôle INNER JOIN Utilisateur ON Utilisateur.id_role=Rôle.id_role where Utilisateur.id_Utilisateur=" +idUti+ "; ";
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
        private void AddApointementToFlDays(int startDayAtFlNumber)
        {
            string P;
            DateTime startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            DateTime ech, cr = new DateTime();
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            
            String Query = "select Tache.id_Tache,Tache.TitreT,Tache.Echéance,Tache.DateCreation ,journalisation.Terminer from Tache INNER JOIN journalisation ON Tache.id_Tache=journalisation.id_Tache where Tache.Echéance  between '" + startDate.ToShortDateString()+"' and '"+endDate.ToShortDateString()+ "' and journalisation.Terminer=0 ;";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {
               
                while (rd.Read())
                {
                    ech = (DateTime)rd[2];
                    cr = (DateTime)rd[3];
                    

                    DateTime appDay = (DateTime)rd[2];

                    bool t = (bool)rd[4];

                    //Microsoft Sans Serif; 8,25pt; style=Bold
                    LinkLabel link = new LinkLabel();
                    link.Font = new Font("Microsoft Sans Serif",7,FontStyle.Bold);
                    link.Name = "link" + (int)rd[0];
                    link.Tag=(int)rd[0];
                    link.Cursor = Cursors.Hand;
                    link.Click += GetDetailsTache;
                    P= (string)rd[1];
                    P = P.Substring(0, 3);
                    link.Text = P + "..";
                    link.Width=95;
                    if (DateTime.Now < ech || ((DateTime.Now - ech).Days) == 0)
                    {
                        link.LinkColor = Color.Black;
                        link.BackColor = Color.Aqua;
                    }
                    else
                    {
                        link.LinkColor = Color.Black;
                        link.BackColor = Color.Coral;

                    }
               
                    
                    listFlDay[(appDay.Day-1) + (startDayAtFlNumber - 1)].Controls.Add(link);
                }
                cnx.Close();
            }
        }
        private void AddApointementToFlDaysUtili(int startDayAtFlNumber)
        {
            string P;
            DateTime startDate = new DateTime(currentDate.Year, currentDate.Month, 1);
            DateTime endDate = startDate.AddMonths(1).AddDays(-1);
            DateTime ech, cr = new DateTime();
            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
       
            String Query = "select Tache.id_Tache,Tache.TitreT,Tache.Echéance,Tache.DateCreation ,journalisation.Terminer from Tache INNER JOIN journalisation ON Tache.id_Tache=journalisation.id_Tache INNER JOIN Utilisateur ON journalisation.id_Utilisateur_aff=Utilisateur.id_Utilisateur where Tache.Echéance  between '" + startDate.ToShortDateString() + "' and '" + endDate.ToShortDateString() + "' and journalisation.id_Utilisateur_aff="+idUti+ " and journalisation.Terminer=0 ;";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    ech = (DateTime)rd[2];
                    cr = (DateTime)rd[3];


                    DateTime appDay = (DateTime)rd[2];

                    bool t = (bool)rd[4];

                    //Microsoft Sans Serif; 8,25pt; style=Bold
                    LinkLabel link = new LinkLabel();
                    link.Font = new Font("Microsoft Sans Serif", 7, FontStyle.Bold);
                    link.Name = "link" + (int)rd[0];
                    link.Tag = (int)rd[0];
                    link.Cursor = Cursors.Hand;
                    link.Click += GetDetailsTache;
                    P = (string)rd[1];
                    P = P.Substring(0, 4);
                    link.Text = P + "..";
                    link.Width = 95;
                    if (DateTime.Now < ech || ((DateTime.Now - ech).Days) == 0)
                    {
                        link.LinkColor = Color.Black;
                        link.BackColor = Color.Aqua;
                    }
                    else
                    {
                        link.LinkColor = Color.Black;
                        link.BackColor = Color.Coral;

                    }

                    listFlDay[(appDay.Day - 1) + (startDayAtFlNumber - 1)].Controls.Add(link);
                }
                cnx.Close();
            }
        }


        private void AjouterNouvelleTache(object sender, EventArgs e)
        {
            //int idTache = (Integer)(sender, LinkLabel).Tag;
            int day = (int)((FlowLayoutPanel)sender).Tag;
            
            if (day!= 0)
            {
                DateTime nouvelDate = new DateTime(currentDate.Year, currentDate.Month, day);
                if (DateTime.Now< nouvelDate|| ((DateTime.Now - nouvelDate).Days) == 0)
                {
                    AjouterTache t = new AjouterTache(idUti);
                    t.dateEch.Value = nouvelDate;
                    t.ShowDialog();
                    DisplayCurrentDate();
                 
                }
                else
                {
                    MsgBox m = new MsgBox();
                    m.txtmsg.Text = "Veuillez de séléctionner une date supérieure d'aujourd'hui";
                    m.picturemsg.Image = Resources.comp_3;
                    m.Show();
                    m.timer_display.Stop();

                }


            }
           
            //int idTache=(int)(((LinkLabel)sender).Tag);
            
            //Dim appID as Integer=CType(sender,LinkLabel).Tag;






        }
        public String TitreProjet(int idT)
        {


            string titreP = "";

            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;

            String Query = "select DISTINCT Projet.id_projet, Projet.Titre FROM Projet INNER JOIN Statut ON Projet.id_projet=Statut.id_projet INNER JOIN Tache ON Statut.id_Tache = Tache.id_Tache  where Tache.id_Tache =" + idT + ";";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    titreP = (string)rd[1];

                }
                cnx.Close();
            }

            return titreP;
        }
        private void GetDetailsTache(object sender, EventArgs e)
        {
            

            bool terminer;
            int idTache = (int)(((LinkLabel)sender).Tag);
            string titreProjet;
           


            SqlConnection cnx = new SqlConnection();
            cnx.ConnectionString = connectionString;
            DateTime date = new DateTime();
            String Query = "Select Tache.TitreT,Utilisateur.Mail,Tache.DateCreation ,journalisation.Terminer,journalisation.Etiquette from Tache INNER JOIN Journalisation ON Tache.id_Tache=journalisation.id_Tache INNER JOIN Utilisateur ON Utilisateur.id_Utilisateur=journalisation.id_Utilisateur_aff where Tache.id_Tache='" + idTache + "'; ";
            SqlCommand cmd = new SqlCommand(Query, cnx);
            cnx.Open();
            SqlDataReader rd = cmd.ExecuteReader();

            if (rd.HasRows)
            {

                while (rd.Read())
                {
                    TacheCalendar ta = new TacheCalendar();
                    ta.id_tache = idTache;
                    titreProjet = TitreProjet(idTache);
                   if(!(TitreProjet(idTache).Equals("")))
                    {
                        ta.txtProjet.Text = titreProjet;
                        ta.labelProjet.Visible = true;
                    }
                    else
                    {
                        ta.labelProjet.Visible=false;
                        ta.txtProjet.Visible = false;
                    }
                        

                   
                        
                    
                    ta.TxtTache.Text = (string)rd[0];
                    ta.txtMembre.Text = (string)rd[1];
                    date = (DateTime)rd[2];
                    ta.txtDate.Text = date.ToShortDateString();
                    terminer = (bool)rd[3];
                    if (terminer == true)
                    {
                        ta.txtStatut.Text = "Terminer";
                    }
                    else
                    {
                        ta.txtStatut.Text = (string)rd[4];
                    }
                    ta.ShowDialog();
                }
                cnx.Close();
            }


        }
        private void MoisAvant()
        {
            currentDate = currentDate.AddMonths(-1);
            string statut = comboBoxetat.Text;
            if (statut.Equals("Générale"))//  
            {

                DisplayCurrentDate();
            }
            else if (statut.Equals("Personnel"))
            {

                DisplayCurrentDateP();
            }
           
        }
        private void MoisApres()
        {
            currentDate = currentDate.AddMonths(1);
            string statut = comboBoxetat.Text;
            if (statut.Equals("Générale"))//  
            {

                DisplayCurrentDate();
            }
            else if (statut.Equals("Personnel"))
            {

                DisplayCurrentDateP();
            }
        }
        private void Today()
        {
            currentDate = DateTime.Today;
            string statut = comboBoxetat.Text;
            if (statut.Equals("Générale"))//  
            {

                DisplayCurrentDate();
            }
            else if (statut.Equals("Personnel"))
            {

                DisplayCurrentDateP();
            }
        }
        private void DisplayCurrentDate()
        {
            lbMoisEtAnnee.Text = currentDate.ToString("MMMM,yyyy");
            int firstDayAtFlNumber = GetFirstDayOfWeekCurrentDate();
            int totalDay = GetTotaltDayOfWeekCurrentDate();
            Role();
            AddLabelToFlDays(firstDayAtFlNumber, totalDay);
            if (role.Equals("Responsable")|| role.Equals("chef de projet"))
            {
                AddApointementToFlDays(firstDayAtFlNumber);
                TxtPlanning.Text = "Planning Générale";
            }
            else
            {
                AddApointementToFlDaysUtili(firstDayAtFlNumber);
                TxtPlanning.Text = "Planning Personnel";
                

            }
           // TEST(firstDayAtFlNumber);


        }
        private void DisplayCurrentDateP()
        {
            lbMoisEtAnnee.Text = currentDate.ToString("MMMM,yyyy");
            int firstDayAtFlNumber = GetFirstDayOfWeekCurrentDate();
            int totalDay = GetTotaltDayOfWeekCurrentDate();
            Role();
            AddLabelToFlDays(firstDayAtFlNumber, totalDay);
           
                AddApointementToFlDaysUtili(firstDayAtFlNumber);
                TxtPlanning.Text = "Planning Personnel";
               

            
            // TEST(firstDayAtFlNumber);


        }
        private int GetFirstDayOfWeekCurrentDate()
        {
            DateTime firstDayOfMonth = new DateTime(currentDate.Year, currentDate.Month, 1);
            return(int)firstDayOfMonth.DayOfWeek+1;
        }
        private int GetTotaltDayOfWeekCurrentDate()
        {
            DateTime firstDayOfCurrentDate= new DateTime(currentDate.Year, currentDate.Month, 1);
            return (int)firstDayOfCurrentDate.AddMonths(1).AddDays(-1).Day;
        }
        private void GenerateDayPanel(int totalDate)
        {
            flDays.Controls.Clear();
            listFlDay.Clear();
            int i;
            for (i = 1; i <= totalDate; i++)
            {
                FlowLayoutPanel fl = new FlowLayoutPanel();
                fl.Name = "flDay" + i;
                fl.Size = new Size(105,68);
                fl.BackColor = Color.FromArgb(216, 227, 231);
                fl.BorderStyle = BorderStyle.FixedSingle;
                fl.AutoScroll = true;
                fl.Cursor = Cursors.Hand;
                fl.Click += AjouterNouvelleTache;
                flDays.Controls.Add(fl);
                listFlDay.Add(fl);
                //105; 88
            }
        }
        private void AddLabelToFlDays(int startDay,int totalDaysInMonth)
        {
            foreach (FlowLayoutPanel fl in listFlDay)
            {
                fl.Controls.Clear();
                fl.Tag = 0;
            }

            int i;
            for (i =1; i <= totalDaysInMonth; i++)
            {
                Label lbl = new Label();
                lbl.Name = "lblDay"+i;
                lbl.AutoSize = false;
                lbl.TextAlign = ContentAlignment.MiddleRight;
                lbl.Text =i.ToString();
                lbl.Font=new Font("Microsoft Sans Serif", 8,FontStyle.Bold);
                lbl.Size = new Size(95,12);
                lbl.BringToFront();
                listFlDay[(i - 1) + (startDay - 1)].Tag= i;
                listFlDay[(i-1)+(startDay-1)].Controls.Add(lbl);
                

            }
        }

    

        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAvant_Click(object sender, EventArgs e)
        {
            MoisAvant();
        }

        private void btnSuivant_Click(object sender, EventArgs e)
        {
            MoisApres();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Today();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(Handle, 0x112, 0xf012, 0);
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

        private void label12_Click(object sender, EventArgs e)
        {
     
           

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string statut = comboBoxetat.Text;
            if (statut.Equals("Générale"))//  
            {
              
                DisplayCurrentDate();
            }
            else if (statut.Equals("Personnel"))
            {
               
                DisplayCurrentDateP();  
            }
        }

        private void flDays_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
