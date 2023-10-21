using Fluxor;
using FluxorLearning.Services;

namespace FluxorLearning.Store.WeatherUseCase
{
    public class Effects
    {
        private IWeatherForecastService _forecastService;

        public Effects(IWeatherForecastService forecastService)
        {
            _forecastService = forecastService;
        }

        [EffectMethod]
        public async Task HandleFetchDataAction(FetchDataAction action, IDispatcher dispatcher)
        {
            var forecasts = await _forecastService.GetForecastAsync(DateTime.Now);
            dispatcher.Dispatch(new FetchDataResultAction(forecasts));
        }
    }
}