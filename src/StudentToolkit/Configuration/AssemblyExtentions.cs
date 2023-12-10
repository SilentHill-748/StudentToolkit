using System.Linq;
using System.Reflection;

namespace StudentToolkit.Configuration;

public static class AssemblyExtentions
{
    public static bool HasType(this Assembly assembly, string typeName)
    {
        return assembly.GetTypes().Any(t => t.Name == typeName);
    }

    public static Type GetTypeByName(this Assembly assembly, string typeName)
    {
        if (string.IsNullOrEmpty(typeName))
            throw new ArgumentException("Type name wasn't be null or empty!", nameof(typeName));

        return assembly.GetTypes().FirstOrDefault(type => type.Name == typeName) ?? 
            throw new ArgumentException("Type wasn't found by specified name!", nameof(typeName));
    }
}
