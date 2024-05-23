using OutPost.Modules.Backoffice.Core.DTO;
using OutPost.Modules.Backoffice.Core.Exceptions;

namespace OutPost.Modules.Backoffice.Core.Validators;

public class MdpCompanyValidator
{
    public void ValidateDto(MdpCompanyDto mdpCompanyDto)
    {
        if (mdpCompanyDto.Name.Length == 0)
        {
            throw new IncorrectMdpCompanyNameException(mdpCompanyDto.Name);
        }

        if (mdpCompanyDto.MarkupPercentage <= 0)
        {
            throw new IncorrectMdpCompanyMarkupValueException(mdpCompanyDto.MarkupPercentage);
        }
    }
}
