
namespace Celluros
{
    public struct Cell
    {
        public int Id 
        {
            get; 
            private set; 
        }

        public Cell(int id)
        {
            Id = id;
        }

        public Cell(Cell other)
        {
            Id = other.Id;
        }

        public static bool operator ==(Cell left, Cell right)
        {
            return left.Id == right.Id;
        }

        public static bool operator !=(Cell left, Cell right)
        {
            return !(left == right);
        }

    }
}
