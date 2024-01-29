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
    public partial class fm_Ticket : Form
    {
        public fm_Ticket(int id_venta)
        {
            InitializeComponent();
            
            foreach (PizzaComprada pizza in VentaHelper.ListaPizzasCompradas(id_venta))
            {
                bdgv_listaVenta.Rows.Add(pizza.Id, pizza.Nombre, pizza.Precio, pizza.Cantidad, pizza.Total);
            }

            foreach (Venta venta in VentaHelper.ListaVentas())
            {
                if (venta.Id == id_venta)
                    bdgv_venta.Rows.Add(venta.Id, venta.Total, venta.Efectivo, venta.Cambio);
            }

        }

        private void bbtn_comprar_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
