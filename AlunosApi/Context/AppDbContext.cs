using AlunosApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlunosApi.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
        public DbSet<Aluno> Alunos {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>().HasData(
                new Aluno
                {
                    Id = 1,
                    Nome = "Maria",
                    Email = "maria@yahoo.com",
                    Idade = 24
                },
                new Aluno 
                { 
                    Id = 2,
                    Nome = "Fernanda",
                    Email = "fe@yahoo.com",
                    Idade = 20
                },
                new
                  {
                      Id = 3,
                      Email = "camis@yahoo.com",
                      Idade = 24,
                      Nome = "Camila"
                  },
                        new
                        {
                            Id = 4,
                            Email = "iara@yahoo.com",
                            Idade = 20,
                            Nome = "Iara"
                        }
        
            );
            base.OnModelCreating(modelBuilder);
        }

    }

}
