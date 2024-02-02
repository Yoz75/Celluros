
using System;

namespace Celluros.Conditions
{
    public class GlobalPositionCondition : Condition
    {
        private uint XPosition;
        private uint YPosition;
        private float Chance;
        private Cell EndType;

        public GlobalPositionCondition(uint xPosition, uint yPosition, float chance, Cell endType)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Chance = chance;
            EndType = endType;
        }

        public override void Calculate(Field field)
        {
            Random random = new Random();
            if (random.Next(0, 100) < Chance)
            {
                field.SetAtPosition(XPosition, YPosition, EndType) ;
            }
        }

    }
}
