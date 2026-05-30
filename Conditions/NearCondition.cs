
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

        public override Cell Calculate(Field field, int selfX, int selfY, out bool isChangedCell)
        {
            var neighbors = field.GetNeighbors(selfX, selfY);
            // selfX and selfY are ALWAYS valid
            var self = field.Field_[selfX, selfY];
            byte requiredTypeNeighbors = 0;

            isChangedCell = false;

            if(Random.Shared.NextDouble() < Chance)
            {
                if(self == StartType)
                {
                    if(neighbors.Upper == RequiredType) requiredTypeNeighbors++;
                    if(neighbors.UpperRight == RequiredType) requiredTypeNeighbors++;
                    if(neighbors.Right == RequiredType) requiredTypeNeighbors++;
                    if(neighbors.DownRight == RequiredType) requiredTypeNeighbors++;
                    if(neighbors.Down == RequiredType) requiredTypeNeighbors++;
                    if(neighbors.DownLeft == RequiredType) requiredTypeNeighbors++;
                    if(neighbors.Left == RequiredType) requiredTypeNeighbors++;
                    if(neighbors.UpperLeft== RequiredType) requiredTypeNeighbors++;

                    if(CellsCount.Contains(requiredTypeNeighbors))
                    {
                        isChangedCell = true;
                        return EndType;
                    }
                }
            }

            return default;
        }
    }
}
