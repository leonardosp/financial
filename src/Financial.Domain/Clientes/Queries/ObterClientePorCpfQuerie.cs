using Financial.Cross.Messages;

namespace Financial.Domain.Clientes.Queries;

public class ObterClientePorCpfQuerie : Querie<Cliente>
{
    public string Cpf { get; set; }
    public ObterClientePorCpfQuerie(string cpf)
    {
        Cpf = cpf;
    }
}
