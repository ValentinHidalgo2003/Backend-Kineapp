using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend_Kineapp.Modelos
{
    public class Rol
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id_rol")] // Mapeo de la columna en la base de datos
        public int IdRol { get; set; }

        public string? Nombre { get; set; }

        [JsonIgnore]
        public virtual ICollection<Usuario>? Usuarios { get; } = new List<Usuario>();
        public virtual ICollection<RolesPermisos>? RolesPermisos { get; } = new List<RolesPermisos>();
    }

}
