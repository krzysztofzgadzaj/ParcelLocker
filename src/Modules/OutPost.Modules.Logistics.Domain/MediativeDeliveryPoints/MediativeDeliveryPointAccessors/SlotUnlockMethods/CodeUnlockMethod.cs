namespace OutPost.Modules.Logistics.Domain.MediativeDeliveryPoints.MediativeDeliveryPointAccessors.SlotUnlockMethods;

public class CodeUnlockMethod
{
    public CodeUnlockMethod(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
        Code = GenerateSixDigitSafeCode();
    }
    
    public int Code { get; init; }
    public string PhoneNumber { get; init; }

    public bool ValidateCombination(string phoneNumber, int code)
    {
        return phoneNumber == PhoneNumber && code == Code;
    }
    
    private int GenerateSixDigitSafeCode()
    {
        return new Random().Next(100000, 999999);
    }
}
