namespace StudentToolkit.MVVM.Models;

public class GroupModel
{
    public Guid Id { get; set; }

    public string GroupCode { get; set; } = string.Empty;

    public IEnumerable<StudentModel> Students { get; set; } = [];
}
