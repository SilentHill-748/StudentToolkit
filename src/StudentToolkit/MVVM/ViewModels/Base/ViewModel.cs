using System.Runtime.CompilerServices;

namespace StudentToolkit.MVVM.ViewModels.Base;

public class ViewModel : INotifyPropertyChanged
{
    public string WindowTitle { get; set; } = string.Empty;

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = "")
    {
        if (field is null || !field.Equals(value))
        {
            field = value;

            OnPropertyChanged(propertyName);
        }
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
}
