﻿
using System;

namespace Celluros.Conditions
{
    public class LocalPositionCondition : Condition
    {

        private Tuple<sbyte, sbyte> Bias;
        private float Chance;
        private Cell StartType;
        private Cell RequiredType;
        private Cell EndType;

        public LocalPositionCondition(Tuple<sbyte, sbyte> bias, float chance, Cell startType, Cell requiredType, Cell endType)
        {
            if(bias.Item1 < -1 || bias.Item1 > 1 || bias.Item2 < -1 || bias.Item2 > 1)
            {
                throw new ArgumentException("Bias elements can only be -1, 0 or 1!");
            }
            Chance = chance;
            StartType = startType;
            RequiredType = requiredType;
            EndType = endType;
        }
        public override void Calculate(Field field)
        {
            Random random = new Random();
            for(int x = 0; x < field.GetLength(0); x++)
            {
                for(int y = 0; y < field.GetLength(1); y++)
                {
                    if(random.Next(0, 100) < Chance)
                    {
                        field.SetAtPosition(x + Bias.Item1, y + Bias.Item2, EndType);
                    }
                }
            }

        }
    }
}