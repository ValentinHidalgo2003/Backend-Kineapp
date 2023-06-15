using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend_Kineapp.Modelos
{
    public class Permiso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdPermiso { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<RolesPermisos>? RolesPermisos { get; } = new List<RolesPermisos>();
    }

}
