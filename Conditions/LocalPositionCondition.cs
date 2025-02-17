
using System;

namespace Celluros.Conditions
{
    public class LocalPositionCondition : Condition
    {
        private Tuple<sbyte, sbyte> Bias;
        private float Chance;
        private Cell EndType;

        Random Random = new Random();

        public LocalPositionCondition(Tuple<sbyte, sbyte> bias, float chance, Cell startType, Cell requiredType, Cell endType)
        {
            if(bias.Item1 < -1 || bias.Item1 > 1 || bias.Item2 < -1 || bias.Item2 > 1)
            {
                throw new ArgumentException("Bias elements can only be -1, 0 or 1!");
            }
            Bias = bias;
            Chance = chance;
            EndType = endType;
        }
        public void Calculate(in Field field)
        {

            Cell[,] newFrame = field.GetField();

            for(int x = 0; x < field.GetLength(0); x++)
            {
                for(int y = 0; y < field.GetLength(1); y++)
                {
                    if(Random.Next(0, 100) < Chance)
                    {
                        newFrame.SetAtPosition(x + Bias.Item1, y + Bias.Item2, EndType);
                    }
                }
            }

            field.SetField(newFrame);
        }

        public override Cell Calculate(CellNeighbors neighbors, out bool isChangedCell, Cell[,] frame)
        {
            isChangedCell = false; 
            if(Random.Next(0, 100) < Chance)
            {
                frame.SetAtPosition(neighbors.SelfXPosition + Bias.Item1,
                    neighbors.selfYPosition+ Bias.Item2, EndType);
            }
            return new Cell(-1);
        }
    }
}
