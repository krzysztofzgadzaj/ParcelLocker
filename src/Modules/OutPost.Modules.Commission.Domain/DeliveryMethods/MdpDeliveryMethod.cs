namespace OutPost.Modules.Commission.Domain.DeliveryMethods;

public class MdpDeliveryMethod : DeliveryMethod
{
    public MdpDeliveryMethod(Mdp mdp)
    {
        if (mdp is null || mdp.Id == Guid.Empty)
        {
            throw new ArgumentException();
        }
        
        Mdp = mdp;
    }

    public override DeliveryMethodType Type => DeliveryMethodType.Mdp;
    public Mdp Mdp { get; }
}
