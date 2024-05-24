namespace OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.DTO;

public class AddressDto
{
    public AddressDto()
    {
    }
    
    public AddressDto(string address, string city, string country)
    {
        Address = address;
        City = city;
        Country = country;
    }

    public string Address { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
}
