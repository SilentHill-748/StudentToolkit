namespace StudentToolkit.WpfCore.Common.Helpers;

public static class GroupEducationHelper
{
    public static ObservableCollection<string> CreateEducationFormats()
    {
        return
        [
            "Очно",
            "Очно-заочно",
            "Заочно"
        ];
    }

    public static ObservableCollection<string> CreateEducationTypes()
    {
        return 
        [
            "СПО",
            "Бакалавриат",
            "Магистратура",
            "Аспирантура"
        ];
    }
}
