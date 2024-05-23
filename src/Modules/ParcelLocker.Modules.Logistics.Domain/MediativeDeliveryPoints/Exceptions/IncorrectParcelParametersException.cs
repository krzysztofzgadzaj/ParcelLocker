using ParcelLocker.Shared.Abstractions.Exceptions.Types;

namespace ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;

public class IncorrectParcelParametersException : CoreException
{
    public IncorrectParcelParametersException(string text) : base(text)
    {
    }
}