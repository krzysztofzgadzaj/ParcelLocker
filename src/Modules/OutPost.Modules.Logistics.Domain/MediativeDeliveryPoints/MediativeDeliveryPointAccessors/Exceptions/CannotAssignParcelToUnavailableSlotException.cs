﻿using OutPost.Shared.Abstractions.Exceptions.Types;

namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.Exceptions;

public class CannotAssignParcelToUnavailableSlotException : DomainException
{
    public CannotAssignParcelToUnavailableSlotException(string text) : base(text)
    {
    }
}
