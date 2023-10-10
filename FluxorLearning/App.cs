using Fluxor;
using FluxorLearning.Shared;
using FluxorLearning.Store;
using FluxorLearning.Store.CounterUseCase;

public class App
{
    private readonly IStore _store;
    private readonly IState<CounterState> _counterState;
    private readonly IDispatcher _dispatcher;
    private readonly IState<WeatherState> _weatherState;

    public App(IStore store, IState<CounterState> counterState, IDispatcher dispatcher,
        IState<WeatherState> weatherState)
    {
        _store = store;
        _counterState = counterState;
        _dispatcher = dispatcher;
        _weatherState = weatherState;
        _counterState.StateChanged += CounterState_StateChanged;
        _weatherState.StateChanged += WeatherState_StateChanged;
    }

    private void WeatherState_StateChanged(object? sender, EventArgs e)
    {
        Console.WriteLine("");
        Console.WriteLine("=========================> WeatherState");
        Console.WriteLine("IsLoading: " + _weatherState.Value.IsLoading);
        if (!_weatherState.Value.Forecasts.Any())
        {
            Console.WriteLine("--- No weather forecasts");
        }
        else
        {
            Console.WriteLine("Temp C\tTemp F\tSummary");
            foreach (WeatherForecast forecast in _weatherState.Value.Forecasts)
                Console.WriteLine($"{forecast.TemperatureC}\t{forecast.TemperatureF}\t{forecast.Summary}");
        }

        Console.WriteLine("<========================== WeatherState");
        Console.WriteLine("");
    }

    private void CounterState_StateChanged(object? sender, EventArgs e)
    {
        Console.WriteLine();
        Console.WriteLine("=================> CounterState");
        Console.WriteLine($"ClickCount is {_counterState.Value.ClickCount}");
        Console.WriteLine("<================= CounterState");
        Console.WriteLine();
    }

    public void Run()
    {
        Console.Clear();
        Console.WriteLine("Initialising Store");
        _store.InitializeAsync().Wait();

        string input = "";
        do
        {
            Console.WriteLine("1: Increment counter");
            Console.WriteLine("x: Exit");
            Console.Write("> ");
            input = Console.ReadLine() ?? "";

            switch (input.ToLowerInvariant())
            {
                case "1":
                    var action = new IncrementCounterAction();
                    _dispatcher.Dispatch(action);
                    break;
                case "x":
                    Console.WriteLine("Program terminated");
                    return;
            }
        } while (true);
    }
}