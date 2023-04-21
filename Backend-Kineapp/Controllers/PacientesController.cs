using AutoMapper;
using Backend_Kineapp.Dtos;
using Backend_Kineapp.Modelos;
using Backend_Kineapp.Resultados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Backend_Kineapp.Controllers
{
    [ApiController]
    // [Route("api/[controller]")]
    public class PacientesController : ControllerBase
    {
        private readonly KineappContext _context;
        private readonly IMapper _mapper;


        public PacientesController(KineappContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpGet("api/Paciente/Get")]
        public async Task<ActionResult<List<ResultadoPaciente>>> GetPacientes()
        {
            try
            {
                var listaDto = new List<DtoPaciente>();
                var resultado = new List<ResultadoPaciente>();
                var pacientes = await _context.Pacientes.ToListAsync();
                if (pacientes != null)
                {
                    var pacientesDto = _mapper.Map<List<DtoPaciente>>(pacientes);
                    var resultadoPaciente = _mapper.Map<List<ResultadoPaciente>>(pacientesDto);
                    if (resultadoPaciente != null)
                    {
                        resultado.AddRange(resultadoPaciente);

                        return resultado;
                    }
                    else return BadRequest("fallo el mapeo");
                }
                else
                {
                    return StatusCode(500, "No hay pacientes");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fallo la solicitud: {ex.Message}");
            }
        }


        [HttpPost("api/Paciente/Post")]
        public async Task<ActionResult<ResultadoPaciente>> PostPaciente(DtoPaciente paciente)
        {
            var pacienteMap = _mapper.Map<Paciente>(paciente);
            _context.Pacientes.Add(pacienteMap);
            await _context.SaveChangesAsync();
            return Ok(pacienteMap);
        }

        [HttpPut("api/Paciente/Put/{id}")]
        public async Task<ActionResult> modificar(int id, [FromBody] DtoPaciente dtoPaciente)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            var nuevoPaciente = _mapper.Map<Paciente>(dtoPaciente);
            paciente.Nombre = nuevoPaciente.Nombre;
            paciente.Apellido = nuevoPaciente.Apellido;
            paciente.Dni = nuevoPaciente.Dni;
            paciente.FechaNacimento = nuevoPaciente.FechaNacimento;
            paciente.Sexo = nuevoPaciente.Sexo;
            paciente.Email = nuevoPaciente.Email;
            paciente.Telefono = nuevoPaciente.Telefono;
            paciente.Antecedentes = nuevoPaciente.Antecedentes;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                BadRequest("no se pudo guardar");
            }

            return Ok();
        }


        [HttpGet("api/Paciente/{id}")]
        public async Task<ActionResult<ResultadoPaciente>> ObtenerPorId(int id)
        {
            var paciente = await _context.Pacientes
                .Include(p => p.IdHistorialNavigation)
                .Include(p => p.IdObraSocialNavigation)
                .Include(p => p.IdTurnoNavigation)
                .Include(p => p.IdUsuarioNavigation)
                .FirstOrDefaultAsync(p => p.IdPaciente == id);

            if (paciente == null)
            {
                return NotFound();
            }

            var resultadoPaciente = _mapper.Map<ResultadoPaciente>(paciente);

            return Ok(resultadoPaciente);
        }


        [HttpDelete("api/Paciente/Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);
            if (paciente == null)
            {
                return NotFound($"No se encontro el paciente con el Id {id}");
            }
            _context.Pacientes.Remove(paciente);
            await _context.SaveChangesAsync();

            return Ok(paciente);
        }

    }
}
