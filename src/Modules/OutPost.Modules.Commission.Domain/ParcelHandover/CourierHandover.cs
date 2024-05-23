﻿using OutPost.Shared.Abstractions.Localization;

namespace OutPost.Modules.Commission.Domain.ParcelHandover;

public class CourierHandover : Handover
{
    public CourierHandover(Address pickupAddress)
    {
        PickupAddress = pickupAddress;
    }

    public Address PickupAddress { get; }
    public ParcelHandoverType ParcelHandoverType => ParcelHandoverType.Courier;
}