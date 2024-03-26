
using System;

namespace Celluros
{
    public class Field
    {
        private Cell[,] Field_;

        public Field(int xSize, int ySize, params Cell[] startTypes)
        { 
            Field_ = new Cell[xSize, ySize];

            Random random = new Random();

            for (int x = 0; x < xSize; x++) 
            {
                for(int y = 0; y < ySize; y++)
                {
                    Field_[x, y] = startTypes[random.Next(0, startTypes.Length)];
                }
            }

        }

        public Cell[,] GetField()
        {
            Cell[,] field = new Cell[Field_.GetLength(0), Field_.GetLength(1)];

            for (int x = 0; x < Field_.GetLength(0); x++)
            {
                for (int y = 0; y < Field_.GetLength(1); y++)
                {
                    field[x,y] = new Cell(Field_[x, y]);
                }

            }

            return field;
        }

        public void SetField(Cell[,] newField)
        {
            Field_ = newField;
        }

        public bool IsTypeAtPosition(int x, int y, Cell type)
        {
            int newX, newY;
            newX = x;
            newY = y;
            ToFieldBorders(x, y, ref newX, ref newY);

            if(Field_[newX, newY] == type)
            {
                return true;
            }

            return false;
        }

        private void ToFieldBorders(int x, int y, ref int newX, ref int newY)
        {
            if(x < 0)
            {
                newX = Field_.GetLength(0) - x;
            }

            if(y < 0)
            {
                newY = Field_.GetLength(1) - y;
            }

            if(x >= Field_.GetLength(0))
            {
                newX = x - Field_.GetLength(0);
            }

            if(y >= Field_.GetLength(1))
            {
                newY = y - Field_.GetLength(0);
            }
        }

        public int GetLength(int dimension)
        {
            return Field_.GetLength(dimension);
        }


    }
}
