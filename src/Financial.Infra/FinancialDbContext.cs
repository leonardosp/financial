using Financial.Cross.Data;
using Financial.Cross.Mediator;
using Financial.Cross.Messages;
using Financial.Domain.Clientes;
using Financial.Infra.Extensions;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace Financial.Infra;

public class FinancialDbContext : DbContext, IUnitOfWork
{
    private readonly IMediatorHandler _mediatorHandler;

    public FinancialDbContext(DbContextOptions<FinancialDbContext> options, IMediatorHandler mediatorHandler) : base(options)
    {
        _mediatorHandler = mediatorHandler;
    }

    public DbSet<Cliente> Clientes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Ignore<ValidationResult>();
        modelBuilder.Ignore<Event>();
    }

    public async Task<bool> Commit()
    {
        foreach (var entry in ChangeTracker.Entries()
            .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
        {
            if (entry.State == EntityState.Added)
            {
                entry.Property("DataCadastro").CurrentValue = DateTime.UtcNow;
            }

            if (entry.State == EntityState.Modified)
            {
                entry.Property("DataCadastro").IsModified = false;
            }
        }

        var sucesso = await base.SaveChangesAsync() > 0;
        if (sucesso) await _mediatorHandler.PublicarEventos(this);

        return sucesso;
    }
}
