namespace StudentToolkit.WpfCore.Commands.Group.CreateGroup;

public class SetGroupDataAndMoveToNextViewCommand : Command
{
    private readonly InputGroupDataViewModel _inputGroupDataVm;
    private readonly GroupViewModel _group;

    public SetGroupDataAndMoveToNextViewCommand(
        InputGroupDataViewModel inputGroupDataVm,
        GroupViewModel group)
    {
        _inputGroupDataVm = inputGroupDataVm;
        _group = group;
    }

    public override void Execute()
    {
        _inputGroupDataVm.GroupData.Validate();

        if (IsNotValidationErrors())
        {
            SetGroupData();

            NavigationService.Navigate<MainViewModel, AddStudentsToGroupViewModel>();
        }
    }

    private bool IsNotValidationErrors()
    {
        return !_inputGroupDataVm.GroupData.HasErrors;
    }

    private void SetGroupData()
    {
        GroupViewModel groupData = _inputGroupDataVm.GroupData;

        _group.GroupCode = groupData.GroupCode;
        _group.EducationDirection = groupData.EducationDirection;
        _group.EducationFormat = groupData.EducationFormat;
        _group.EducationType = groupData.EducationType;
        _group.AdmissionYear = groupData.AdmissionYear;
    }
}
