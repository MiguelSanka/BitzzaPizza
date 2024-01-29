using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitzzaPizza
{
    public class Venta
    {
        public Venta(int id, float total, float efectivo, float cambio)
        {
            Id = id;
            Total = total;
            Efectivo = efectivo;
            Cambio = cambio;

        }
        public int Id { get; set; }
        public float Total { get; set; }
        public float Cambio { get; set; }
        public float Efectivo { get; set; }
    }

    public class VentaHelper
    {
        public static List<PizzaComprada> ListaPizzasCompradas(int id_venta)
        {
            List<PizzaComprada> lista = new List<PizzaComprada>();
            using (StreamReader sr = new StreamReader("C:/Users/Miguel Sanka/Desktop/ventas.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] infoPizzaComprada = line.Split(',');
                    if (infoPizzaComprada[0].Equals("#") && Convert.ToInt32(infoPizzaComprada[1]).Equals(id_venta))
                    {
                        line = sr.ReadLine();
                        while (line.First() != '-')
                        {
                            infoPizzaComprada = line.Split(',');
                            PizzaComprada pizzaComp_aux = new PizzaComprada(Convert.ToInt32(infoPizzaComprada[0]), infoPizzaComprada[1],
                            float.Parse(infoPizzaComprada[2]), Convert.ToInt32(infoPizzaComprada[3]), float.Parse(infoPizzaComprada[4]));
                            lista.Add(pizzaComp_aux);
                            line = sr.ReadLine();
                        }
                    }
                }
            }
            return lista;
        }

        public static List<Venta> ListaVentas()
        {
            List<Venta> lista = new List<Venta>();
            using (StreamReader sr = new StreamReader("C:/Users/Miguel Sanka/Desktop/ventas.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] infoVenta = line.Split(',');
                    if (infoVenta[0].Equals("#") && line.First() != '-')
                    {
                        Venta Venta_aux = new Venta(Convert.ToInt32(infoVenta[1]), float.Parse(infoVenta[2]), 
                        float.Parse(infoVenta[3]), float.Parse(infoVenta[4]));
                        lista.Add(Venta_aux);
                    }
                }
                sr.Close();
            }
            return lista;
        }


        public static int GenerarIdVenta()
        {
            int num=0;
            List<Venta> lista = ListaVentas();

            foreach (Venta Venta_aux in lista)
            {
                if (Venta_aux.Id > num)
                    num = Venta_aux.Id;
            }
            num++;
            return num;
        }

        public static string CalcularGanancias()
        {
            float AuxGanancias = 0;
            string Ganancias;
            List<Venta> lista = ListaVentas();

            foreach (Venta Venta_aux in lista)
                AuxGanancias += Venta_aux.Total;

            Ganancias = "$ " + Convert.ToString(AuxGanancias);
            return Ganancias;
        }

        public static string CalcularNumeroVentas()
        {
            int AuxVentas = 0;
            string Ventas;
            List<Venta> lista = ListaVentas();

            foreach (Venta Venta_aux in lista)
                AuxVentas++;

            Ventas = Convert.ToString(AuxVentas);
            return Ventas;
        }
    }
}

