namespace OutPost.Modules.Backoffice.Core.Repositories.OutpostConfiguration;

class OutpostConfigurationRepository : IOutpostConfigurationRepository
{
    private readonly List<Entities.OutpostConfiguration> _outpostConfigurations = new()
    {
        new Entities.OutpostConfiguration
        {
            Id = Guid.NewGuid(),
            OutpostMarkup = 10
        }
    };

    public async Task UpdateOutpostMarkup(decimal markup)
        => _outpostConfigurations.First().OutpostMarkup = markup;
    
    public async Task<Entities.OutpostConfiguration> GetSingle()
        => _outpostConfigurations.First();
}
