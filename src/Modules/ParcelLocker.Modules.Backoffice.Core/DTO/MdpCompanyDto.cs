using ParcelLocker.Modules.Backoffice.Core.Entities;

namespace ParcelLocker.Modules.Backoffice.Core.DTO;

public class MdpCompanyDto
{
    public string Name { get; set; }
    public decimal MarkupPercentage { get; set; }
    public MdpTypes MdpTypes { get; set; }
}
