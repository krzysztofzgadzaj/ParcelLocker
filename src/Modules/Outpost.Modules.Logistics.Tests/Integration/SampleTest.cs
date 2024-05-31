using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.Commands.CreateParcelLocker;
using OutPost.Modules.Logistics.Application.MediativeDeliveryPoints.DTO;
using OutPost.Modules.Logistics.Infrastructure.Persistence;
using Xunit;

namespace Outpost.Modules.Logistics.Tests.Integration;

public class SampleTest : BaseTestClass
{
    [Fact]
    public async Task Siema()
    {
        var siema = Factory.CreateClient();

        var dupa = new CreateDraftParcelLockerCommand();
        dupa.Address = new AddressDto
        {
            Address = "address",
            Country = "fds",
            City = "fasddgs"
        };
        dupa.SerialCode = "serial";

        string userIdsJson = JsonConvert.SerializeObject(dupa);
        var body = new StringContent(userIdsJson, Encoding.UTF8, "application/json");
        
        var karamba = await siema.GetAsync("logistics-module/mediative-delivery-point-companies");
        var elo = await siema.PostAsync("logistics-module/mediative-delivery-points/type/parcel-locker", body);
        var siema3 = "siema";
        using var scope = Factory.Services.CreateScope();

        var tratwa = scope.ServiceProvider.GetService<LogisticsContext>();
        
        var lalala = await tratwa.MediativeDeliveryPointsPoints.ToListAsync();
    }
}
