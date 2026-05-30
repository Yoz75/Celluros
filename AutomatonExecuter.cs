
using System.Collections.Generic;

namespace Celluros
{
    public class AutomatonExecuter
    {
        private int ExecutingRuleId = 0;

        public List<IRule> Rules
        {
            get;
            private set;
        } = [];

        /// <summary>
        /// Execute a step of the automaton on a field
        /// </summary>
        /// <param name="field"></param>
        /// <param name="isCompletedAllRules"></param>
        /// <returns>true if can continue, false if all rules can't be executed</returns>
        public bool Execute(Field field)
        {
            if(ExecutingRuleId >= Rules.Count)
            {
                return false;
            }
            else
            {
                if(!Rules[ExecutingRuleId].CanBeExecuted())
                {
                    ExecutingRuleId++;
                }
                if(ExecutingRuleId > Rules.Count - 1)
                {
                    return false;
                }
            }

            Rules[ExecutingRuleId].Execute(field);

            return true;
        }
    }
}
