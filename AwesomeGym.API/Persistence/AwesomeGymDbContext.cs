using AwesomeGym.API.Entidades;
using AwesomeGym.API.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AwesomeGym.API.Persistence
{
    public class AwesomeGymDbContext : DbContext
    {
        public AwesomeGymDbContext(DbContextOptions<AwesomeGymDbContext> options)
            : base(options)
        {

        }

        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Unidade> Unidades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UnidadeConfiguration());
            modelBuilder.ApplyConfiguration(new AlunoConfiguration());
            modelBuilder.ApplyConfiguration(new ProfessorConfiguration());
        } 
    }
}
