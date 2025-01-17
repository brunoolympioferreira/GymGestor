using GymGestor.Core.Enums;

namespace GymGestor.Core.Exceptions;

public class GymGestorException : SystemException
{
    public GymGestorException(string message) : base(message) { }
}
