using Financial.Cross.Messages;

namespace Financial.Domain.Clientes.Events;

public class ClienteAdicionadoSolicitaCartaoEvent : Event
{
    public Guid ClienteId { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public string Cpf { get; private set; }

    public ClienteAdicionadoSolicitaCartaoEvent(Guid clienteId, DateTime dataNascimento, string cpf)
    {
        ClienteId = clienteId;
        DataNascimento = dataNascimento;
        Cpf = cpf;
    }
}
