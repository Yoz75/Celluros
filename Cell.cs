
namespace Celluros
{
    public struct Cell
    {
        public int Id 
        {
            get; 
            private set; 
        }

        private int LastId;

        public Cell()
        {
            Id = LastId;
            LastId++;
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
