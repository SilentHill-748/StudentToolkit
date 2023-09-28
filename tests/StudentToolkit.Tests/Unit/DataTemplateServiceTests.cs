namespace StudentToolkit.Tests.Unit;

public class DataTemplateServiceTests
{
    [Fact]
    public void Should_correct_generate_data_templates()
    {
        DataTemplateService dataTemplateService = new(typeof(DataTemplateServiceTests).Assembly);

        var dataTemplates = dataTemplateService.GenerateDataTemplates().ToArray();

        Assert.NotEmpty(dataTemplates);
        Assert.True(dataTemplates.Length > 0);
        Assert.True(dataTemplates.Length < 3);
        Assert.True(dataTemplates.Length == 2);
        // Assert.IsType(..) throws error, because DataType is RuntimeType, but DataType has correct Stub...ViewModel type.
        Assert.Equal("StubOneViewModel", ((Type)dataTemplates[0].DataType).Name);
        Assert.Equal("StubTwoViewModel", ((Type)dataTemplates[1].DataType).Name);
        Assert.Equal("StubOneView", dataTemplates[0].VisualTree.Type.Name);
        Assert.Equal("StubTwoView", dataTemplates[1].VisualTree.Type.Name);
    }
}
