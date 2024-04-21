using CrudCoches.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudCoches.Controllers
{
    internal class AutomovilesController
    {
        private string connectionString = "Data Source = DESKTOP-G43PN29\\SQLEXPRESS; Initial Catalog = Coches; Integrated Security = True";
        
        //obtenemos la lista de los Automoviles
        public List<AutomovilesModel> GetAutomoviles()
        {
            var ListaAutomoviles = new List<AutomovilesModel>();

            using (var connection = new SqlConnection(connectionString))
            {
                string query = "select * from Automoviles";
                connection.Open();
                var command = new SqlCommand(query,connection);
                //ejecutamos la lectura de los datos
                using(var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        ListaAutomoviles.Add(new AutomovilesModel
                        {
                            id = reader.GetInt32(0),
                            nombre = reader.GetString(1),
                            marca = reader.GetString(2),
                            color = reader.GetString(3),
                            placa = reader.GetString(4),
                            precio = reader.GetString(5)

                        });
                    }

                }
                connection.Close();
            }
            return ListaAutomoviles;
        }
        //editamos la tabla
        public void EditAutomoviles(AutomovilesModel automoviles)
        {
            
            
            string query = "update Automoviles set  color=@color, precio = @precio where idAutomovil = @id";
            using (var conection = new SqlConnection(connectionString))
            {
                conection.Open();
                var command = new SqlCommand(query, conection);

                command.Parameters.AddWithValue("@id",automoviles.id);
                command.Parameters.AddWithValue("@color", automoviles.color);
                command.Parameters.AddWithValue("@precio", automoviles.precio);

                command.ExecuteNonQuery();
                conection.Close();
            }
        } 
        public void DeleteAutmoviles(int id)
        {
            string query = "DELETE FROM Automoviles where idAutomovil = @id;";
            using(var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
            }
        }

        public void SetAutomoviles(AutomovilesModel automoviles)
        {
            string query = "INSERT INTO Automoviles Values(@nombre,@marca,@color,@placa,@precio)";
            using( var conection = new SqlConnection(connectionString))
            {
                conection.Open();
                var command = new SqlCommand(query, conection);
                command.Parameters.AddWithValue("@nombre",automoviles.nombre);
                command.Parameters.AddWithValue("@marca", automoviles.marca);
                command.Parameters.AddWithValue("@color", automoviles.color);
                command.Parameters.AddWithValue("@placa", automoviles.placa);
                command.Parameters.AddWithValue("@precio", automoviles.precio);
                command.ExecuteNonQuery();
                conection.Close();
            }
        }
        
    }
}
