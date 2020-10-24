using AwesomeGym.API.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AwesomeGym.API.Persistence.Configurations
{
    public class UnidadeConfiguration : IEntityTypeConfiguration<Unidade>
    {
        public void Configure(EntityTypeBuilder<Unidade> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .HasMany(u => u.Alunos)
                .WithOne(a => a.Unidade)
                .HasForeignKey(a => a.IdUnidade)
                .OnDelete(DeleteBehavior.Restrict);

            builder
               .HasMany(u => u.Professores)
               .WithOne(p => p.Unidade)
               .HasForeignKey(a => a.IdUnidade)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
