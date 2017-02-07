using EvolutionaryStrategyEngine.Evaluation;
using EvolutionaryStrategyEngine.Logging;
using EvolutionaryStrategyEngine.Mutation;
using EvolutionaryStrategyEngine.Recombination;
using EvolutionaryStrategyEngine.Selection;
using EvolutionaryStrategyEngine.Utils;

namespace EvolutionaryStrategyEngine
{
    public class EvolutionaryStrategyEngine
    {
        private IEvaluator _evaluator;
        private ILogger _logger;
        private IMutator _mutator;
        private IRecombiner _recombiner;
        private ISelector _parentsSelector;
        private ISelector _survivorsSelector;

        public EvolutionaryStrategyEngine(AlgorithmParameters algorithmParameters)
        {
            _evaluator = new Evaluator();
            _logger = new Logger();
            _mutator = new Mutator(algorithmParameters);
            _recombiner = new Recombiner();
            _parentsSelector = new RandomParentsSelector(algorithmParameters);
            _survivorsSelector = new SurvivorsSeletor(algorithmParameters);
        }
    }
}
