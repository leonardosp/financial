using Financial.Cross.Messages;

namespace Financial.Domain.Clientes.Events;

public class ClienteAdicionadoSolicitaConsignadoEvent : Event
{
    public Guid ClienteId { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string Cpf { get; private set; }

    public ClienteAdicionadoSolicitaConsignadoEvent(Guid clienteId, DateTime dataNascimento, string cpf)
    {
        ClienteId = clienteId;
        DataNascimento = dataNascimento;
        Cpf = cpf;
    }
}
