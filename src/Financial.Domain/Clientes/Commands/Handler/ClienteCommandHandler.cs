using Financial.Cross.Messages;
using Financial.Domain.Clientes.Events;
using Financial.Domain.Clientes.Interface;
using FluentValidation.Results;
using MediatR;

namespace Financial.Domain.Clientes.Commands.Handler;

public class ClienteCommandHandler : CommandHandler,
                                     IRequestHandler<RegistrarClienteCommand, ValidationResult>
{
    private readonly IClienteRepository _clienteRepository;

    public ClienteCommandHandler(IClienteRepository clienteRepository)
    {
        _clienteRepository = clienteRepository;
    }

    public async Task<ValidationResult> Handle(RegistrarClienteCommand request, CancellationToken cancellationToken)
    {
        var cliente = new Cliente(request.Nome, request.CPf, request.DataNascimento, request.DataCadastro);

        _clienteRepository.Adicionar(cliente);
        cliente.AdicionarEvento(new ClienteAdicionadoSolicitaCartaoEvent(cliente.Id, cliente.DataNascimento, cliente.Cpf));

        return await PersistirDados(_clienteRepository.UnitOfWork);
    }
}
