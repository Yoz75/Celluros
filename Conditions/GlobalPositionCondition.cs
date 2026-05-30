
using System;

namespace Celluros.Conditions
{
    public class GlobalPositionCondition : Condition
    {
        private int XPosition;
        private int YPosition;
        private float Chance;
        private Cell EndType;

        Random Random = new Random();

        public GlobalPositionCondition(int xPosition, int yPosition, float chance, Cell endType)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            Chance = chance;
            EndType = endType;
        }

        public override Cell Calculate(Field field, int selfX, int selfY, out bool isChangedCell)
        {
            isChangedCell = false;

            if(Random.Next(0, 100) < Chance)
            {
                // The position is absolute and already known. Its YOUR duty to validate it!
                field.Field_[XPosition, YPosition] = EndType;
            }

            return new Cell(-1);
            throw new NotImplementedException();
        }
    }
}
