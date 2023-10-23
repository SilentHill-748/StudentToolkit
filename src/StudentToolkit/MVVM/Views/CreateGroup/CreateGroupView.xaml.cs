using System.Windows;
using System.Windows.Controls;

namespace StudentToolkit.MVVM.Views.CreateGroup;

public partial class CreateGroupView : UserControl
{
    public CreateGroupView()
    {
        InitializeComponent();
    }

    private void CloseBtn_Click(object sender, System.Windows.RoutedEventArgs e)
    {
        Window.GetWindow(this).Close();
    }
}
