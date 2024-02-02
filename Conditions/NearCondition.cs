
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
        private byte Chance;
        private byte[] CellsCount = new byte[8];

        public NearCondition(byte[] cellsCount, byte chance, Cell startType, Cell requiredType, Cell endType)
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
            byte requiredTypeNeighboors = 0;
            for (int x = 0; x < field.Field_.GetLength(0); x++)
            {
                for (int y = 0; y < field.Field_.GetLength(1); y++)
                {
                    if (random.Next(0, 100) < Chance)
                    {
                        if (field.Field_[x, y] == StartType)
                        {
                            requiredTypeNeighboors = CountNeighbors(x, y, RequiredType);
                            if (CellsCount.Contains(requiredTypeNeighboors))
                            {
                                field.Field_[x, y] = EndType;
                            }
                        }
                    }
                }
            }

            byte CountNeighbors(int x, int y, Cell type)
            {
                byte count = 0;
                for (int i = -1; i < 1; i++)
                {
                    for (int j = -1; j < 1; j++)
                    {
                        if (i == 0 || j == 0)
                        {
                            continue;
                        }
                        if (field.Field_[x + i, y + j] == type)
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
