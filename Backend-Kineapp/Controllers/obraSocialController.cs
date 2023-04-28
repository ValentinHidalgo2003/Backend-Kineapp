using AutoMapper;
using Backend_Kineapp.Dtos;
using Backend_Kineapp.Modelos;
using Backend_Kineapp.Resultados;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend_Kineapp.Controllers
{
    [ApiController]
    public class obraSocialController : ControllerBase
    {
        private readonly KineappContext _context;
        private readonly IMapper _mapper;

        public obraSocialController(KineappContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet("api/obraSocial/Get")]
        public async Task<ActionResult<List<DtoObraSocial>>> getObras()
        {
            try
            {
                var listaDto = new List<DtoObraSocial>();
                var obras = await _context.ObraSocials.ToListAsync();
                if (obras != null)
                {
                    var obrasDto = _mapper.Map<List<DtoObraSocial>>(obras);
                    if (obrasDto != null)
                    {
                        listaDto.AddRange(obrasDto);

                        return listaDto;
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


        [HttpGet("api/obraSocial/{id}")]
        public async Task<ActionResult<DtoObraSocial>> ObtenerPorId(int id)
        {
            var obras = await _context.ObraSocials.FirstOrDefaultAsync(o => o.IdObra == id);
            if (obras == null)
            {
                return NotFound();
            }
            return Ok(obras);
        }
    }
}

