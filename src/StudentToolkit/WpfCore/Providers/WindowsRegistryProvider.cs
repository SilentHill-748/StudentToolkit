using System;
using System.Linq;

using Microsoft.Win32;

namespace StudentToolkit.WpfCore.Providers;

public class WindowsRegistryProvider : IDisposable
{
    private const string AppPath = "SOFTWARE\\StudentToolkit";
    private readonly RegistryKey _appSubKey;
    private bool _disposedValue;

    public WindowsRegistryProvider()
    {
        _appSubKey = Registry.CurrentUser
            .CreateSubKey(AppPath, RegistryKeyPermissionCheck.ReadWriteSubTree);
    }

    public void CreateSubKey(string subKeyName)
    {
        _appSubKey.CreateSubKey(subKeyName).Close();
    }

    public void DeleteSubKeyTree(string subKeyName)
    {
        ArgumentException.ThrowIfNullOrEmpty(subKeyName, nameof(subKeyName));

        _appSubKey.DeleteSubKeyTree(subKeyName, true);
    }

    public bool HasValue(string valueName, string subKeyName = "")
    {
        ArgumentException.ThrowIfNullOrEmpty(valueName, nameof(valueName));

        using var subKey = TryOpenSubKey(subKeyName);

        return subKey.GetValueNames().Contains(valueName);
    }

    public void WriteValue<TValue>(string valueName, TValue value, string subKeyName = "")
    {
        ArgumentException.ThrowIfNullOrEmpty(valueName, nameof(valueName));
        ArgumentNullException.ThrowIfNull(value, nameof(value));

        using var subKey = TryOpenSubKey(subKeyName);

        subKey.SetValue(valueName, value);
    }

    public TValue ReadValue<TValue>(string valueName, string subKeyName = "")
    {
        ArgumentException.ThrowIfNullOrEmpty(valueName, nameof(valueName));

        using var subKey = TryOpenSubKey(subKeyName);

        var value = subKey.GetValue(valueName);

        return (TValue?)value ??
            throw new ArgumentException($"Value '{valueName}' not found on application subkey tree.", nameof(valueName));
    }

    public void DeleteValue(string valueName, string subKeyName = "")
    {
        ArgumentException.ThrowIfNullOrEmpty(valueName, nameof(valueName));
        ArgumentException.ThrowIfNullOrEmpty(subKeyName, nameof(subKeyName));

        using var subKey = TryOpenSubKey(subKeyName);

        subKey.DeleteValue(valueName, true);
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private RegistryKey TryOpenSubKey(string subKeyName)
    {
        ArgumentNullException.ThrowIfNull(subKeyName, nameof(subKeyName));

        return _appSubKey.OpenSubKey(subKeyName, true) ??
            throw new ArgumentException($"Subkey '{subKeyName}' is not found.");
    }

    private void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _appSubKey.Dispose();
            }

            _disposedValue = true;
        }
    }
}
