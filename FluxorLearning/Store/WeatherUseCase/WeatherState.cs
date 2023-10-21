using Fluxor;
using FluxorLearning.Shared;

[FeatureState]
public class WeatherState
{
    public bool IsLoading { get; }
    public IEnumerable<WeatherForecast> Forecasts { get; } = Enumerable.Empty<WeatherForecast>();

    public WeatherState()
    {
        // Required for creating initial state.
    }

    public WeatherState(bool isLoading, IEnumerable<WeatherForecast> forecasts)
    {
        IsLoading = isLoading;
        Forecasts = forecasts;
    }
}