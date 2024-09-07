using System.Collections.Generic;

using StudentToolkit.Presentation.Mappers;

namespace StudentToolkit.Wpf.Extensions;

public static class AppExtensions
{
    public static void ConfigureServices(this App app)
    {
        app.Services.AddServices();
    }

    public static void SetViewToViewModelDataTemplates(this App app)
    {
        IEnumerable<DataTemplate> dataTemplates =
            new ViewToViewModelMapper()
                .Map();

        foreach (var dataTemplate in dataTemplates)
        {
            app.Resources.Add(dataTemplate.DataTemplateKey, dataTemplate);
        }
    }
}
