using Financial.Domain.Clientes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Financial.Infra.Mappings;

public class ClienteMapping : IEntityTypeConfiguration<Domain.Clientes.Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasKey(c => c.Id);

        builder.HasIndex(c => c.Cpf).IsUnique();

        builder.ToTable("Clientes");
    }
}
