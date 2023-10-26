using Fluxor;
using System.Text.Json;

namespace FluxorLearning.Store.Middlewares.Logging;

public class LoggingMiddleware : Middleware
{
    private IStore Store;
    private bool _includeLogging = true;

    private string ObjectInfo(object obj)
        => ": " + obj.GetType().Name + " " + JsonSerializer.Serialize(obj);

    private void LogWrite(string message)
    {
        if (_includeLogging)
            Console.WriteLine(message);
    }

    public override Task InitializeAsync(IDispatcher dispatcher, IStore store)
    {
        Store = store;
        Console.WriteLine(nameof(InitializeAsync));
        return Task.CompletedTask;
    }

    public override void AfterInitializeAllMiddlewares()
    {
        LogWrite(nameof(AfterInitializeAllMiddlewares));
    }

    public override bool MayDispatchAction(object action)
    {
        LogWrite(nameof(MayDispatchAction) + " " + ObjectInfo(action));
        return true;
    }

    public override void BeforeDispatch(object action)
    {
        LogWrite(nameof(BeforeDispatch) + " " + ObjectInfo(action));
    }

    public override void AfterDispatch(object action)
    {
        LogWrite(nameof(AfterDispatch) + " " + ObjectInfo(action));
    }
}