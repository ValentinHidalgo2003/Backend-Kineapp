using AutoMapper;
using Backend_Kineapp.Dtos;
using Backend_Kineapp.Modelos;
using Backend_Kineapp.Resultados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Kineapp.Controllers
{
    [ApiController]
    public class HistorialController : ControllerBase
    {
        private readonly KineappContext _context;
        private readonly IMapper _mapper;

        public HistorialController(KineappContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("api/Historial/Get")]
        public async Task<ActionResult<List<ResultadoHistorial>>> GetHistoriales()
        {
            try
            {
                var listaDto = new List<DtoHistorial>();
                var resultado = new List<ResultadoHistorial>();
                var historiales = await _context.HistorialMedicos.ToListAsync();
                if (historiales != null)
                {
                    var historialDto = _mapper.Map<List<DtoHistorial>>(historiales);
                    var resultadoHistorial = _mapper.Map<List<ResultadoHistorial>>(historialDto);
                    if (resultadoHistorial != null)
                    {
                        resultado.AddRange(resultadoHistorial);

                        return resultado;
                    }
                    else return BadRequest("fallo el mapeo");
                }
                else
                {
                    return StatusCode(500, "No hay historiales");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Fallo la solicitud: {ex.Message}");
            }
        }

        [HttpPost("api/Historial/Post")]
        public async Task<ActionResult<DtoHistorial>> PostPaciente(DtoHistorial historial)
        {
                var historialMap = _mapper.Map<HistorialMedico>(historial);
                _context.HistorialMedicos.Add(historialMap);
                await _context.SaveChangesAsync();
                return Ok(historialMap);
        }

        [HttpPut("api/Historial/Put/{id}")]
        public async Task<ActionResult> modificar(int id, [FromBody] DtoHistorial dtoHistorial)
        {
            var historial = await _context.HistorialMedicos.FindAsync(id);

            if (historial == null)
            {
                return NotFound();
            }

            var nuevoHistorial = _mapper.Map<HistorialMedico>(dtoHistorial);
            historial.Nota = nuevoHistorial.Nota;
            historial.Descripcion = historial.Descripcion;
            historial.FechaCreacion = nuevoHistorial.FechaCreacion;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                BadRequest("no se pudo guardar");
            }

            return Ok(historial);
        }

        [HttpGet("api/Historial/{id}")]
        public async Task<ActionResult<ResultadoHistorial>> ObtenerPorId(int id)
        {
            var historial = await _context.HistorialMedicos.FirstOrDefaultAsync(p => p.IdHistorial == id);
            if (historial == null)
            {
                return NotFound();
            }

            var resultadoHistorial = _mapper.Map<ResultadoHistorial>(historial);

            return Ok(resultadoHistorial);
        }

        [HttpDelete("api/Historial/Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var historial = await _context.HistorialMedicos.FindAsync(id);
            if (historial == null)
            {
                return NotFound($"No se encontro el historial con el Id {id}");
            }
            _context.HistorialMedicos.Remove(historial);
            await _context.SaveChangesAsync();

            return Ok(historial);
        }
    }
}
