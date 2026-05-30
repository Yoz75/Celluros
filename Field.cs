
using System;

namespace Celluros;

/// <summary>
/// A "smart" wrap over a 2D <see cref="Cell"/> array
/// </summary>
public class Field
{
    public Cell[,] Field_;

    public (int, int) Resolution
    {
        get;
        private init;
    }

    public Field(int xSize, int ySize, params Cell[] startTypes)
    { 
        Field_ = new Cell[xSize, ySize];
        Resolution = (xSize, ySize);

        for (int x = 0; x < xSize; x++) 
        {
            for(int y = 0; y < ySize; y++)
            {
                Field_[x, y] = startTypes[Random.Shared.Next(0, startTypes.Length)];
            }
        }
    }

    /// <summary>
    /// Safe interface to get a cell at the [x, y] position. Normalizes coordinates
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public Cell GetAtNormalized(int x, int y)
    {
        NormalizeCoordinates(x, y, out int newX, out int newY);

        return Field_[newX, newY];
    }

    /// <summary>
    /// Safe interface to set a cell at the [x, y] position. Normalizes coordinates
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    public void SetAtNormalized(int x, int y, Cell cell)
    {
        NormalizeCoordinates(x, y, out int newX, out int newY);

        Field_[newX, newY] = cell;
    }

    /// <summary>
    /// Safe interface to check if a cell of type <see cref="type"/> is placed at a position
    /// </summary>
    /// <returns>true if cell at coordinates [x, y] has type <see cref="type"/>, false otherwise</returns>
    public bool IsAtNormalized(int x, int y, Cell type)
    {
        NormalizeCoordinates(x, y, out int newX, out int newY);

        if(Field_[newX, newY] == type)
        {
            return true;
        }

        return false;
    }

    private void NormalizeCoordinates(int x, int y, out int newX, out int newY)
    {
        newX = x;
        newY = y;

        if(x < 0)
        {
            newX = Resolution.Item1 - 1;
        }

        if(y < 0)
        {
            newY = Resolution.Item2 - 1;
        }

        newX %= Resolution.Item1;
        newX %= Resolution.Item2;
    }

    public Neighbors GetNeighbors(int xPosition, int yPosition)
    {
        Neighbors neighbors = default;

        bool isXInRange = xPosition > 0 && xPosition + 1 < Resolution.Item1;
        bool isYInRange = yPosition > 0 && yPosition + 1< Resolution.Item2;

        neighbors.Upper = isYInRange ? Field_[xPosition, yPosition - 1] : default;
        neighbors.UpperRight = isXInRange && isYInRange ? Field_[xPosition + 1, yPosition - 1] : default;

         neighbors.Right = isXInRange ? Field_[xPosition + 1, yPosition] : default;
        neighbors.DownRight = isXInRange && isYInRange ? Field_[xPosition + 1, yPosition + 1] : default;

        neighbors.Down = isYInRange ? Field_[xPosition, yPosition + 1] : default;
        neighbors.DownLeft = isXInRange && isYInRange ? Field_[xPosition - 1, yPosition + 1] : default;

        neighbors.Left = isXInRange ? Field_[xPosition - 1, yPosition] : default;
        neighbors.UpperLeft = isXInRange && isYInRange ? Field_[xPosition - 1, yPosition - 1] : default;

        return neighbors;
    }
}
