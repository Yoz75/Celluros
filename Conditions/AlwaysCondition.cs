
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

        public override Cell Calculate(Field field, int selfX, int selfY, out bool isChangedCell)
        {
            isChangedCell = false;

            if(Random.Shared.NextDouble() <= Chance)
            {
                isChangedCell = true;
                return EndType;
            }

            return default;
        }
    }
}
