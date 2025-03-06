using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TDDTestingMVC.data
{
    public class Cliente
    {
        [Required]
        public int Codigo { get; set; }
        [Required]
        public string Cedula { get; set; }
        [Required]
        public string Apellidos { get; set; }
        [Required]
        public string Nombres { get; set; }
        [Required]
        public DateTime FechaNacimiento { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Telefono { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public string Estado { get; set; }


        // Propiedad para manejar el checkbos
        [NotMapped]
        public bool EstadoBool
        {
            get
            { return Estado == "Activo"; }
            set
            { Estado = value ? "Activo" : "Inactivo"; }
        }

    }
}
