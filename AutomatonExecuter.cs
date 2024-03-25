
using System.Collections.Generic;

namespace Celluros
{
    public class AutomatonExecuter
    {

        private int ExecutingRuleId = 0;

        public List<Rule> Rules
        {
            get;
            private set;
        } = new List<Rule>();

        public Cell[,] Execute(Field field, out bool isCompletedAllRules)
        {
            if(ExecutingRuleId >= Rules.Count)
            {
                isCompletedAllRules = true;
                return field.GetField();
            }
            else
            {
                isCompletedAllRules = false;
                if(Rules[ExecutingRuleId].IsCompleted)
                {
                    ExecutingRuleId++;
                }
            }

            Rules[ExecutingRuleId].Execute(field);

            return field.GetField();
        }

    }
}
