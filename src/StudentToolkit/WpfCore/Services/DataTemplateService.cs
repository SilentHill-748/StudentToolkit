using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace StudentToolkit.WpfCore.Services;

/// <summary>
/// Service for generating <see cref="DataTemplate"/> collection of mappings view model to view.
/// </summary>
internal class DataTemplateService
{
    /// <summary>
    /// Create collection of <see cref="DataTemplate"/> objects.
    /// </summary>
    /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="DataTemplate"/>.</returns>
    public IEnumerable<DataTemplate> GenerateDataTemplates()
    {
        var assembly = GetType().Assembly;

        var viewModelTypes = assembly
            .GetTypes()
            .Where(type => type.Name.EndsWith("ViewModel"));

        foreach (Type viewModelType in viewModelTypes)
        {
            Type? viewType = GetViewType(viewModelType);

            if (viewType is not null)
            {
                yield return GenerateDataTemplate(viewModelType, viewType);
            }
        }
    }

    private static DataTemplate GenerateDataTemplate(Type viewModelType, Type viewType)
    {
        return new DataTemplate(viewModelType)
        {
            VisualTree = new FrameworkElementFactory(viewType)
        };
    }

    private static Type? GetViewType(Type viewModelType)
    {
        var viewTypeName = viewModelType.FullName!.Replace("ViewModel", "View");

        return Type.GetType(viewTypeName);
    }
}
