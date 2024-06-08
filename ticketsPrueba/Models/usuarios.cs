using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace ticketsPrueba.Models
{
    public class usuarios
    {
        [Key]
        public int Id_usuario { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Estado { get; set; }
        [JsonIgnore]
        public string Contra { get; set; }
        public int Numero { get; set; }
    }
}
