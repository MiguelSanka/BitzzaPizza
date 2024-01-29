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
    public partial class fm_Ganancias : Form
    {
        public fm_Ganancias()
        {
            InitializeComponent();

            foreach (Venta venta in VentaHelper.ListaVentas())
                bdgv_venta.Rows.Add(venta.Id, venta.Total, venta.Efectivo,venta.Cambio, "Ver información");

            lb_ganancias.Text = VentaHelper.CalcularGanancias();
            lb_numeroVentas.Text = VentaHelper.CalcularNumeroVentas();

        }

        private void bdgv_venta_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(bdgv_venta.CurrentRow.Cells[0].Value);
            fm_InfoVenta infoVenta = new fm_InfoVenta(id);
            infoVenta.Show();
        }

        private void btxt_idbuscar_TextChange(object sender, EventArgs e)
        {
            int n;
            bdgv_venta.Rows.Clear();

            if (btxt_idbuscar.Text != "" && Int32.TryParse(btxt_idbuscar.Text, out n))
            {
                foreach (Venta venta in VentaHelper.ListaVentas())
                {
                    if(venta.Id == Convert.ToInt32(btxt_idbuscar.Text))
                        bdgv_venta.Rows.Add(venta.Id, venta.Total, venta.Efectivo, venta.Cambio, "Ver información");
                }
            }
            else if(btxt_idbuscar.Text == "")
            {
                foreach (Venta venta in VentaHelper.ListaVentas())
                    bdgv_venta.Rows.Add(venta.Id, venta.Total, venta.Efectivo, venta.Cambio, "Ver información");
            }
           
        }
    }

}
