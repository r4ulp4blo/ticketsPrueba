using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ticketsPrueba.Models
{
    public class clientes
    {
        [Key]
        public int Id_cliente { get; set; }
        public int Id_usuario { get; set; }
    }
}
