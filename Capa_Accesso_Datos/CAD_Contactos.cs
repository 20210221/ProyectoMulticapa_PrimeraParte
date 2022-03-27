using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using Capa_Entidad;
using System.Data;

namespace Capa_Accesso_Datos
{
    public class CAD_Contactos
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        SqlConnection conexion = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<CE_Contactos> ListarContactos(String buscar)
        {
            SqlDataReader Leerfilas;

            SqlCommand cmd = new SqlCommand("SP_BuscarContacto", conexion);

            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@Buscar", buscar);

            Leerfilas = cmd.ExecuteReader();

            List<CE_Contactos> Listar = new List<CE_Contactos>();

            while (Leerfilas.Read()) {

                Listar.Add(new CE_Contactos
                {

                    IDContacto = Leerfilas.GetInt32(0),

                    CodeContacto = Leerfilas.GetString(1),

                    NombreContacto = Leerfilas.GetString(2),

                    ApellidoContacto = Leerfilas.GetString(3)

                });
            
            }

            conexion.Close();

            Leerfilas.Close();

            return Listar;
        }

        public void InsertarContacto(CE_Contactos Contacto)
        {
            SqlCommand cmd = new SqlCommand("SP_InsertarContacto", conexion);

            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@Nombre", Contacto.NombreContacto);

            cmd.Parameters.AddWithValue("@Apellido", Contacto.ApellidoContacto);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void EditarContacto(CE_Contactos Contacto)
        {
            SqlCommand cmd = new SqlCommand("SP_EditarContacto", conexion);

            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@CodeContacto", Contacto.CodeContacto);

            cmd.Parameters.AddWithValue("@Nombre", Contacto.NombreContacto);

            cmd.Parameters.AddWithValue("@Apellido", Contacto.ApellidoContacto);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }

        public void EliminarContacto(CE_Contactos Contacto)
        {
            SqlCommand cmd = new SqlCommand("SP_EliminarContacto", conexion);

            cmd.CommandType = CommandType.StoredProcedure;

            conexion.Open();

            cmd.Parameters.AddWithValue("@CodeContacto", Contacto.CodeContacto);

            cmd.ExecuteNonQuery();

            conexion.Close();
        }
    }
}
