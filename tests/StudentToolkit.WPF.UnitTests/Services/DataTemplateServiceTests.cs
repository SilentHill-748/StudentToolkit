using System.Windows;

using StudentToolkit.WpfCore;

namespace StudentToolkit.WPF.UnitTests.Services;

public class DataTemplateServiceTests
{
    [Fact]
    public void Correct_mapping_view_and_view_model_to_data_template_collection()
    {
        var dataTemplates = ViewToViewModelDataTemplateMapper.Map();

        Assert.NotEmpty(dataTemplates);
        
        foreach (DataTemplate template in dataTemplates)
        {
            var viewModelTypeName = ((Type)template.DataType).Name;
            var viewTypeName = template.VisualTree.Type.Name;

            Assert.Contains("ViewModel", viewModelTypeName);
            Assert.Contains("View", viewTypeName);
            Assert.DoesNotContain("Model", viewTypeName);
        }
    }
}
