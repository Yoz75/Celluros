
using System;

namespace Celluros.Conditions
{
    public class AlwaysCondition : Condition
    {
        private float Chance;
        private Cell EndType;
        public AlwaysCondition(float chance, Cell endType) 
        {
            Chance = chance;
            EndType = endType;
        }

        public override void Calculate(Field field)
        {
            Random random = new Random();
            for (uint x = 0; x < field.GetLength(0); x++) 
            {
                for(uint y = 0; y < field.GetLength(1); y++) 
                {
                    if(random.Next(0, 100) < Chance)
                    {
                        field.SetAtPosition(x, y, EndType); 
                    }
                }
            }
        }
    }
}
