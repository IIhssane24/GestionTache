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
    public partial class StatistiqueControl : UserControl
    {
        public StatistiqueControl()
        {
            InitializeComponent();
        }
        private string _taux;
        private void StatistiqueControl_Load(object sender, EventArgs e)
        {

        }
        public string Taux
        {
            get { return _taux; }
            set { _taux = value; tauxTache.Text = value; }

        }
    }
}
