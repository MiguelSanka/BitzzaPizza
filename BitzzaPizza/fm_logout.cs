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
    public partial class fm_logout : Form
    {
        public fm_logout()
        {
            InitializeComponent();
        }

        private void bbtn_no_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bib_cerrar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void bbtn_si_Click(object sender, EventArgs e)
        {
            foreach(Form form in Application.OpenForms)
            {
                form.Hide();
            }
            fm_Login login = new fm_Login();
            login.Show();

        }
    }
}
