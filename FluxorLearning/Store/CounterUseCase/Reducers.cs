using Fluxor;

namespace FluxorLearning.Store.CounterUseCase
{
    public static class Reducers
    {
        [ReducerMethod]
        public static CounterState ReduceIncrementCounterAction(CounterState state, IncrementCounterAction action) =>
            new(state.ClickCount + 1);
    }
}