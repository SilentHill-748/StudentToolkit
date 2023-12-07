using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Windows;

using StudentToolkit.Configuration;

namespace StudentToolkit.WpfCore.Services;

/// <summary>
/// Service for generating <see cref="DataTemplate"/> collection of mappings view model to view.
/// </summary>
public class DataTemplateService(Assembly targetAssembly)
{
    /// <summary>
    /// Create collection of <see cref="DataTemplate"/> objects.
    /// </summary>
    /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="DataTemplate"/>.</returns>
    public IEnumerable<DataTemplate> GenerateDataTemplates()
    {
        var viewToViewModelMap = from type in targetAssembly.GetTypes()
                                 let viewName = type.Name.Replace("ViewModel", "View")
                                 where type.Name.EndsWith("ViewModel") && targetAssembly.HasType(viewName)
                                 select new 
                                 { 
                                     View = targetAssembly.GetType(typeName: viewName), 
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
