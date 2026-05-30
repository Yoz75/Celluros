
using System;

namespace Celluros.Conditions
{
    public class StartTypeAlwaysCondition : Condition
    {
        private readonly Cell StartType;
        private readonly Cell EndType;
        private readonly float Chance;

        public StartTypeAlwaysCondition(float chance, Cell startType, Cell endType)
        {
            StartType = startType;
            Chance = chance;
            EndType = endType;
        }

        public override Cell Calculate(Field field, int selfX, int selfY, out bool isChangedCell)
        {
            isChangedCell = false;

            if(field.Field_[selfX, selfY] == StartType)
            {
                if(Random.Shared.Next(0, 100) < Chance)
                {
                    isChangedCell = true;
                    return EndType;
                }
            }

            return new Cell(-1);
        }

    }
}

