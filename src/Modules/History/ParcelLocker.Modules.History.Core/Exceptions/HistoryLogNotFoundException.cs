using ParcelLocker.Shared.Abstractions.Exceptions;

namespace ParcelLocker.Modules.History.Core.Exceptions;

public class HistoryLogNotFoundException : CoreException
{
    public HistoryLogNotFoundException(int id) 
        : base($"History log with id: {id} was not found")
    {
    }
}
