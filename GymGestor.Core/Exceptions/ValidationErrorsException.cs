using GymGestor.Core.Enums;

namespace GymGestor.Core.Exceptions;
public class ValidationErrorsException : GymGestorException
{
    public List<string> ErrorMessages { get; set; }
    public ValidationErrorsException(List<string> errorMessages) : base(string.Empty)
    {
        ErrorMessages = errorMessages;
    }
    public ValidationErrorsException(string errorMessage) : base(errorMessage) { }
}
