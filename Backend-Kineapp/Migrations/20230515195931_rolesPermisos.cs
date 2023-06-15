using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_Kineapp.Migrations
{
    /// <inheritdoc />
    public partial class rolesPermisos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "Permiso",
                columns: table => new
                {
                    IdPermiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permiso", x => x.IdPermiso);
                });



            migrationBuilder.CreateTable(
                name: "RolesPermisos",
                columns: table => new
                {
                    IdRolPermiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdRol = table.Column<int>(type: "int", nullable: false),
                    IdPermiso = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<bool>(type: "bit", nullable: false),
                    IdRolNavigation = table.Column<int>(type: "int", nullable: true),
                    IdPermisoNavigation = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolesPermisos", x => x.IdRolPermiso);
                    table.ForeignKey(
                        name: "FK_RolesPermisos_Permiso_IdPermisoNavigation",
                        column: x => x.IdPermisoNavigation,
                        principalTable: "Permiso",
                        principalColumn: "IdPermiso");
                    table.ForeignKey(
                        name: "FK_RolesPermisos_Rol_IdRolNavigation",
                        column: x => x.IdRolNavigation,
                        principalTable: "Rol",
                        principalColumn: "id_rol");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_id_rol",
                table: "Usuario",
                column: "id_rol");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermisos_IdPermisoNavigation",
                table: "RolesPermisos",
                column: "IdPermisoNavigation");

            migrationBuilder.CreateIndex(
                name: "IX_RolesPermisos_IdRolNavigation",
                table: "RolesPermisos",
                column: "IdRolNavigation");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuario_Rol",
                table: "Usuario");

            migrationBuilder.DropTable(
                name: "RolesPermisos");

            migrationBuilder.DropTable(
                name: "Permiso");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropIndex(
                name: "IX_Usuario_id_rol",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "id_rol",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Precio",
                table: "Detalle_turno");

            migrationBuilder.AddColumn<int>(
                name: "id_kinesiologo",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_paciente",
                table: "Usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_detalle_turno",
                table: "Medio_pago",
                type: "int",
                nullable: true);
        }
    }
}
