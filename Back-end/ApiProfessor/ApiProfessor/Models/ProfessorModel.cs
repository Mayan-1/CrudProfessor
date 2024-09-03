using System.ComponentModel.DataAnnotations;

namespace ApiProfessor.Models;

public class ProfessorModel
{
    public int Id { get; set; }
    [Required]
    [StringLength(30)]
    public string? Nome { get; set; }
    [Required]
    [StringLength(14)]
    public string? Cpf { get; set; }
    [Required]
    [StringLength(40)]
    public string? Email { get; set; }
    [Required]
    [StringLength(15)]
    public string? Senha { get; set; }
    [Required]
    [StringLength(15)]
    public string? Telefone { get; set; }
    [Required]
    [StringLength(30)]
    public string? Materia { get; set; }



}
