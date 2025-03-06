using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace TDDTestingMVC.data
{
    public class ClienteDataAccessLayer
    {
        string connectionString = "Server=LAPTOP-OL6NHILJ\\SQL;Database=DBProductos;User Id=sa;Password=Edgar123456/;TrustServerCertificate=True;";

        public List<Cliente> GetAllClientes()
        {
            List<Cliente> listClientes = new List<Cliente>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_SelectAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Cliente cliente = new Cliente();
                    cliente.Codigo = Convert.ToInt32(rdr["codigo"]);
                    cliente.Cedula = rdr["cedula"].ToString();
                    cliente.Apellidos = rdr["apellidos"].ToString();
                    cliente.Nombres = rdr["nombres"].ToString();
                    cliente.FechaNacimiento = Convert.ToDateTime(rdr["fecha_nacimiento"]);
                    cliente.Mail = rdr["mail"].ToString();
                    cliente.Telefono = rdr["telefono"].ToString();
                    cliente.Direccion = rdr["direccion"].ToString();
                    cliente.Estado = rdr["estado"].ToString();
                    listClientes.Add(cliente);
                }
                con.Close();
            }
            return listClientes;
        }

        public void AddCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdateCliente(Cliente cliente)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", cliente.Codigo);
                cmd.Parameters.AddWithValue("@Cedula", cliente.Cedula);
                cmd.Parameters.AddWithValue("@Apellidos", cliente.Apellidos);
                cmd.Parameters.AddWithValue("@Nombres", cliente.Nombres);
                cmd.Parameters.AddWithValue("@FechaNacimiento", cliente.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Mail", cliente.Mail);
                cmd.Parameters.AddWithValue("@Telefono", cliente.Telefono);
                cmd.Parameters.AddWithValue("@Direccion", cliente.Direccion);
                cmd.Parameters.AddWithValue("@Estado", cliente.Estado);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Cliente GetClienteData(int? id)
        {
            Cliente cliente = new Cliente();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_SelectById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    cliente.Codigo = Convert.ToInt32(rdr["codigo"]);
                    cliente.Cedula = rdr["cedula"].ToString();
                    cliente.Apellidos = rdr["apellidos"].ToString();
                    cliente.Nombres = rdr["nombres"].ToString();
                    cliente.FechaNacimiento = Convert.ToDateTime(rdr["fecha_nacimiento"]);
                    cliente.Mail = rdr["mail"].ToString();
                    cliente.Telefono = rdr["telefono"].ToString();
                    cliente.Direccion = rdr["direccion"].ToString();
                    cliente.Estado = rdr["estado"].ToString();
                }
            }
            return cliente;
        }


        public void DeleteCliente(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("cliente_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Codigo", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
