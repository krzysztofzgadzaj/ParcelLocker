using ParcelLocker.Shared.Abstractions.Exceptions.Types;

namespace ParcelLocker.Modules.History.Core.Exceptions;

internal class HistoryLogNotFoundException : NotFoundException
{
    public HistoryLogNotFoundException(int id) 
        : base($"History log with id: {id} was not found")
    {
    }
}
