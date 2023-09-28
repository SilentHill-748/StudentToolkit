using System;

namespace StudentToolkit.WpfCore.Exceptions.Navigation;

public class NavigationDeniedException : Exception
{
    public NavigationDeniedException(string message)
        : base(message) { }
}
