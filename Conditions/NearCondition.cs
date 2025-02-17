
using System;
using System.Linq;

namespace Celluros.Conditions
{
    public class NearCondition : Condition
    {

        private Cell StartType;
        private Cell RequiredType;
        private Cell EndType;
        private float Chance;
        private byte[] CellsCount;

        public NearCondition(float chance, Cell startType, Cell requiredType, Cell endType, params byte[] cellsCount)
        {

            CellsCount = cellsCount;
            Chance = chance;
            StartType = startType;
            RequiredType = requiredType;
            EndType = endType;
        }

        public override Cell Calculate(CellNeighbors neighbors, out bool isChangedCell, Cell[,] frame)
        {
            Random random = new Random();
            byte requiredTypeNeighbors = 0;

            isChangedCell = false;

            if(random.NextDouble() < Chance)
            {
                if(neighbors.Neighbors[neighbors.SelfIndex, neighbors.SelfIndex].Cell == StartType)
                {
                    foreach(var neighbor in neighbors.Neighbors)
                    {
                        if(neighbor.IsSelf)
                        {
                            continue;
                        }
                        if(neighbor.Cell == RequiredType)
                        {
                            requiredTypeNeighbors++;
                        }
                    }
                    if(CellsCount.Contains(requiredTypeNeighbors))
                    {
                        isChangedCell = true;
                        return EndType;
                    }
                }
            }

            return new Cell(-1);
        }
    }
}
