using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StudentToolkit.MVVM.ViewModels;

public class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void Set<T>(ref T field, T value, string propertyName)
    {
        if (field is null || !field.Equals(value))
        {
            field = value;
        }

        OnPropertyChanged(propertyName);
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
