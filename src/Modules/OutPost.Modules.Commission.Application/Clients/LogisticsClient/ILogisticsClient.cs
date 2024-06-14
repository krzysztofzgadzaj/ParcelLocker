namespace OutPost.Modules.Commission.Application.Clients.LogisticsClient;

public interface ILogisticsClient
{
    Task ReserveForClient(Guid mdpId, Guid id);
    Task ReserveClosestMdp(Guid mdpId, Guid id);
    Task CreateSubmission();
}