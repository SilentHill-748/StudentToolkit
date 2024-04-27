using System.Runtime.CompilerServices;

namespace StudentToolkit.MVVM.BaseViewModels;

public class ViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler? PropertyChanged;

    public string WindowTitle { get; set; } = string.Empty;
    public string ViewTitle { get; set; } = string.Empty;

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
