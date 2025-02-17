
using System;

namespace Celluros.Conditions
{
    public class StartTypeAlwaysCondition : Condition
    {

        private Cell StartType;
        private Cell EndType;
        private float Chance;

        public StartTypeAlwaysCondition(float chance, Cell startType, Cell endType)
        {
            StartType = startType;
            Chance = chance;
            EndType = endType;
        }

        public override Cell Calculate(CellNeighbors neighbors, out bool isChangedCell, Cell[,] frame)
        {
            Random random = new Random();

            isChangedCell = false;

            if(neighbors.Neighbors[neighbors.SelfIndex, neighbors.SelfIndex].Cell == StartType)
            {
                if(random.Next(0, 100) < Chance)
                {
                    isChangedCell = true;
                    return EndType;
                }
            }

            return new Cell(-1);
        }

    }
}

