using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ticketsPrueba.Models
{
    public class tecnicos
    {
        [Key]
        public int Id_tecnico { get; set; }
        public int Id_usuario { get; set; }
        public string Rol { get; set; }
        public string Area { get; set; }
    }
}
