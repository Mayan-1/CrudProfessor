using ApiProfessor.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ApiProfessor.Config;

public class AppDbContext : DbContext
{


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

  
    public DbSet<ProfessorModel> Professores { get; set; }
  
}
