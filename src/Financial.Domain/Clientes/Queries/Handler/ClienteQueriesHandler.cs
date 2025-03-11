using Financial.Cross.Messages;
using Financial.Domain.Clientes.Interface;
using MediatR;

namespace Financial.Domain.Clientes.Queries.Handler;

public class ClienteQueriesHandler : CommandHandler,
             IRequestHandler<ObterClientePorCpfQuerie, Cliente>,
             IRequestHandler<ObterClientePorIdQuerie, Cliente>
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteQueriesHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<Cliente> Handle(ObterClientePorCpfQuerie request, CancellationToken cancellationToken)
    {
        return await _clienteRepository.ObterPorCpf(request.Cpf, cancellationToken);
    }

    public async Task<Cliente> Handle(ObterClientePorIdQuerie request, CancellationToken cancellationToken)
    {
        return await _clienteRepository.ObterPorId(request.Id, cancellationToken);
    }
}
