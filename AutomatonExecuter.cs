
using System.Collections.Generic;

namespace Celluros
{
    public class AutomatonExecuter
    {
        public List<Rule> Rules 
        { 
            get;
            private set;
        } = new List<Rule>();

        public Cell[,] Execute(Field field)
        {
            foreach (var rule in Rules) 
            {
                rule.Execute(field);
            }

            return field.GetField();
        }

    }
}
