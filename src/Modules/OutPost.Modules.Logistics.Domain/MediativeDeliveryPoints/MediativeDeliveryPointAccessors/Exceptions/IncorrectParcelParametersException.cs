using OutPost.Shared.Abstractions.Exceptions.Types;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Exceptions;

public class IncorrectParcelParametersException : CoreException
{
    public IncorrectParcelParametersException(string text) : base(text)
    {
    }
}