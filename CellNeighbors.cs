
namespace Celluros
{
    /// <summary>
    /// A neighbor of a cell
    /// </summary>
    public struct Neighbor
    {
        /// <summary>
        /// the neighbor
        /// </summary>
        public Cell Cell;

        /// <summary>
        /// Is this cell not a neighbor, but main cell itself?
        /// </summary>
        public bool IsSelf;
    }

    public class CellNeighbors
    {
        /// <summary>
        /// How much neighbors we use? (e.g. 1 - only cell neighbors, 
        /// 2 - cell neighbors and neighbors of cell neighbors
        /// </summary>
        public static int Depth = 1;
        public Neighbor[,] Neighbors;
        public int SelfXPosition, selfYPosition;

        public CellNeighbors()
        {
            //У нас есть двумерный квадрат, со стороной равной нечтному числу,
            //путём рисования на листке я понял, что сторона такого квадрата всегда равна 
            //глубине соседей + 1, т.к у нас фактически  n соседей в одну сторону и столько же
            //в другую + сама клетка (это всё для одной координаты, но у нас это квадрат, а потому
            //оно работает для обеих)
            Neighbors = new Neighbor[Depth * 2 + 1, Depth * 2 + 1];
        }

        /// <summary>
        /// Get self x and y indices in Neighbors matrix (we use square neighbors matrix, x size == y size) 
        /// </summary>
        /// <returns></returns>
        public int SelfIndex
        {
            get
            {
                return (Depth * 2 + 1) / 2;
            }
        }
    }
}
