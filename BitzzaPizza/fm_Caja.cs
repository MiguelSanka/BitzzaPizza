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
    public partial class fm_Caja : Form
    {
        public fm_Caja()
        {
            InitializeComponent();
        }

        private float SumarColumnaDataGridView(BunifuDataGridView Tabla, int Columna)
        {
            float suma = 0;
            foreach(DataGridViewRow row in Tabla.Rows)
            {
                if(row.Cells[Columna].Value != null)
                {
                    suma += (float)row.Cells[Columna].Value;
                }
            }
            return suma;
        }

        private void AgregarySumarCompra(int IdPizza)
        {
            bool Encontrado = false;
            int NumFila = 0;
            for(int i= 0; i < bdgv_venta.Rows.Count; i++)
            {
                if(Convert.ToInt32(bdgv_venta[0,i].Value) == IdPizza)
                {
                    Encontrado = true;
                    NumFila = i;
                }
            }
            if(Encontrado == true)
            {
                bdgv_venta.Rows.RemoveAt(NumFila);
            }
  
                 PizzaTicketHelper.AgregarPizzaVenta(IdPizza, bdgv_venta, Convert.ToInt32(btxt_cantidad.Text));
                 btxt_total.Text = Convert.ToString(SumarColumnaDataGridView(bdgv_venta, 4));
                   
        }

        private void bib_pepperoni_Click(object sender, EventArgs e)
        {
            AgregarySumarCompra(1);
        }

        private void btxt_cantidad_TextChange(object sender, EventArgs e)
        {
            int n = 0;
            if (int.TryParse(btxt_cantidad.Text, out n) && btxt_cantidad.Text != "")
            {
                bib_pepperoni.Enabled = true;
                bib_hawaiina.Enabled = true;
                bib_3carnes.Enabled = true;
                bib_ranchera.Enabled = true;
                bib_mariscos.Enabled = true;
                bib_vegana.Enabled = true;
                bib_queso.Enabled = true;
                bib_napo.Enabled = true;
            }
            else
            {
                bib_pepperoni.Enabled = false;
                bib_hawaiina.Enabled = false;
                bib_3carnes.Enabled = false;
                bib_ranchera.Enabled = false;
                bib_mariscos.Enabled = false;
                bib_vegana.Enabled = false;
                bib_queso.Enabled = false;
                bib_napo.Enabled = false;
            }
        }

        private void bib_hawaiina_Click(object sender, EventArgs e)
        {
            AgregarySumarCompra(2);
        }

        private void bib_3carnes_Click(object sender, EventArgs e)
        {
            AgregarySumarCompra(3);
        }

        private void bib_ranchera_Click(object sender, EventArgs e)
        {
            AgregarySumarCompra(4);
        }

        private void bib_vegana_Click(object sender, EventArgs e)
        {
            AgregarySumarCompra(5);
        }

        private void bib_mariscos_Click(object sender, EventArgs e)
        {
            AgregarySumarCompra(6);
        }

        private void btxt_efectivo_TextChange(object sender, EventArgs e)
        {
            int n = 0;
            if (int.TryParse(btxt_efectivo.Text, out n) && btxt_efectivo.Text != "")
            {
                btxt_cambio.Text = Convert.ToString(float.Parse(btxt_efectivo.Text) - SumarColumnaDataGridView(bdgv_venta, 4));
            }
        }

        private void btxt_total_TextChange(object sender, EventArgs e)
        {
            int n = 0;
            if (int.TryParse(btxt_efectivo.Text, out n) && btxt_efectivo.Text != "")
            {
                btxt_cambio.Text = Convert.ToString(float.Parse(btxt_efectivo.Text) - SumarColumnaDataGridView(bdgv_venta, 4));
            }
        }

        private void btxt_cambio_TextChange(object sender, EventArgs e)
        {
            if (btxt_cambio.Text != "" && float.Parse(btxt_cambio.Text) >= 0)
                bbtn_comprar.Enabled = true;
            else
                bbtn_comprar.Enabled = false;
        }

        private void bbtn_comprar_Click(object sender, EventArgs e)
        {
            if(btxt_total.Text != "")
            {
                PizzaCompradaTicketHelper.EscribirListaComprar("C:/Users/Miguel Sanka/Desktop/ventas.txt", bdgv_venta,btxt_total, btxt_efectivo, btxt_cambio);
                fm_Ticket ticket = new fm_Ticket(VentaHelper.GenerarIdVenta() - 1);
                ticket.Show();
                btxt_cantidad.Clear();
                btxt_efectivo.Clear();
                btxt_cambio.Clear();
                btxt_total.Clear();
                bdgv_venta.Rows.Clear();
            }
        }

        private void bdb_listaPizzas_SelectedIndexChanged(object sender, EventArgs e)
        {
     
        }

        private void bbtn_agregar_Click(object sender, EventArgs e)
        {
            if(btxt_cantidad.Text != "")
            {
                switch (bdb_listaPizzas.SelectedIndex)
                {
                    case 0:
                        AgregarySumarCompra(1);
                        break;
                    case 1:
                        AgregarySumarCompra(2);
                        break;
                    case 2:
                        AgregarySumarCompra(3);
                        break;
                    case 3:
                        AgregarySumarCompra(4);
                        break;
                    case 4:
                        AgregarySumarCompra(5);
                        break;
                    case 5:
                        AgregarySumarCompra(6);
                        break;
                    case 6:
                        AgregarySumarCompra(7);
                        break;
                    case 7:
                        AgregarySumarCompra(8);
                        break;
                }
            }
        }

        private void bbtn_eliminar_Click(object sender, EventArgs e)
        {
            if(bdgv_venta.CurrentRow != null)
            {
                bdgv_venta.Rows.Remove(bdgv_venta.CurrentRow);
                btxt_total.Text = Convert.ToString(SumarColumnaDataGridView(bdgv_venta, 4));
            }
            
        }

        private void bbtn_cancelar_Click(object sender, EventArgs e)
        {
            btxt_cantidad.Clear();
            btxt_efectivo.Clear();
            btxt_cambio.Clear();
            btxt_total.Clear();
            bdgv_venta.Rows.Clear();
        }

        private void bib_queso_Click(object sender, EventArgs e)
        {
            AgregarySumarCompra(7);
        }

        private void bib_napo_Click(object sender, EventArgs e)
        {
            AgregarySumarCompra(8);
        }
    }
}
