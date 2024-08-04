using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StudentToolkit.Presentation.Common.Abstractions;

public abstract class BindableBase : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    protected void Set<T>(
        ref T field,
        T value,
        [CallerMemberName] string propertyName = "")
    {
        field = value;

        RaisePropertyChanged(propertyName);
    }

    protected void RaisePropertyChanged(string propertyName)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
