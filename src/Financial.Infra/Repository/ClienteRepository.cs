using Financial.Cross.Data;
using Financial.Domain.Clientes;
using Financial.Domain.Clientes.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace Financial.Infra.Repository;

public class ClienteRepository : IClienteRepository
{
    private readonly FinancialDbContext _context;

    public ClienteRepository(FinancialDbContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public DbConnection ObterConexao() => _context.Database.GetDbConnection();

    public void Adicionar(Cliente cliente)
    {
        _context.Clientes.Add(cliente);
    }

    public void Atualizar(Cliente cliente)
    {
        _context.Clientes.Update(cliente);
    }

    public async Task<Cliente> ObterPorCpf(string cpf, CancellationToken cancellationToken)
    {
        return await _context.Clientes.FirstOrDefaultAsync(x => x.Cpf == cpf, cancellationToken);
    }

    public async Task<Cliente> ObterPorId(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Clientes.FirstOrDefaultAsync(x => x.Id == id, cancellationToken).ConfigureAwait(false);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

}
