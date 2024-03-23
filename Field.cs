
namespace Celluros
{
    public class Field
    {
        private Cell[,] Field_;

        public Field(int xSize, int ySize)
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

            if(Field_[newX, newY] == type)
            {
                return true;
            }

            return false;
        }

        public uint GetLength(int dimension)
        {
            return (uint)Field_.GetLength(dimension);
        }


    }
}
