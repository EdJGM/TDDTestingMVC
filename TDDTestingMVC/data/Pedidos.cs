using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TDDTestingMVC.data
{
    public class Pedido
    {
        [Required]
        public int PedidoID { get; set; }

        [Required]
        public int ClienteID { get; set; }

        [Required]
        public DateTime FechaPedido { get; set; }

        [Required]
        public decimal Monto { get; set; }

        [Required]
        public string Estado { get; set; }

        // Propiedad para manejar el checkbox
        [NotMapped]
        public bool EstadoCompletado
        {
            get
            { return Estado == "Completado"; }
            set
            { Estado = value ? "Completado" : "Pendiente"; }
        }
    }
}