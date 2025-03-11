using Financial.Cross.Utils;

namespace Financial.Domain.Clientes;

public class Cliente : Entity
{
    public string Nome { get; private set; }
    public string Cpf { get; private set; }
    public DateTime DataNascimento { get; private set; }
    public DateTime DataCadastro { get; private set; }

    public Cliente(string nome, string cpf, DateTime dataNascimento, DateTime dataCadastro)
    {
        Nome = nome;
        Cpf = cpf;
        DataNascimento = dataNascimento;
        DataCadastro = dataCadastro;
    }
}
