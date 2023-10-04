using FluentValidation;

namespace StudentToolkit.Configuration.DI;

public static class RegisterValidationExtention
{
    public static Container RegisterValidation(this Container container)
    {
        var assembly = typeof(RegisterValidationExtention).Assembly;
        var serviceType = typeof(AbstractValidator<>);

        var implemetationTypes = container.GetTypesToRegister(serviceType, assembly);

        container.Register(serviceType, implemetationTypes);

        return container;
    }
}
