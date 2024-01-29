using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitzzaPizza
{
    public class Usuario
    {
        public Usuario(int id, string nombre, string password)
        {
            Id = id;
            Nombre = nombre;
            Password = password;
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Password { get; set; }
    }


    public class UsuariosLoginHelper
    {

        public static List<Usuario> ListaUsuarios()
        {
            List<Usuario> lista = new List<Usuario>();

            using (StreamReader sr = new StreamReader("C:/Users/Miguel Sanka/Desktop/usuarios.txt"))
            {
                string line;

                while ((line = sr.ReadLine()) != null)
                {
                    string[] infousu = line.Split(',');
                    Usuario usu_aux = new Usuario(Convert.ToInt32(infousu[0]), infousu[1], infousu[2]);
                    lista.Add(usu_aux);
                }
            }

            return lista;
        }

        public static bool AutenticarUsuario(string nombre, string password)
        {
            bool result = false;
            List<Usuario> lista = ListaUsuarios();

            foreach (Usuario usu_aux in lista)
            {
                if (usu_aux.Nombre == nombre && usu_aux.Password == password)
                {
                    result = true;
                    break;
                }
            }

            return result;
        }

    }
}
