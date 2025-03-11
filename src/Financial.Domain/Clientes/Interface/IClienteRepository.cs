using Financial.Cross.Data;

namespace Financial.Domain.Clientes.Interface;

public interface IClienteRepository : IRepository<Cliente>
{
    Task<Cliente> ObterPorId(Guid id, CancellationToken cancellationToken);
    Task<Cliente> ObterPorCpf(string cpf, CancellationToken cancellationToken);
    void Adicionar(Cliente cliente);
    void Atualizar(Cliente cliente);
}
    