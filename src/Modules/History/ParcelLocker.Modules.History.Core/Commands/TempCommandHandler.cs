using ParcelLocker.Shared.Abstractions.Commands;

namespace ParcelLocker.Modules.History.Core.Commands;

public class TempCommandHandler : ICommandHandler<TempCommand>
{
    public async Task SendAsync(TempCommand command)
    {
        Console.WriteLine("From temp command handler");
    }
}