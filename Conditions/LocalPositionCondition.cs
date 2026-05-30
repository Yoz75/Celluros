
using System;

namespace Celluros.Conditions
{
    public class LocalPositionCondition : Condition
    {
        private readonly (sbyte, sbyte) Bias;
        private readonly float Chance;
        private readonly Cell EndType;

        public LocalPositionCondition((sbyte, sbyte) bias, float chance, Cell endType)
        {
            Bias = bias;
            Chance = chance;
            EndType = endType;
        }

        public override Cell Calculate(Field field, int selfX, int selfY, out bool isChangedCell)
        {
            isChangedCell = false; 
            if(Random.Shared.Next(0, 100) < Chance)
            {
                field.SetAtNormalized(selfX + Bias.Item1, selfY + Bias.Item2, EndType);
            }

            return default;
        }
    }
}
