using OutPost.Shared.Abstractions.Exceptions.Types;

namespace OutPost.Modules.Commission.Application.Exceptions;

public class MdpNotFoundException : NotFoundException
{
    public MdpNotFoundException(string text) : base(text)
    {
    }
}
