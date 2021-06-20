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
namespace GestionTâche
{
    public partial class MessageControl1 : UserControl
    {
        public MessageControl1()
        {
            InitializeComponent();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;
        public int idU;
        public int idM;
        public string _email;
        public string _TitreM;
        private string _date;
        private string _tache;
        private Color _iconBack;
        private string textM;//richTextBox1
        public MessageControl1(int idu,int idm)
        {
            InitializeComponent();
            this.idU = idu;
            this.idM = idm;
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; txtEmail.Text = value; }

        }
        public string TextM
        {
            get { return textM; }
            set { textM = value; richTextBox1.Text = value; }

        }
        public string TitreMessage
        {
            get { return _TitreM; }
            set { _TitreM = value;titreMessage.Text = value; }

        }
        public string DateT
        {
            get { return _date; }
            set { _date = value; txtDate.Text = value; }

        }
        public string TacheT
        {
            get { return _tache; }
            set { _tache = value; txtTache.Text = value; }

        }
       public Color IconBackground
      {
         get { return _iconBack; }
         set { _iconBack = value; panel2.BackColor= value; }

       }
        private void MessageControl1_Load(object sender, EventArgs e)
        {
            //txtIdMessage.Hide();
          
            
        }

        private void txtDate_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;

                String Query = "update MessageU set etat=1 where id_Message=" + idM + ";";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                if (cnx.State == ConnectionState.Open)
                    cnx.Close();
                cnx.Open();


                if (cmd.ExecuteNonQuery() == 1)
                {
                   MsgBox m = new MsgBox();
                    m.txtmsg.Text = "Message vu";
                    m.buttonOk.Hide();
                    m.timer();
                    m.Show();

                    this.Hide();



                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;

                String Query = "Delete from MessageU  where id_Message=" + idM + ";";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                if (cnx.State == ConnectionState.Open)
                    cnx.Close();
                cnx.Open();
                
             
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MsgBox m = new MsgBox();
                    m.txtmsg.Text = "Message supprimer";
                    m.buttonOk.Hide();
                    m.timer();
                    m.Show();
               
                    this.Hide();



                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
              
            }
        }

        private void titreMessage_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtTache_Click(object sender, EventArgs e)
        {

        }

        private void titreMessage_Click_1(object sender, EventArgs e)
        {

        }
    }
}
