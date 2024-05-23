# Parcel Locker

1.  Basic requirements gathered on alignment process
    1.1 Customer perspective
        1.1.1 System should allow private users to send and pick up parcels from/to home and from/to pick up point.
        1.1.2 Pick up point might be parcel locker and some shops (like "froggie"). New pick up points might be added.
        1.1.3 User should has the option to created account and see all parcels associeted to this account.
        1.1.4 User can see current state of the parcel on his account or by searching this parcel using its id.
        1.1.5 If user sends or picks up parcel without registering the process proceeding by email and sms.
        1.1.6 Picking up and sending require phone number and code (different codes for sending and picking).
    1.2 Courier perspective
        1.2.1 


1. Logistics requirements:
    1.1 Amount of parcels to pick up and transport is calculated by external system called "JebacAEI". It doesn't provide any API so user has to rewrite it manually.
    1.2 Logistics part of this system needs to collect data about all parcels to transform, then send that data to JebacAEI which will generate list of parcels to collect and to deliver in a period of time.
    1.3 JebacAEI only returns list of parcels and estimation about how much time and trucks it takes to deliver it. Storehouse manager has to assign parcels to trucks.