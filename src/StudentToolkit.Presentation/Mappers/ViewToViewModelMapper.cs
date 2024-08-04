using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace StudentToolkit.Presentation.Mappers;

public sealed class ViewToViewModelMapper
{
    private readonly Assembly _targetAssembly;

    public ViewToViewModelMapper()
    {
        _targetAssembly = typeof(ViewToViewModelMapper).Assembly;
    }

    public IEnumerable<DataTemplate> Map()
    {
        Dictionary<Type, Type> viewModeltoViewDict = GetViewModelToViewTypesMap();

        foreach (var record in viewModeltoViewDict)
        {
            yield return new DataTemplate(record.Key)
            {
                VisualTree = new FrameworkElementFactory(record.Value)
            };
        }
    }

    private Dictionary<Type, Type> GetViewModelToViewTypesMap()
    {
        Dictionary<Type, Type> viewToViewModelMap = [];
        Type[] types = _targetAssembly.GetTypes();

        Array.Sort(types, (x, y) => x.Name.CompareTo(y.Name));

        /*
         * If view and view model is related (MainView and MainViewModel for example)
         * then view type is located above by 1 position view model type in the array.
         */
        for (int i = 0; i < types.Length; i++)
        {
            if (i == types.Length - 1)
                break;

            Type viewType = types[i];
            Type viewModelType = types[i + 1];

            if (IsNotViewType(viewType))
                continue;

            if (IsNotViewModelType(viewModelType))
                continue;

            if (viewModelType.Name.StartsWith(viewType.Name))
            {
                viewToViewModelMap.Add(viewModelType, viewType);
                i++;
            }
        }

        return viewToViewModelMap;
    }

    private static bool IsNotViewType(Type type)
    {
        return
            !type.IsSubclassOf(typeof(UserControl)) ||
            !type.Name.EndsWith("View");
    }

    private static bool IsNotViewModelType(Type type)
    {
        return !type.IsSubclassOf(typeof(ViewModel));
    }
}
