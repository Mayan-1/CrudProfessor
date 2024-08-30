using ApiProfessor.Models;
using ApiProfessor.Dto.Professor;

namespace ApiProfessor.Services.Professor
{
    public interface IProfessorService
    {
        Task<IEnumerable<ProfessorModel>> GetAll();
        Task<ProfessorModel> GetByName(string nome);
        Task<ResponseModel<ProfessorModel>> Get(int id);
        Task<ResponseModel<ProfessorModel>> Create(ProfessorDto professorDto);
        Task<ResponseModel<IEnumerable<ProfessorModel>>> Update(int id, ProfessorDto professorDto);
        Task<ResponseModel<IEnumerable<ProfessorModel>>> Delete(int id);
    }
}
