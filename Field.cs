
namespace Celluros
{
    public class Field
    {
        public Cell[,] Field_
        {
            get;
            private set;
        }
        public Field(uint xSize, uint ySize)
        { 
            Field_ = new Cell[xSize, ySize];
        }

        public void SetAtPosition(uint x, uint y, Cell instance)
        {
            Field_[x,y] = instance;
        }
    }
}
