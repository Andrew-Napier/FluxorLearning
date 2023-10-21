using Fluxor;

namespace FluxorLearning.Store.WeatherUseCase
{
    public static class Reducer
    {
        [ReducerMethod]
        public static WeatherState ReducerFetchDataResultAction(WeatherState state, FetchDataResultAction action) =>
            new WeatherState(
                isLoading: false,
                forecasts: action.Forecasts);
    }
}