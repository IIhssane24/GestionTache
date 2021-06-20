using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GestionTâche
{
    public partial class ConnectionString : Form
    {
        public ConnectionString()
        {
            InitializeComponent();
        }

        private void ConnectionString_Load(object sender, EventArgs e)
        {

              //cboServer.Items.Add(".");
             // cboServer.Items.Add("(local)");
            cboServer.Items.Add(@".");
            cboServer.Items.Add(string.Format(@"{0}", Environment.MachineName));
            cboServer.Items.Add(string.Format(@"{0}\SQLEXPRESS", Environment.MachineName));
            cboServer.SelectedIndex = 1;


        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            //C:\Users\hp\source\repos\GestionTâche\db.ini
            var connectionString = String.Format("Data Source={0};Initial Catalog={1};Integrated Security=True", cboServer.Text, txtDatabase.Text);
            try
            {
                SqlServer sqlS = new SqlServer(connectionString);
                if (sqlS.IsConnection)
                {
                    
                    AppSetting setting = new AppSetting();
                    setting.SaveConnectionString("cnxSqlServer",connectionString);
                    // MessageBox.Show(" La Connexion est bien établie", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    
                    this.Hide();

                    Authentification au = new Authentification();
                    au.Show();
                    
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
