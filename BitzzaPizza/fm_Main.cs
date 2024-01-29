using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;

namespace BitzzaPizza
{
    public partial class fm_Main : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;
                return cp;
            }
        }

        public fm_Main(string nombre)
        {
            InitializeComponent();
            AbrirFormulario(new fm_Inicio(nombre));
            blb_nombre.Text = nombre;
        }

        private Form formActivo = null;

        private void AbrirFormulario(Form form)
        {
            if (formActivo != null)
                formActivo.Close();

            formActivo = form;
            form.TopLevel = false;
            form.Dock = DockStyle.Fill;
            pn_principal.Controls.Add(form);
            pn_principal.Tag = form;
            form.BringToFront();
            form.Show();
        }

        private void bbtn_inicio_Click(object sender, EventArgs e)
        {
            bpn_iden.Location = new Point(3, 146);
            AbrirFormulario(new fm_Inicio(blb_nombre.Text));
        }

        private void bbtn_menu_Click(object sender, EventArgs e)
        {
            bpn_iden.Location = new Point(3, 194);
            AbrirFormulario(new fm_Menu());
        }

        private void bbtn_ventas_Click(object sender, EventArgs e)
        {
            bpn_iden.Location = new Point(3, 242);
            AbrirFormulario(new fm_Caja());
        }

        private void bbtn_ganancias_Click(object sender, EventArgs e)
        {
            bpn_iden.Location = new Point(3, 290);
            AbrirFormulario(new fm_Ganancias());
        }

       
        private void bib_logout_Click(object sender, EventArgs e)
        {
            fm_logout logout = new fm_logout();
            logout.Show();
        }
    }
}
