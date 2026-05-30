
namespace Celluros
{
    /// <summary>
    /// A unique type of cells/ E.g "alive", "dead", "beach", "ocean" etc.
    /// </summary>
    public struct Cell
    {
        /// <summary>
        /// Unique value that distinguishes different types. <see cref="int.MinValue"/> is considered as invalid value and is being default. 
        /// </summary>
        public int Id
        {
            get;
            private set;
        } = int.MinValue;

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

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
