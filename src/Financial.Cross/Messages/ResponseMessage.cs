using FluentValidation.Results;

namespace Financial.Cross.Messages;

public class ResponseMessage : Message
{
    public ValidationResult ValidationResult { get; set; }

    public ResponseMessage(ValidationResult validationResult)
    {
        ValidationResult = validationResult;
    }
}
