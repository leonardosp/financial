using Financial.Cross.Messages;
using FluentValidation.Results;

namespace Financial.Cross.Mediator;

public interface IMediatorHandler
{
    Task PublicarEvento<T>(T evento) where T : Event;
    Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
}
