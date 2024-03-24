
using System;

namespace Celluros.Conditions
{
    public class GlobalPositionCondition : Condition
    {
        private int XPosition;
        private int YPosition;
        private float Chance;
        private Cell EndType;

        public GlobalPositionCondition(int xPosition, int yPosition, float chance, Cell endType)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Chance = chance;
            EndType = endType;
        }

        public override void Calculate(Field field)
        {
            Random random = new Random();

            Cell[,] newFrame = field.GetField();

            if (random.Next(0, 100) < Chance)
            {
                newFrame.SetAtPosition(XPosition, YPosition, EndType);
            }

            field.SetField(newFrame);

        }

    }
}
