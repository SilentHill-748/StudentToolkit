using StudentToolkit.WpfCore.Common.Interop.Structs;

namespace StudentToolkit.WpfCore.Common.Interop.MessageHandlers;

internal interface IMessageHandler
{
    int Message { get; }

    bool Handle(IntMessageArgs args);
}
