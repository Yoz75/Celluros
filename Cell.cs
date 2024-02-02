
namespace Celluros
{
    public struct Cell
    {
        public int Id 
        {
            get; 
            set; 
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
