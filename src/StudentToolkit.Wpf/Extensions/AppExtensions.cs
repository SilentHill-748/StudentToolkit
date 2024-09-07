using System.Collections.Generic;

using StudentToolkit.Presentation.Mappers;

namespace StudentToolkit.Wpf.Extensions;

public static class AppExtensions
{
    public static void Configure(this App app)
    {
        ConfigureServices(app);
        SetViewToViewModelDataTemplates(app);
    }

    private static void ConfigureServices(this App app)
    {
        app.Services.AddServices();
    }

    private static void SetViewToViewModelDataTemplates(this App app)
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
