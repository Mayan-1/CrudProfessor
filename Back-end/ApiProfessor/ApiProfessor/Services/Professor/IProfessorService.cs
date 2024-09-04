using ApiProfessor.Models;
using ApiProfessor.Dto;
using ApiProfessor.Dto.Professor;

namespace ApiProfessor.Services.Professor
{
    public interface IProfessorService
    {
        Task<IEnumerable<ProfessorModel>> GetAll();
        Task<ProfessorModel> GetByName(string nome);
        Task<ProfessorModel> Get(int id);
        Task<ResponseModel<ProfessorModel>> Create(ProfessorDto professorDto);
        Task<ProfessorModel> Update(int id, ProfessorEdicaoDto professorDto);
        Task<ResponseModel<IEnumerable<ProfessorModel>>> Delete(int id);
    }
}
