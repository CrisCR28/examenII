using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExammenII.clases
{
    public class USUARIOS
    {
        /*UsuarioId INT   IDENTITY primary key,
     Nombre varchar(50) not null,
     CorreoElectronico varchar(50),
     Telefono varchar(50) unique,*/
        public int UsuarioId { get; set; }
        public String Nombre { get; set; }
        public String CorreoElectronico { get; set; }
        public String Telefono { get; set; }

        public USUARIOS(int USUARIOID, string NOMBRE, string CORREOELECTRONICO, String TELEFONO)
        {
            UsuarioId = USUARIOID;
            Nombre = NOMBRE;
            CorreoElectronico = CORREOELECTRONICO;
            Telefono = TELEFONO;

        }
        public void agregar()
        {
            // Reemplaza la cadena de conexión con la de cada uno
            const string cadenaConexion = "conexion";

            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                // Consulta SQL para la inserción
                const string consulta = "INSERT INTO USUARIOS (Nombre, CorreoElectronico, Telefono) VALUES (@Nombre, @CorreoElectronico, @Telefono)";

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    // Agrega parámetros para evitar SQL Injection
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.Parameters.AddWithValue("@CorreoElectronico", CorreoElectronico);
                    comando.Parameters.AddWithValue("@Telefono", Telefono);

                    // Ejecuta la consulta
                    comando.ExecuteNonQuery();

                    Console.WriteLine("Usuario agregado exitosamente");
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

                // Consulta SQL para borrar un usuario por UsuarioId
                const string consulta = "DELETE FROM USUARIOS WHERE UsuarioId = @UsuarioId";

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    // Agrega parámetro para evitar SQL Injection
                    comando.Parameters.AddWithValue("@UsuarioId", UsuarioId);

                    // Ejecuta la consulta
                    comando.ExecuteNonQuery();

                    Console.WriteLine("Usuario borrado exitosamente");
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

                // Consulta SQL para consultar usuarios con filtro
                const string consulta = "SELECT * FROM USUARIOS WHERE Nombre LIKE @Nombre";

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    // Agrega parámetro para evitar SQL Injection
                    comando.Parameters.AddWithValue("@Nombre", "%" + Nombre + "%");

                    // Ejecuta la consulta
                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            Console.WriteLine($"UsuarioId: {lector["UsuarioId"]}, Nombre: {lector["Nombre"]}, Correo: {lector["CorreoElectronico"]}, Teléfono: {lector["Telefono"]}");
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

                // Consulta SQL para modificar un usuario por UsuarioId
                const string consulta = "UPDATE USUARIOS SET Nombre = @Nombre, CorreoElectronico = @CorreoElectronico, Telefono = @Telefono WHERE UsuarioId = @UsuarioId";

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    // Agrega parámetros para evitar SQL Injection
                    comando.Parameters.AddWithValue("@UsuarioId", UsuarioId);
                    comando.Parameters.AddWithValue("@Nombre", Nombre);
                    comando.Parameters.AddWithValue("@CorreoElectronico", CorreoElectronico);
                    comando.Parameters.AddWithValue("@Telefono", Telefono);

                    // Ejecuta la consulta
                    comando.ExecuteNonQuery();

                    Console.WriteLine("Usuario modificado exitosamente");
                }
            }
        }
    }
}

    