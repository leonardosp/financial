using AutoMapper;
using Financial.Application.Base;
using Financial.Application.models;
using Financial.Application.Services.Interfaces;
using Financial.Cross.Mediator;
using Financial.Domain.Clientes.Commands;
using Financial.Domain.Clientes.Queries;
using FluentValidation.Results;
using MediatR;

namespace Financial.Application.Services;

public class ClienteAppService : ApplicationBase, IClienteAppService
{
    private readonly IMediatorHandler _mediatorHandler;
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ClienteAppService(IMediatorHandler mediatorHandler, IMediator mediator, IMapper mapper)
    {
        _mediatorHandler = mediatorHandler;
        _mediator = mediator;
        _mapper = mapper;
    }

    public async Task<ClienteViewModel> ObterPorCpf(string cpf)
    {
        var command = new ObterClientePorCpfQuerie(cpf);

        return _mapper.Map<ClienteViewModel>(await _mediator.Send(command));
    }

    public async Task<ClienteViewModel> ObterPorId(Guid id)
    {
        var command = new ObterClientePorIdQuerie(id);

        return _mapper.Map<ClienteViewModel>(await _mediator.Send(command));
    }

    public async Task<ValidationResult> RegistrarCliente(ClienteViewModel clienteViewModel)
    {
        var ClienteExiste = await ClienteExistente(clienteViewModel.Cpf);

        if (ClienteExiste)
        {
            AdicionarErroValidation($"Já existe cliente cadastrado com este Cpf: {clienteViewModel.Cpf}");
            return ValidationResult;
        }

        var command = _mapper.Map<RegistrarClienteCommand>(clienteViewModel);

        return await _mediatorHandler.EnviarComando(command);
    }

    private async Task<bool> ClienteExistente(string? cpf)
    {
        var clienteExiste = new ClienteViewModel();

        if (cpf != string.Empty)
        {
            clienteExiste = await ObterPorCpf(cpf);
        }

        if (clienteExiste == null)
        {
            return false;
        }

        return true;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
