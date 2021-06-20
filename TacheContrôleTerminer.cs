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
namespace GestionTâche
{
    public partial class TacheContrôleTerminer : UserControl
    {
        public TacheContrôleTerminer()
        {
            InitializeComponent();
        }
        string connectionString = ConfigurationManager.ConnectionStrings["cnxSqlServer"].ConnectionString;
        private string _titre;
        private int idProjet;
        private int _id;//id tache

        public TacheContrôleTerminer(int p)
        {
            InitializeComponent();;
            this.idProjet = p;
        }
        public string Title
        {
            get { return _titre; }
            set { _titre = value; txtTitre.Text = value; }

        }
        public int ID
        {
            get { return _id; }
            set { _id = value; txtId.Text = value.ToString(); }

        }

        private void TacheContrôleTerminer_Load(object sender, EventArgs e)
        {
            txtId.Hide();
        }

        private void btnNonTer_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection cnx = new SqlConnection();
                cnx.ConnectionString = connectionString;
                
                String Query = "update journalisation set Terminer=0 where id_Tache=" + _id + ";";
                SqlCommand cmd = new SqlCommand(Query, cnx);
                if (cnx.State == ConnectionState.Open)
                    cnx.Close();
                cnx.Open();


                if (cmd.ExecuteNonQuery() == 1)
                {
                   
                    MsgBox m = new MsgBox();
                    m.txtmsg.Text = "Tâche Non Terminer ";
                    m.buttonOk.Hide();
                    m.picturemsg.Image = Resources.NonTerminer;
                    m.Show();
                    m.timer();
                    //MessageBox.Show("Tâche Non Terminer ", "Tâche", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
