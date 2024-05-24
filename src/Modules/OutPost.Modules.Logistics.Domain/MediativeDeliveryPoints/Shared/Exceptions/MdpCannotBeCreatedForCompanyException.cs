using OutPost.Shared.Abstractions.Exceptions.Types;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.Shared.Exceptions;

public class MdpCannotBeCreatedForCompanyException : CoreException
{
    public MdpCannotBeCreatedForCompanyException(string text) : base(text)
    {
    }
}
