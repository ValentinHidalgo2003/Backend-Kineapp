using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Backend_Kineapp.Modelos
{
    public class RolesPermisos
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdRolPermiso { get; set; }
        public int? IdRol { get; set; }
        public int? IdPermiso {get; set;}
        public bool? Estado { get; set;}

        public virtual Rol? IdRolNavigation { get; set; }
        public virtual Permiso? IdPermisoNavigation { get; set; }
    }
}
