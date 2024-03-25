
using Celluros.Conditions;
using System.Collections.Generic;

namespace Celluros
{
    public class Rule
    {

        private int CurrentIteration = 0;
        private int MaxIteration;

        public Rule(int iterations)
        {
            MaxIteration = iterations;
        }

        public List<Condition> Conditions
        {
            get;
            private set;
        } = new List<Condition>();

        public void Execute(Field field)
        {

            if(CurrentIteration >= MaxIteration)
            {
                return;
            }

            CurrentIteration ++;
            foreach (var condition in Conditions) 
            {
                condition.Calculate(field);
            }
        }
    }
}
