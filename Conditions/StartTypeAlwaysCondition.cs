
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

        public override void Calculate(in Field field)
        {
            Random random = new Random();

            Cell[,] newFrame = field.GetField();

            for(int x = 0; x < field.GetLength(0); x++)
            {
                for(int y = 0; y < field.GetLength(1); y++)
                {
                    if(field.IsTypeAtPosition(x,y, StartType))
                    {
                        if(random.Next(0, 100) < Chance)
                        {
                            newFrame.SetAtPosition(x, y, EndType);
                        }
                    }
                }
            }

            field.SetField(newFrame);

        }
    }
}
