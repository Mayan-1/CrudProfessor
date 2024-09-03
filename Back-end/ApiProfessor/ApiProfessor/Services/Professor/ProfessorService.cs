using ApiProfessor.Config;
using ApiProfessor.Models;
using Microsoft.EntityFrameworkCore;
using ApiProfessor.Dto.Professor;

namespace ApiProfessor.Services.Professor
{
    public class ProfessorService : IProfessorService
    {
        private readonly AppDbContext _context;

        public ProfessorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<ProfessorModel>> Create(ProfessorDto professorDto)
        {
            ResponseModel<ProfessorModel> resposta = new ResponseModel<ProfessorModel>();
            try
            {

                var professor = new ProfessorModel()
                {
                    Nome = professorDto.Nome,
                    Cpf = professorDto.Cpf,
                    Telefone = professorDto.Telefone,
                    Email = professorDto.Email,
                    Senha = professorDto.Senha,
                    Materia = professorDto.Materia,
                };

                _context.Add(professor);
                await _context.SaveChangesAsync();

                resposta.Dados = professor;
                resposta.Mensagem = "Professor adicionado com sucesso";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<IEnumerable<ProfessorModel>>> Delete(int id)
        {
            ResponseModel<IEnumerable<ProfessorModel>> resposta = new ResponseModel<IEnumerable<ProfessorModel>>();
            try
            {
                var professor = await _context.Professores.FirstOrDefaultAsync(x => x.Id == id);

                if (professor == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                _context.Remove(professor);
                await _context.SaveChangesAsync();
                resposta.Dados = await _context.Professores.AsNoTracking().ToListAsync();
                resposta.Mensagem = "Professor deletado com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<ProfessorModel>> Get(int id)
        {
            ResponseModel<ProfessorModel> resposta = new ResponseModel<ProfessorModel>();
            try
            {
                var professor = await _context.Professores.FirstOrDefaultAsync(x => x.Id == id);

                if (professor == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                resposta.Dados = professor;
                resposta.Mensagem = "Professor localizado";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<IEnumerable<ProfessorModel>> GetAll()
        {
            try
            {
                var professores = await _context.Professores.ToListAsync();
                return professores;
            }
            catch (Exception ex)
            {
                throw ex;   
            }
        }

        public async Task<ProfessorModel> GetByName(string nome)
        {
            try
            {
                var professor = await _context.Professores.FirstOrDefaultAsync(x => x.Nome.StartsWith(nome));

                if(professor == null)
                {
                    return professor;
                }

                return professor;
            }catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<ResponseModel<IEnumerable<ProfessorModel>>> Update(int id, ProfessorDto professorDto)
        {
            ResponseModel<IEnumerable<ProfessorModel>> resposta = new ResponseModel<IEnumerable<ProfessorModel>>();
            try
            {
                var professor = await _context.Professores.FirstOrDefaultAsync(x => x.Id == id);

                if (professor == null)
                {
                    resposta.Mensagem = "Nenhum registro localizado";
                    return resposta;
                }

                professor.Nome = professorDto.Nome;
                professor.Cpf = professorDto.Cpf;
                professor.Email = professorDto.Email;
                professor.Senha = professorDto.Senha;
                professor.Telefone = professorDto.Telefone;
                professor.Materia = professorDto.Materia;
                _context.Entry(professor).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                resposta.Dados = await _context.Professores.ToListAsync();
                resposta.Mensagem = "Professor atualizado com sucesso";
                return resposta;


            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }
    }
}
