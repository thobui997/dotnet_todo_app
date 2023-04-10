using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoApp.API.Domain.Models;

namespace ToDoApp.API.Persistence.Contexts.Configurations;

public class ToDoConfiguration : IEntityTypeConfiguration<ToDo>
{
    public void Configure(EntityTypeBuilder<ToDo> builder)
    {
        builder.ToTable("ToDo");
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id).IsRequired().HasColumnType("uuid").HasDefaultValueSql("uuid_generate_v4()")
            .ValueGeneratedOnAdd();
        builder.Property(t => t.Name).HasMaxLength(30);
    }
}