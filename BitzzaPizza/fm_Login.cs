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
    public partial class fm_Login : Form
    {
        public fm_Login()
        {
            InitializeComponent();
        }

        private void bbtn_ingresar_Click(object sender, EventArgs e)
        {
            if (UsuariosLoginHelper.AutenticarUsuario(btxt_usuario.Text, btxt_contrasena.Text))
            {
                this.Hide();
                fm_Main Main = new fm_Main(btxt_usuario.Text);
                Main.Show();
            }
            else
            {
                fm_ErrLogin errLogin = new fm_ErrLogin();
                errLogin.Show();
            }
        }

        private void bcb_verCont_CheckedChanged(object sender, Bunifu.UI.WinForms.BunifuCheckBox.CheckedChangedEventArgs e)
        {
            if (bcb_verCont.Checked || btxt_contrasena.Text == "")
            {
                btxt_contrasena.UseSystemPasswordChar = false;
            }
            else
                btxt_contrasena.UseSystemPasswordChar = true;
        }

        private void bib_cerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
