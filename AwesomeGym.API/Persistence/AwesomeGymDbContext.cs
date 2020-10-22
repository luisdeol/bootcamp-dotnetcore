using AwesomeGym.API.Entidades;
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
            modelBuilder.Entity<Aluno>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Professor>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Professor>()
                .HasMany(p => p.Alunos)
                .WithOne(a => a.Professor)
                .HasForeignKey(a => a.IdProfessor)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Unidade>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Unidade>()
                .HasMany(u => u.Alunos)
                .WithOne(a => a.Unidade)
                .HasForeignKey(a => a.IdUnidade)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Unidade>()
               .HasMany(u => u.Professores)
               .WithOne(p => p.Unidade)
               .HasForeignKey(a => a.IdUnidade)
               .OnDelete(DeleteBehavior.Restrict);
        } 
    }
}
