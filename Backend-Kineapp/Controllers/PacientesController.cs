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
        public async Task<ActionResult<List<DtoPaciente>>> GetPacientes()
        {
            try
            {
                var listaDto = new List<DtoPaciente>();
                var pacientes = await _context.Pacientes
                    .Include(p => p.IdHistorialNavigation)
                    .Include(p => p.IdTurnoNavigation)
                    .Include(p => p.IdObraSocialNavigation)
                    .Include(p => p.IdUsuarioNavigation)
                    .Include(t => t.IdUsuarioNavigation)
                    .ToListAsync();

                if (pacientes != null)
                {
                    var pacientesDto = _mapper.Map<List<DtoPaciente>>(pacientes);
                    if (pacientesDto != null)
                    {
                        listaDto.AddRange(pacientesDto);
                        return listaDto;
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
        public ActionResult PostPaciente(DtoPaciente registrarPacienteDTO)
        {
            var paciente = _mapper.Map<Paciente>(registrarPacienteDTO);

            var historialMedico = _mapper.Map<HistorialMedico>(registrarPacienteDTO.HistorialMedico);
            var usuario = _mapper.Map<Usuario>(registrarPacienteDTO.Usuario);
            paciente.IdHistorialNavigation = historialMedico;
            paciente.IdUsuarioNavigation = usuario;

            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
            return Ok();
        }


        [HttpPut("api/Paciente/Put/{id}")]
        public async Task<ActionResult> modificar(int id, [FromBody] DtoPaciente dtoPaciente)
        {
            var paciente = await _context.Pacientes
                .Include(p => p.IdHistorialNavigation) // Incluimos la entidad HistorialMedico en la consulta
                .FirstOrDefaultAsync(p => p.IdPaciente == id);

            if (paciente == null)
            {
                return NotFound();
            }

            var nuevoPaciente = _mapper.Map<Paciente>(dtoPaciente);
            var historialMedico = _mapper.Map<HistorialMedico>(dtoPaciente.HistorialMedico);

            paciente.IdHistorialNavigation = historialMedico;
            paciente.Nombre = nuevoPaciente.Nombre;
            paciente.Apellido = nuevoPaciente.Apellido;
            paciente.Dni = nuevoPaciente.Dni;
            paciente.FechaNacimento = nuevoPaciente.FechaNacimento;
            paciente.Sexo = nuevoPaciente.Sexo;
            paciente.Email = nuevoPaciente.Email;
            paciente.Telefono = nuevoPaciente.Telefono;
            paciente.Antecedentes = nuevoPaciente.Antecedentes;
            //paciente.IdObraSocialNavigation = nuevoPaciente.IdObraSocialNavigation;
            if (dtoPaciente.IdObraSocial != null && paciente.IdObraSocial != null)
            {
                _mapper.Map(dtoPaciente.IdObraSocial, paciente.IdObraSocial);
                paciente.IdObraSocial = dtoPaciente.IdObraSocial;
            }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest("No se pudo guardar.");
            }

            return Ok();
        }



        [HttpGet("api/Paciente/{id}")]
        public async Task<ActionResult<DtoPaciente>> ObtenerPorId(int id)
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

            var resultadoPaciente = _mapper.Map<DtoPaciente>(paciente);

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
