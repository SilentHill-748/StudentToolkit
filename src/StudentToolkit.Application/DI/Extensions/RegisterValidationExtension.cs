using System.Reflection;

namespace StudentToolkit.Application.DI.Extentions;

public static class RegisterValidationExtension
{
    public static Container RegisterValidation(this Container container, params Assembly[] assemplies)
    {
        var serviceType = typeof(AbstractValidator<>);

        var serviceImplementations = container.GetTypesToRegister(serviceType, assemplies);

        foreach (Type serviceImplementation in serviceImplementations)
        {
            container.Register(serviceImplementation);
        } 
        
        return container;
    }
}
