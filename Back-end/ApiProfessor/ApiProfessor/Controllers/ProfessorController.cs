using ApiProfessor.Dto.Professor;
using ApiProfessor.Models;
using ApiProfessor.Services.Professor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProfessor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorService _professorService;

        public ProfessorController(IProfessorService professorService)
        {
            _professorService = professorService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProfessorModel>> Get(int id)
        {
            var professor = await _professorService.Get(id);
            return Ok(professor);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProfessorModel>>> GetAll()
        {
            var professores = await _professorService.GetAll();
            return Ok(professores);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<ProfessorModel>>> Create(ProfessorDto professorDto)
        {
            var professor = await _professorService.Create(professorDto);
            return Ok(professor);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<ResponseModel<ProfessorModel>>> Update(int id, ProfessorDto professorDto)
        {
            var professor = await _professorService.Update(id, professorDto);
            return Ok(professor);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ResponseModel<IEnumerable<ProfessorModel>>>> Delete(int id)
        {
            var professores = await _professorService.Delete(id);
            return Ok(professores);
        }

        [HttpGet("{nome}")]
        public async Task<ActionResult<ProfessorModel>> GetByName(string nome)
        {
            var professor = await _professorService.GetByName(nome);
            return Ok(professor);
        }
    }
}
