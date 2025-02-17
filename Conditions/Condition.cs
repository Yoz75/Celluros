
namespace Celluros.Conditions
{
    public abstract class Condition
    {
        public abstract Cell Calculate(CellNeighbors neighbors, out bool isChangedCell, Cell[,] frame);
    }
}
