using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.UI.WinForms;

namespace BitzzaPizza
{
    public class PizzaComprada
    {
        public PizzaComprada(int id, string nombre, float precio, int cantidad, float total)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
            Cantidad = cantidad;
            Total = total;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
        public int Cantidad { get; set; }
        public float Total { get; set; }
    }

    public class PizzaCompradaTicketHelper
    {
        public static void EscribirListaComprar(string ruta, BunifuDataGridView Tabla, 
            BunifuTextBox Total, BunifuTextBox Efectivo, BunifuTextBox Cambio)
        {
            try
            {
                string aux = "#," + Convert.ToString(VentaHelper.GenerarIdVenta()) + ',' + Total.Text + ',' + Efectivo.Text + ',' + Cambio.Text;

                StreamWriter writer = new StreamWriter(ruta, true);
                writer.WriteLine(aux);

                foreach (DataGridViewRow row in Tabla.Rows)
                {
                    writer.WriteLine(row.Cells[0].Value.ToString() + ',' + row.Cells[1].Value.ToString() + ',' + row.Cells[2].Value.ToString()
                        + ',' + row.Cells[3].Value.ToString() + ',' + row.Cells[4].Value.ToString());
                }
                writer.WriteLine("-------------------------------------------------------------------");

                writer.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show("Error " + e);
            }
        }

    }
}
