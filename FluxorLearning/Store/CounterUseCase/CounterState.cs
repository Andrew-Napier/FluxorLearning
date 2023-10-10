using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fluxor;

namespace FluxorLearning.Store.CounterUseCase
{
    [FeatureState]
    public class CounterState
    {
        public int ClickCount { get; }

        private CounterState()
        {
            ClickCount = 0;
        }

        public CounterState(int clickCount)
        {
            ClickCount = clickCount;
        }
    }
}