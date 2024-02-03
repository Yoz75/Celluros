
using Celluros.Conditions;
using System.Collections.Generic;

namespace Celluros
{
    public class Rule
    {
        public List<Condition> Conditions
        {
            get;
            private set;
        }
        public void Execute(Field field)
        {
            foreach (var condition in Conditions) 
            {
                condition.Calculate(field);
            }
        }
    }
}
