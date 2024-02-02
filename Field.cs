
namespace Celluros
{
    public class Field
    {
        public Cell[,] Field_
        {
            get;
            private set;
        }
        public Field(int xSize, int ySize)
        { 
            Field_ = new Cell[xSize, ySize];
        }

        public void SetAtPosition(int x, int y, Cell instance)
        {
            Field_[x,y] = instance;
        }
    }
}
