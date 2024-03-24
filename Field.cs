﻿
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

        private Field(int xSize, int ySize)
        {
            Field_ = new Cell[xSize, ySize];
        }

        public Cell[,] GetField()
        {
            Cell[,] field = new Cell[Field_.GetLength(0), Field_.GetLength(1)];

            for (int x = 0; x < Field_.GetLength(0); x++)
            {
                for (int y = 0; y < Field_.GetLength(1); y++)
                {
                    field[x,y] = Field_[x, y];
                }

            }

            return Field_;
        }

        public Field Copy()
        {
            Field result = new Field(GetLength(0), GetLength(1));

            result.Field_ = GetField();

            return result;
        }

        public void SetAtPosition(int x, int y, Cell instance)
        {
            int newX, newY;
            newX = x;
            newY = y;
            if(x < 0)
            {
                newX = Field_.GetLength(0) - 1;
            }

            if(y < 0) 
            {
                newY = Field_.GetLength(1) - 1;
            }

            if(x >= Field_.GetLength(0))
            {
                newX = 0;
            }

            if(y >= Field_.GetLength(1))
            {
                newY = 0;
            }

            Field_[newX,newY] = instance;
        }

        public bool IsTypeAtPosition(int x, int y, Cell type)
        {
            int newX, newY;
            newX = x;
            newY = y;
            if(x < 0)
            {
                newX = Field_.GetLength(0) - 1;
            }

            if(y < 0)
            {
                newY = Field_.GetLength(1) - 1;
            }

            if(x >= Field_.GetLength(0))
            {
                newX = 0;
            }

            if(y >= Field_.GetLength(1))
            {
                newY = 0;
            }

            if(Field_[newX, newY] == type)
            {
                return true;
            }

            return false;
        }

        public int GetLength(int dimension)
        {
            return Field_.GetLength(dimension);
        }


    }
}
