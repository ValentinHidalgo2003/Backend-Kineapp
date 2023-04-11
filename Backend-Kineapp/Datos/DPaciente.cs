using Backend_Kineapp.Conexion;
using Backend_Kineapp.Modelos;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Backend_Kineapp.Datos
{
    public class DPaciente
    {
            ConexionBD conexion = new ConexionBD();


        public async Task<List<Paciente>> mostrarPacientes()
        {
            var lista = new List<Paciente>();
            using (var sql = new SqlConnection(conexion.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("select * from Paciente", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = CommandType.Text;
                    using(var item = await cmd.ExecuteReaderAsync())
                    {
                        while (await item.ReadAsync()) 
                        {
                            var pacientes = new Paciente();
                            pacientes.IdPaciente = (int)item["id_paciente"];
                            pacientes.Nombre = (string)item["Nombre"];
                            pacientes.Apellido = (string)item["Apellido"];
                            pacientes.Email = (string)item["Email"];
                            pacientes.Antecedentes = (string)item["Antecedentes"];
                            pacientes.Telefono = (string)item["Telefono"];
                            pacientes.Dni = (long)item["DNI"];
                            pacientes.Sexo = (bool)item["Sexo"];
                            pacientes.FechaNacimento = (DateTime)item["FechaNacimento"];
                            lista.Add(pacientes);
                        }
                    }
                }
            }
            return lista;
        }

        //public async Task insertarPaciente(Paciente parametros)
        //{
        //    using (var sql = new SqlConnection(conexion.cadenaSQL()))
        //    {
        //        using (var cmd = new SqlCommand("insert into Paciente values(Nombre,Apellido,DNI,FechaNacimento,Sexo,Email,Telefono,Antecedentes,id_usuario,Id_turno,Id_obraSocial,Id_historial)", sql))  
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            //cmd.Parameters.AddWithValue("id_paciente", parametros.IdPaciente);
        //            cmd.Parameters.AddWithValue("Nombre", parametros.Nombre);
        //            cmd.Parameters.AddWithValue("Apellido", parametros.Apellido);
        //            cmd.Parameters.AddWithValue("DNI", parametros.Dni);
        //            cmd.Parameters.AddWithValue("FechaNacimento", parametros.FechaNacimento);
        //            cmd.Parameters.AddWithValue("Sexo", parametros.Sexo);
        //            cmd.Parameters.AddWithValue("Email", parametros.Email);
        //            cmd.Parameters.AddWithValue("Telefono", parametros.Telefono);
        //            cmd.Parameters.AddWithValue("Antecedentes", parametros.Antecedentes);

        //            cmd.Parameters.AddWithValue("id_usuario", parametros.IdUsuario);
        //            cmd.Parameters.AddWithValue("Id_turno", parametros.IdTurno);
        //            cmd.Parameters.AddWithValue("Id_obraSocial", parametros.IdObraSocial);
        //            cmd.Parameters.AddWithValue("Id_historial", parametros.IdHistorial);

        //            await sql.OpenAsync();   //ABRIR CONEXION BASE DE DATOS
        //            await cmd.ExecuteNonQueryAsync();
        //        }
        //    }
        //}


        public async Task insertarPaciente(Paciente parametros)
        {
            using (var db = new KineappContext())
            {
                db.Pacientes.Add(parametros);
                await db.SaveChangesAsync();
            }
        }

    }
}
