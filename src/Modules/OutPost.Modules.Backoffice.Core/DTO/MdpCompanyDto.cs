using OutPost.Modules.Backoffice.Core.Entities;

namespace OutPost.Modules.Backoffice.Core.DTO;

public class MdpCompanyDto
{
    public string Name { get; set; }
    public decimal MarkupPercentage { get; set; }
    public MdpTypes MdpTypes { get; set; }
}
