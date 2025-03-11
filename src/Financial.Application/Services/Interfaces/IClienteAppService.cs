using Financial.Application.models;
using FluentValidation.Results;

namespace Financial.Application.Services.Interfaces;

public interface IClienteAppService : IDisposable
{
    public Task<ValidationResult> RegistrarCliente(ClienteViewModel clienteViewModel);
    public Task<ClienteViewModel> ObterPorCpf(string cpf);
    public Task<ClienteViewModel> ObterPorId(Guid id);
}
