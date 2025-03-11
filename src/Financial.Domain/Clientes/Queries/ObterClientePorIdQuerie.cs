using Financial.Cross.Messages;

namespace Financial.Domain.Clientes.Queries;

public class ObterClientePorIdQuerie : Querie<Cliente>
{
    public Guid Id { get; set; }

    public ObterClientePorIdQuerie(Guid id)
    {
        Id = id;
    }
}
