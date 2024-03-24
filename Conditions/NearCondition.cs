
using System;
using System.Collections.Generic;
using System.Linq;

namespace Celluros.Conditions
{
    public class NearCondition : Condition
    {

        private Cell StartType;
        private Cell RequiredType;
        private Cell EndType;
        private float Chance;
        private byte[] CellsCount = new byte[8];

        public NearCondition( float chance, Cell startType, Cell requiredType, Cell endType, params byte[] cellsCount)
        {
            if (cellsCount.Length > 8)
            {
                throw new ArgumentException("cellsCount must be 8 elements or less!");
            }

            List<byte> foundElements = new List<byte>();

            foreach (var number in cellsCount)
            {
                if (foundElements.Contains(number))
                {
                    throw new ArgumentException("cellsCount must contains only unique items!");
                }
                foundElements.Add(number);
            }

            CellsCount = cellsCount;
            Chance = chance;
            StartType = startType;
            RequiredType = requiredType;
            EndType = endType;
        }

        public override void Calculate(Field field)
        {
            Random random = new Random();
            byte requiredTypeNeighbors = 0;
            for (int x = 0; x < field.GetLength(0); x++)
            {
                for (int y = 0; y < field.GetLength(1); y++)
                {
                    if (random.Next(0, 100) < Chance)
                    {
                        if (field.IsTypeAtPosition(x, y, StartType))
                        {
                            requiredTypeNeighbors = CountNeighbors(x, y, RequiredType);
                            if (CellsCount.Contains(requiredTypeNeighbors))
                            {
                                field.SetAtPosition(x, y, EndType);
                            }
                        }
                    }
                }
            }

            byte CountNeighbors(int x, int y, Cell type)
            {
                byte count = 0;


                for(sbyte i = -1; i <= 1; i++)
                {
                    for (sbyte j = -1; j <= 1; j++)
                    {
                        if (i == 0 || j == 0)
                        {
                            continue;
                        }

                        if (field.IsTypeAtPosition(x + i, y + j, type))
                        {
                            count++;
                        }
                    }
                }
                return count;
            }
        }
    }
}
