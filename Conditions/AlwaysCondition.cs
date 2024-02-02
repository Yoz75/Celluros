
using System;

namespace Celluros.Conditions
{
    public class AlwaysCondition : Condition
    {
        private byte Chance;
        private Cell EndType;
        public AlwaysCondition(byte chance, Cell endType) 
        {
            Chance = chance;
            EndType = endType;
        }

        public override void Calculate(Field field)
        {
            Random random = new Random();
            for (uint x = 0; x < field.Field_.GetLength(0); x++) 
            {
                for(uint y = 0; y < field.Field_.GetLength(1); y++) 
                {
                    if(random.Next(0, 100) < Chance)
                    {
                        field.Field_[x, y] = EndType; 
                    }
                }
            }
        }
    }
}
