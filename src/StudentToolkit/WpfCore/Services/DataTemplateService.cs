using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;

using StudentToolkit.Configuration;

namespace StudentToolkit.WpfCore.Services;

/// <summary>
/// Service for generating <see cref="DataTemplate"/> collection of mappings view model to view.
/// </summary>
public class DataTemplateService
{
    private readonly Assembly _targetAssembly;

    public DataTemplateService(Assembly targetAssembly)
    {
        ArgumentNullException.ThrowIfNull(targetAssembly, nameof(targetAssembly));

        _targetAssembly = targetAssembly;
    }

    /// <summary>
    /// Create collection of <see cref="DataTemplate"/> objects.
    /// </summary>
    /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="DataTemplate"/>.</returns>
    public IEnumerable<DataTemplate> GenerateDataTemplates()
    {
        var assembly = GetType().Assembly;

        var viewToViewModelMap = from type in _targetAssembly.GetTypes()
                                 let viewName = type.Name.Replace("ViewModel", "View")
                                 where type.Name.EndsWith("ViewModel") && _targetAssembly.HasType(viewName)
                                 select new 
                                 { 
                                     View = _targetAssembly.GetType(typeName: viewName), 
                                     ViewModel = type 
                                 };

        foreach (var item in viewToViewModelMap)
        {
            yield return GenerateDataTemplate(item.ViewModel, item.View);
        }
    }

    private static DataTemplate GenerateDataTemplate(Type viewModelType, Type viewType)
    {
        return new DataTemplate(viewModelType)
        {
            VisualTree = new FrameworkElementFactory(viewType)
        };
    }
}
