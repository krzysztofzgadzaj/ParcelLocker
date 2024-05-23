using OutPost.Shared.Abstractions.Exceptions.Types;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;

public class IncorrectParcelParametersException : CoreException
{
    public IncorrectParcelParametersException(string text) : base(text)
    {
    }
}