namespace OutPost.Modules.Commission.Domain;

public class Mdp
{
    public Mdp(Guid id, decimal markup)
    {
        Id = id;
        Markup = markup;
    }

    public Guid Id { get; }
    public decimal Markup { get; private set; }

    public void UpdateMarkup(decimal markup)
    {
        Markup = markup;
    }
}
