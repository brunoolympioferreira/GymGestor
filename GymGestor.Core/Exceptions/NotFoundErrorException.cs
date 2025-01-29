namespace GymGestor.Core.Exceptions;
public class NotFoundErrorException : GymGestorException
{
    public NotFoundErrorException(string errorMessage) : base(errorMessage) { }
}
