using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ExammenII.clases
{
    public class EQUIPOS
    {
        /*create table equipo
 (
 EquipoId int identity primary key,
 TipoEquipo varchar(50) not null,
 Modelo varchar(50),
 UsuarioId int ,
 constraint fk__usuarioId foreign key(usuarioId) references usuario(UsuarioId)   
     }*/

        public int EquipoId { get; set; }
        public string TipoEquipo { get; set; }
        public string Modelo { get; set; }
        public int UsuarioId { get; set; }

        public EQUIPOS(int EQUIPOID, string TIPOEQUIPO, string MODELO, int USUARIOID) 
        
        {
            EquipoId = EQUIPOID;
            TipoEquipo = TIPOEQUIPO;
            Modelo = MODELO;
            UsuarioId = USUARIOID;
        
        }
        public void Agregar()
        {
            // Reemplaza la cadena de conexión con la tuya
            const string cadenaConexion = "conexion";

            using (var conexion = new SqlConnection(cadenaConexion))
            {
                conexion.Open();

                const string consulta = "INSERT INTO equipo (TipoEquipo, Modelo, UsuarioId) VALUES (@TipoEquipo, @Modelo, @UsuarioId)";

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@TipoEquipo", TipoEquipo);
                    comando.Parameters.AddWithValue("@Modelo", Modelo);
                    comando.Parameters.AddWithValue("@UsuarioId", UsuarioId);

                    comando.ExecuteNonQuery();

                    Console.WriteLine("Equipo agregado exitosamente");
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

                const string consulta = "DELETE FROM equipo WHERE EquipoId = @EquipoId";

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@EquipoId", EquipoId);

                    comando.ExecuteNonQuery();

                    Console.WriteLine("Equipo borrado exitosamente");
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

                const string consulta = "SELECT * FROM equipo WHERE TipoEquipo LIKE @TipoEquipo";

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@TipoEquipo", "%" + TipoEquipo + "%");

                    using (var lector = comando.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            Console.WriteLine($"EquipoId: {lector["EquipoId"]}, TipoEquipo: {lector["TipoEquipo"]}, Modelo: {lector["Modelo"]}, UsuarioId: {lector["UsuarioId"]}");
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

                const string consulta = "UPDATE equipo SET TipoEquipo = @TipoEquipo, Modelo = @Modelo, UsuarioId = @UsuarioId WHERE EquipoId = @EquipoId";

                using (var comando = new SqlCommand(consulta, conexion))
                {
                    comando.Parameters.AddWithValue("@EquipoId", EquipoId);
                    comando.Parameters.AddWithValue("@TipoEquipo", TipoEquipo);
                    comando.Parameters.AddWithValue("@Modelo", Modelo);
                    comando.Parameters.AddWithValue("@UsuarioId", UsuarioId);

                    comando.ExecuteNonQuery();

                    Console.WriteLine("Equipo modificado exitosamente");
                }
            }
        }
    }
}
  