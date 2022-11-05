using AutoMapper;
using CarroAPI.Data;
using CarroAPI.Model;
using CarrosAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CarroAPI.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CarroController : ControllerBase
    {
        private CarroContext _context;
        private IMapper _mapper;
        public CarroController(CarroContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionarCarro([FromBody] CreateCarroDTO carroDto)
        {
            Carro carro = _mapper.Map<Carro>(carroDto);
            _context.Carros.Add(carro);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarCarroPorId), new {id = carro.Id}, carro) ;

        }
        [HttpGet]
        public IEnumerable<Carro> RecuperarCarro()
        {   
            return _context.Carros;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCarroPorId(int id)
        {
            Carro carro = _context.Carros.FirstOrDefault(carro => carro.Id == id);
            if (carro != null){
                ReadCarroDto carroDto = _mapper.Map<ReadCarroDto>(carro);
               return Ok(carroDto);   
            }
            return NotFound();
        }
        [HttpPut("{id}")]
        public IActionResult AtualizaCarro(int id, [FromBody] UpdateCarroDTO carroDto)
        {
            Carro carro = _context.Carros.FirstOrDefault(carro => carro.Id == id);
            if (carro == null)
            {
                return NotFound();
            }
            _mapper.Map(carroDto, carro);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult DeletaCarro(int id)
        {
            Carro carro = _context.Carros.FirstOrDefault(carro => carro.Id == id);
            if (carro == null)
            {
                return NotFound();
            }
            _context.Remove(carro);
            _context.SaveChanges();
            return NoContent();

        }
    }
}
