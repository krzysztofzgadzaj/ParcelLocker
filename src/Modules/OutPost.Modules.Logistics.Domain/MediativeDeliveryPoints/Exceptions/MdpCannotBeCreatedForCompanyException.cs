using OutPost.Shared.Abstractions.Exceptions.Types;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;

public class MdpCannotBeCreatedForCompanyException : CoreException
{
    public MdpCannotBeCreatedForCompanyException(string text) : base(text)
    {
    }
}
