using System.Linq;
using System.Reflection;
using System.Windows;

using StudentToolkit.Configuration;

namespace StudentToolkit.WpfCore;

/// <summary>
/// Mapper views and view models to <see cref="DataTemplate"/> collection.
/// </summary>
public static class ViewToViewModelDataTemplateMapper
{
    /// <summary>
    /// Create collection of <see cref="DataTemplate"/> objects.
    /// </summary>
    /// <returns><see cref="IEnumerable{T}"/> collection of <see cref="DataTemplate"/>.</returns>
    public static IEnumerable<DataTemplate> Map()
    {
        var assemply = Assembly.GetExecutingAssembly();

        return from type in assemply.GetTypes()
               let viewTypeName = type.Name.Replace("ViewModel", "View")
               where type.Name.EndsWith("ViewModel") && assemply.HasType(viewTypeName)
               select new DataTemplate(type)
               {
                   VisualTree = new FrameworkElementFactory(assemply.GetTypeByName(viewTypeName))
               };
    }
}
