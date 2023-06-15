using Backend_Kineapp.Modelos;

namespace Backend_Kineapp.Dtos
{
    public class DtoRolesPermisos
    {
        public int IdRolPermiso { get; set; }
        public int IdRol { get; set; }
        public int IdPermiso { get; set; }
        public bool Estado { get; set; }

        public virtual DtoRol? IdRolNavigation { get; set; }
        public virtual DtoPermisos? IdPermisoNavigation { get; set; }
    }
}
