using ParcelLocker.Modules.Storage.Core.DomainEvents;
using ParcelLocker.Modules.Storage.Core.Exceptions;
using ParcelLocker.Shared.Abstractions.Kernel.Types;

namespace ParcelLocker.Modules.Storage.Core.Entities;

public class Storage : AggregateRoot
{
    public string Name { get; private set; }
    public int Load { get;  private set; }

    public void UpdateName(string name)
    {
        if (name.Length < 3)
        {
            throw new IncorrectNameException("Name to short");
        }

        Name = name;
        AddEvent(new StorageNameChanged(this));
    }
    
    public void UpdateLoad(int load)
    {
        if (load < 3)
        {
            throw new IncorrectNameException("Name to short");
        }

        Load = load;
        AddEvent(new StorageLoadChanged(this));
    }
}