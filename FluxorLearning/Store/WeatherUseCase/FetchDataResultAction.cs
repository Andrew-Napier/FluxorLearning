using FluxorLearning.Shared;

namespace FluxorLearning.Store.WeatherUseCase;

public class FetchDataResultAction
{
    public IEnumerable<WeatherForecast> Forecasts { get; }

    public FetchDataResultAction(WeatherForecast[] forecasts)
    {
        Forecasts = forecasts;
    }
}