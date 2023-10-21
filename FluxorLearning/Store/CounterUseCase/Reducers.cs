using Fluxor;
using FluxorLearning.Shared;
using FluxorLearning.Store.WeatherUseCase;

namespace FluxorLearning.Store.CounterUseCase
{
    public static class Reducers
    {
        [ReducerMethod]
        public static CounterState ReduceIncrementCounterAction(CounterState state, IncrementCounterAction action) =>
            new(state.ClickCount + 1);

        [ReducerMethod]
        public static WeatherState ReduceFetchDataAction(WeatherState state, FetchDataResultAction action) =>
            new WeatherState(
                isLoading: true,
                forecasts: action.Forecasts);
    }
}