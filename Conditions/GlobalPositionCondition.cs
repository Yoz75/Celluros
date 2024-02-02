
using System;

namespace Celluros.Conditions
{
    public class GlobalPositionCondition : Condition
    {
        private int XPosition;
        private int YPosition;
        private byte Chance;

        public GlobalPositionCondition(int xPosition, int yPosition, byte chance)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Chance = chance;
        }

        public override void Calculate(Field field)
        {
            Random random = new Random();
            if (random.Next(0, 100) < Chance)
            {

            }
        }

    }
}
