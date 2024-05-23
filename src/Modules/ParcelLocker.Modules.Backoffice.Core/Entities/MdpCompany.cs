namespace ParcelLocker.Modules.Backoffice.Core.Entities;

public class MdpCompany
{
    public MdpCompany(string name, decimal markupPercentage, MdpTypes mdpTypes)
    {
        Id = new MdpCompanyId(Guid.NewGuid());
        Name = name;
        MarkupPercentage = markupPercentage;
        MdpTypes = mdpTypes;
    }

    public MdpCompanyId Id { get; }
    public string Name { get; }
    public decimal MarkupPercentage { get; }
    public DateTime TempTime { get; set; }
    public MdpTypes MdpTypes { get; }
}
