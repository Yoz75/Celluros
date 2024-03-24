
namespace Celluros
{
    public static class CellMatrixExtensions
    {
        public static void SetAtPosition(this Cell[,] field, int x, int y, Cell instance)
        {
            int newX, newY;
            newX = x;
            newY = y;
            if(x < 0)
            {
                newX = field.GetLength(0) - 1;
            }

            if(y < 0)
            {
                newY = field.GetLength(1) - 1;
            }

            if(x >= field.GetLength(0))
            {
                newX = 0;
            }

            if(y >= field.GetLength(1))
            {
                newY = 0;
            }

            field[newX, newY] = instance;
        }
    }
}
