using AutoMapper;
using Financial.Application.models;
using Financial.Domain.Clientes;
using Financial.Domain.Clientes.Commands;

namespace Financial.Application.Mappings;

public class ClienteMapping : Profile
{
    public ClienteMapping()
    {
        CreateMap<ClienteViewModel, RegistrarClienteCommand>();
        CreateMap<Cliente, ClienteViewModel>().ReverseMap();
    }
}
