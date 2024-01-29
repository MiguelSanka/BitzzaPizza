using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bunifu.UI.WinForms;

namespace BitzzaPizza
{
    public class Pizza
    {
        public Pizza(int id, string nombre, float precio)
        {
            Id = id;
            Nombre = nombre;
            Precio = precio;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public float Precio { get; set; }
    }


    public class PizzaTicketHelper
    {

        public static List<Pizza> ListaPizza()
        {
            List<Pizza> lista = new List<Pizza>();

            using (StreamReader sr = new StreamReader("C:/Users/Miguel Sanka/Desktop/pizzas.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] infoPizza = line.Split(',');
                    Pizza pizza_aux = new Pizza(Convert.ToInt32(infoPizza[0]), infoPizza[1], float.Parse(infoPizza[2]));
                    lista.Add(pizza_aux);
                }
            }

            return lista;
        }

        public static void AgregarPizzaVenta(int id_Pizza, BunifuDataGridView tablaVentas, int cantidad)
        {
            List<Pizza> lista = ListaPizza();
            float total;
            foreach (Pizza pizza_aux in lista)
            {
                if (pizza_aux.Id == id_Pizza)
                {
                    total = pizza_aux.Precio * cantidad;
                    tablaVentas.Rows.Add(pizza_aux.Id, pizza_aux.Nombre, pizza_aux.Precio, cantidad, total);
                }

            }
        }

    }
}

