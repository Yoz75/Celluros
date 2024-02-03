
namespace Celluros
{
    public class Field
    {
        private Cell[,] Field_;
        public Field(int xSize, int ySize)
        { 
            Field_ = new Cell[xSize, ySize];
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
            Field_[newX,newY] = instance;
        }

        public bool IsTypeAtPosition(int x, int y, Cell type)
        {
            if(Field_[x,y] == type)
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
