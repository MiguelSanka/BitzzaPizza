using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BitzzaPizza
{
    public partial class fm_ErrLogin : Form
    {
        public fm_ErrLogin()
        {
            InitializeComponent();
        }

        private void bbtn_ok_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bib_cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
