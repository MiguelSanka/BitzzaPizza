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
    public partial class fm_Inicio : Form
    {
        public fm_Inicio(string nombre)
        {
            InitializeComponent();
            blb_hola.Text = "!Hola, " + nombre + "¡";
        }
    }
}
