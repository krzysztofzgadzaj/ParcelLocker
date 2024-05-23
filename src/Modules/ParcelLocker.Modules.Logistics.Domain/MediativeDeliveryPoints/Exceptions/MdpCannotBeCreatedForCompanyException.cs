﻿using ParcelLocker.Shared.Abstractions.Exceptions.Types;

namespace ParcelLocker.Modules.Logistics.Domain.MediativeDeliveryPoints.Exceptions;

public class MdpCannotBeCreatedForCompanyException : CoreException
{
    public MdpCannotBeCreatedForCompanyException(string text) : base(text)
    {
    }
}