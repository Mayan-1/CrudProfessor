﻿using ApiProfessor.Models;

namespace ApiProfessor.Dto.Professor
{
    public class ProfessorDto
    {
        public string? Nome { get; set; }
        public string? Cpf { get; set; }
        public string? Email { get; set; }
        public string? Telefone { get; set; }
        public string? Materia { get; set; }
    }
}
