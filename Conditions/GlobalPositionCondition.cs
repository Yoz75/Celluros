
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

        public override Cell Calculate(CellNeighbors neighbors, out bool isChangedCell, Cell[,] frame)
        {
            isChangedCell = false;

            if(Random.Next(0, 100) < Chance)
            {
                frame.SetAtPosition(XPosition, YPosition, EndType);
            }

            return new Cell(-1);
            throw new NotImplementedException();
        }
    }
}
