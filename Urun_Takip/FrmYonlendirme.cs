using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Urun_Takip
{
    public partial class FrmYonlendirme : Form
    {
        public FrmYonlendirme()
        {
            InitializeComponent();
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            FrmUrun fr = new FrmUrun();
                fr.Show();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            Frmİstatistik frist = new Frmİstatistik();
            frist.Show();
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            FrmGrafikler frmgrf = new FrmGrafikler();
            frmgrf.Show();
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            FrmAdmin fradm = new FrmAdmin();
            fradm.Show();
        }
    }
}
