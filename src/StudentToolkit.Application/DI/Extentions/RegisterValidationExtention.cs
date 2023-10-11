using System.Reflection;

namespace StudentToolkit.Application.DI.Extentions;

public static class RegisterValidationExtention
{
    public static Container RegisterValidation(this Container container, params Assembly[] assemplies)
    {
        var serviceType = typeof(AbstractValidator<>);

        var serviceImplementations = container.GetTypesToRegister(serviceType, assemplies);

        container.Register(serviceType, serviceImplementations);

        return container;
    }
}
