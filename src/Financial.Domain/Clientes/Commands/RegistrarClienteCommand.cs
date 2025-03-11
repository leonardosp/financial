using Financial.Cross.Messages;

namespace Financial.Domain.Clientes.Commands;

public class RegistrarClienteCommand : Command
{
    public Guid Id { get; private set; }
    public string Nome { get; private set; }
    public string CPf { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public DateTime DataCadastro { get; private set; }

    public RegistrarClienteCommand()
    {
    }
}
