namespace OutPost.Modules.Commission.Domain;

public enum CommissionStatus
{
    UnderProcessing = 1 << 0,
    Retired = 1 << 2,
    Completed = 1 << 2,
}
