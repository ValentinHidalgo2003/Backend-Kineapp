using Backend_Kineapp.Datos;
using Backend_Kineapp.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Backend_Kineapp.Controllers
{
    [ApiController]
    [Route("api/Paciente")]
    public class PacientesController
    {
    

        [HttpGet]
        public async Task <ActionResult<List<Paciente>>> GetPaciente()
        {
            var paciente = new DPaciente();
            var lista = await paciente.mostrarPacientes();
            return lista;
        }


        [HttpPost]
        public async Task PostPaciente([FromBody]Paciente parametros)
        {
 
            var funcion = new DPaciente();          
            await funcion.insertarPaciente(parametros);
        }
     
    }
}
