using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaDeTarefas.Models;

namespace SistemaDeTarefas.Data.Map
{
    public class TarefaMap : IEntityTypeConfiguration<TarefaModel>
    {
        public void Configure(EntityTypeBuilder<TarefaModel> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Nome).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Descricao).HasMaxLength(1000);
            builder.Property(t => t.Status).IsRequired();
        }
    }
}
