using Microsoft.AspNetCore.Mvc.ApplicationModels;
using System.Text.RegularExpressions;

namespace OutPost.Shared.Infrastructure.Api;

public class KebabCaseRouteConvention : IApplicationModelConvention
{
    public void Apply(ApplicationModel application)
    {
        foreach (var controller in application.Controllers)
        {
            var kebabCaseName = ConvertToKebabCase(controller.ControllerName);
            
            foreach (var selector in controller.Selectors)
            {
                if (selector.AttributeRouteModel == null)
                {
                    selector.AttributeRouteModel = new AttributeRouteModel
                    {
                        Template = kebabCaseName
                    };
                }
                else
                {
                    if (!string.IsNullOrEmpty(selector.AttributeRouteModel.Template))
                    {
                        selector.AttributeRouteModel.Template = 
                            selector.AttributeRouteModel.Template.Replace("[controller]", kebabCaseName);    
                    }
                }
            }
        }
    }

    private string ConvertToKebabCase(string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input;
        }

        var startUnderscores = Regex.Match(input, @"^_+");
        return startUnderscores + Regex.Replace(input, @"([a-z0-9])([A-Z])", "$1-$2").ToLower();
    }
}
