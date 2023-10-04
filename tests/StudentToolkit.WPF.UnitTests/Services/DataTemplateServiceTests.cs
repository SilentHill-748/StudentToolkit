namespace StudentToolkit.WPF.UnitTests.Services;

public class DataTemplateServiceTests
{
    [Fact]
    public void Data_templates_generating_by_current_assembly_is_correct()
    {
        DataTemplateService dataTemplateService = new(typeof(DataTemplateServiceTests).Assembly);

        var dataTemplates = dataTemplateService.GenerateDataTemplates().ToArray();

        Assert.NotEmpty(dataTemplates);
        Assert.True(dataTemplates.Length == 2);
        // Assert.IsType(..) throws error, because DataType is RuntimeType, but DataType has correct Stub...ViewModel type.
        Assert.Equal("DummyOneViewModel", ((Type)dataTemplates[0].DataType).Name);
        Assert.Equal("DummyTwoViewModel", ((Type)dataTemplates[1].DataType).Name);
        Assert.Equal("DummyOneView", dataTemplates[0].VisualTree.Type.Name);
        Assert.Equal("DummyTwoView", dataTemplates[1].VisualTree.Type.Name);
    }
}
