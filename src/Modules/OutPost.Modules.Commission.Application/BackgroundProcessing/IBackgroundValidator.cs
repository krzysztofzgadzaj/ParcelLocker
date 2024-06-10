namespace OutPost.Modules.Commission.Application.BackgroundProcessing;

public interface IBackgroundValidator
{
    Task Validate(Domain.Commission commission);
}
