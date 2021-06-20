using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionTâche
{
    public partial class Tache : UserControl
    {
        public Tache()
        {
            InitializeComponent();
        }
        public int idUti;
        private string titreT;
        private string titreP;
        private string terminer;
        private string mailCr;
        private string _change;
        public Tache(int idU)
        {
            InitializeComponent();
            this.idUti = idU;
        }
      
             public string Change
           {
            get { return _change; }
            set { _change = value; txtchange.Text = value; }
           }
        public string TitreT
        {
            get { return titreT; }
            set { titreT = value; txtTitreT.Text = value; }

        }
        public string MailCree
        {
            get { return mailCr; }
            set { mailCr = value;txtCree.Text = value;}

        }
        public string TitreP
        {
            get { return titreP; }
            set { titreP = value; txtTitreP.Text = value; }

        }
        public string Terminer
        {
            get { return terminer; }
            set { terminer = value; txtTerminer.Text = value; }

        }
        private void Tache_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
