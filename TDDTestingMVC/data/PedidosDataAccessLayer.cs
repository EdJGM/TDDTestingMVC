using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlTypes;

namespace TDDTestingMVC.data
{
    public class PedidoDataAccessLayer
    {
        string connectionString = "Server=LAPTOP-OL6NHILJ\\SQL;Database=DBProductos;User Id=sa;Password=Edgar123456/;TrustServerCertificate=True;";

        public List<Pedido> GetAllPedidos()
        {
            List<Pedido> listPedidos = new List<Pedido>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("pedido_SelectAll", con);
                cmd.CommandType = CommandType.StoredProcedure;
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.PedidoID = Convert.ToInt32(rdr["PedidoID"]);
                    pedido.ClienteID = Convert.ToInt32(rdr["ClienteID"]);
                    pedido.FechaPedido = Convert.ToDateTime(rdr["FechaPedido"]);
                    pedido.Monto = Convert.ToDecimal(rdr["Monto"]);
                    pedido.Estado = rdr["Estado"].ToString();
                    listPedidos.Add(pedido);
                }
                con.Close();
            }
            return listPedidos;
        }

        public void AddPedido(Pedido pedido)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("pedido_Insert", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClienteID", pedido.ClienteID);
                cmd.Parameters.AddWithValue("@FechaPedido", pedido.FechaPedido);
                cmd.Parameters.AddWithValue("@Monto", pedido.Monto);
                cmd.Parameters.AddWithValue("@Estado", pedido.Estado);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void UpdatePedido(Pedido pedido)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("pedido_Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PedidoID", pedido.PedidoID);
                cmd.Parameters.AddWithValue("@ClienteID", pedido.ClienteID);
                cmd.Parameters.AddWithValue("@FechaPedido", pedido.FechaPedido);
                cmd.Parameters.AddWithValue("@Monto", pedido.Monto);
                cmd.Parameters.AddWithValue("@Estado", pedido.Estado);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Pedido GetPedidoData(int? id)
        {
            Pedido pedido = new Pedido();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("pedido_SelectById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PedidoID", id);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    pedido.PedidoID = Convert.ToInt32(rdr["PedidoID"]);
                    pedido.ClienteID = Convert.ToInt32(rdr["ClienteID"]);
                    pedido.FechaPedido = Convert.ToDateTime(rdr["FechaPedido"]);
                    pedido.Monto = Convert.ToDecimal(rdr["Monto"]);
                    pedido.Estado = rdr["Estado"].ToString();
                }
            }
            return pedido;
        }

        public void DeletePedido(int? id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("pedido_Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PedidoID", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public List<Pedido> GetPedidosByCliente(int clienteId)
        {
            List<Pedido> listPedidos = new List<Pedido>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("pedido_SelectByCliente", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ClienteID", clienteId);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.PedidoID = Convert.ToInt32(rdr["PedidoID"]);
                    pedido.ClienteID = Convert.ToInt32(rdr["ClienteID"]);
                    pedido.FechaPedido = Convert.ToDateTime(rdr["FechaPedido"]);
                    pedido.Monto = Convert.ToDecimal(rdr["Monto"]);
                    pedido.Estado = rdr["Estado"].ToString();
                    listPedidos.Add(pedido);
                }
                con.Close();
            }
            return listPedidos;
        }

        public List<Pedido> GetPedidosByEstado(string estado)
        {
            List<Pedido> listPedidos = new List<Pedido>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("pedido_SelectByEstado", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Estado", estado);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Pedido pedido = new Pedido();
                    pedido.PedidoID = Convert.ToInt32(rdr["PedidoID"]);
                    pedido.ClienteID = Convert.ToInt32(rdr["ClienteID"]);
                    pedido.FechaPedido = Convert.ToDateTime(rdr["FechaPedido"]);
                    pedido.Monto = Convert.ToDecimal(rdr["Monto"]);
                    pedido.Estado = rdr["Estado"].ToString();
                    listPedidos.Add(pedido);
                }
                con.Close();
            }
            return listPedidos;
        }

        public void CambiarEstadoPedido(int? id, string nuevoEstado)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("pedido_CambiarEstado", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PedidoID", id);
                cmd.Parameters.AddWithValue("@NuevoEstado", nuevoEstado);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}