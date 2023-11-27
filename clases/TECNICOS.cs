using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExammenII.clases
{
    public class TECNICOS
    {

        /*create table tecnico
              (
              TecnicoId int identity primary key,
              Nombre varchar(50),
      especialidad text
      )*/

        public int TecnicoId { get; set; }
        public String Nombre { get; set; }
        public String especialidad { get; set; }

        public TECNICOS(int TECNICOID, string NOMBRE, String ESPECIALIDAD)
        {
            TecnicoId = TECNICOID;
            Nombre = NOMBRE;
            especialidad = ESPECIALIDAD;
        }

        public void agregar()
        {
            // Reemplaza la cadena de conexión con la tuya
            const string cadenaConexion = "conexion";

            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                // Consulta SQL para la inserción
                const string consulta = "INSERT INTO TECNICOS (Nombre, Especialidad) VALUES (@Nombre, @Especialidad)";

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    // Agrega parámetros para evitar SQL Injection
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.Parameters.AddWithValue("@Especialidad", especialidad);

                    // Ejecuta la consulta
                    comando.ExecuteNonQuery();

                    Console.WriteLine("Técnico agregado exitosamente");
                }
            }
        }

        public void Borrar()
        {
            // Reemplaza la cadena de conexión con la tuya
            const string cadenaConexion = "conexion";

            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                // Consulta SQL para borrar un técnico por TecnicoId
                const string consulta = "DELETE FROM TECNICOS WHERE TecnicoId = @TecnicoId";

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    // Agrega parámetro para evitar SQL Injection
                    comando.Parameters.AddWithValue("@TecnicoId", TecnicoId);

                    // Ejecuta la consulta
                    comando.ExecuteNonQuery();

                    Console.WriteLine("Técnico borrado exitosamente");
                }
            }
        }

        public void ConsultarFiltro()
        {
            // Reemplaza la cadena de conexión con la tuya
            const string cadenaConexion = "conexion";

            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                // Consulta SQL para consultar técnicos con filtro
                const string consulta = "SELECT * FROM TECNICOS WHERE Nombre LIKE @Nombre";

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    // Agrega parámetro para evitar SQL Injection
                    comando.Parameters.AddWithValue("@Nombre", "%" + Nombre + "%");

                    // Ejecuta la consulta
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            Console.WriteLine($"TecnicoId: {lector["TecnicoId"]}, Nombre: {lector["Nombre"]}, Especialidad: {lector["Especialidad"]}");
                        }
                    }
                }
            }
        }

        public void Modificar()
        {
            // Reemplaza la cadena de conexión con la tuya
            const string cadenaConexion = "conexion";

            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                // Consulta SQL para modificar un técnico por TecnicoId
                const string consulta = "UPDATE TECNICOS SET Nombre = @Nombre, Especialidad = @Especialidad WHERE TecnicoId = @TecnicoId";

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    // Agrega parámetros para evitar SQL Injection
                    comando.Parameters.AddWithValue("@TecnicoId", TecnicoId);
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.Parameters.AddWithValue("@Especialidad", especialidad);

                    // Ejecuta la consulta
                    comando.ExecuteNonQuery();

                    Console.WriteLine("Técnico modificado exitosamente");
                }
            }
        }


    }
}
      