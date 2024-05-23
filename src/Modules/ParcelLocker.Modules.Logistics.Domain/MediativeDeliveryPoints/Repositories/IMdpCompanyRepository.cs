﻿namespace ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Repositories;

public interface IMdpCompanyRepository
{
    Task Add(MdpCompany mdpCompany);
    Task<MdpCompany?> GetById(MdpCompanyId id);
    Task<IEnumerable<MdpCompany>> GetMdpCompanies();
}
