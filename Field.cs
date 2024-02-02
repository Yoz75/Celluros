
namespace Celluros
{
    public class Field
    {
        private Cell[,] Field_;
        public Field(uint xSize, uint ySize)
        { 
            Field_ = new Cell[xSize, ySize];
        }

        public void SetAtPosition(uint x, uint y, Cell instance)
        {
            Field_[x,y] = instance;
        }

        public bool IsTypeAtPosition(uint x, uint y, Cell type)
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
