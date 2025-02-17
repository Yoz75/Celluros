
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

        public override Cell Calculate(CellNeighbors neighbors, out bool isChangedCell, Cell[,] frame)
        {
            Random random = new Random();

            isChangedCell = false;

            if(random.NextDouble() <= Chance)
            {
                isChangedCell = true;
                return EndType;
            }
            return new Cell(-1);
        }
    }
}
