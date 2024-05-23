using ParcelLocker.Shared.Abstractions.Exceptions.Types;

namespace ParcelLocker.Modules.Backoffice.Core.Exceptions;

public class IncorrectMdpCompanyMarkupValueException : CoreException
{
    private const string MessageFormat = "Markup: {0} is not valid as mdp company markup";
    
    public IncorrectMdpCompanyMarkupValueException(decimal markup) : base(string.Format(MessageFormat, markup))
    {
    }
}
