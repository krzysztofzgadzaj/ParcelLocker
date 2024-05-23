using OutPost.Shared.Abstractions.Exceptions.Types;

namespace OutPost.Modules.Backoffice.Core.Exceptions;

public class IncorrectMdpCompanyNameException : CoreException
{
    private const string MessageFormat = "Name: {0} is not valid as mdp company name";
    public IncorrectMdpCompanyNameException(string companyName) : base(string.Format(MessageFormat, companyName))
    {
    }
}
