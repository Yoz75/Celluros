
using Celluros.Conditions;
using System;
using System.Collections.Generic;

namespace Celluros
{
    public class Rule
    {

        private int CurrentIteration = 0;
        private int MaxIteration;

        public Rule(int iterations)
        {
            MaxIteration = iterations;
        }

        public bool IsCompleted
        {
            get;
            private set;
        } = false;

        public List<Condition> Conditions
        {
            get;
            private set;
        } = new List<Condition>();

        public void Execute(Field field)
        {
            if(CurrentIteration >= MaxIteration)
            {
                IsCompleted = true;
                return;
            }

            CurrentIteration++;

            Cell[,] newField = field.GetField();

            for(int x = 0; x < field.GetLength(0); x++)
            {
                for(int y = 0; y < field.GetLength(1); y++)
                {
                    foreach(var condition in Conditions)
                    {
                        bool isChangedCell;
                        var neighbors = GetNeighbors(x, y, field);
                        Cell newCell = condition.Calculate(neighbors, out isChangedCell, newField);

                        if(isChangedCell)
                        {
                            newField[x, y] = newCell;
                            break;
                        }
                    }
                }
            }

            field.SetField(newField);
        }

        private CellNeighbors GetNeighbors(int xPosition, int yPosition, Field field)
        {
            CellNeighbors neighbors = new();
            neighbors.SelfXPosition = xPosition;
            neighbors.selfYPosition = yPosition;

            int xCounter, yCounter;
            xCounter = yCounter = 0;

            for(int x = -CellNeighbors.Depth; x <= CellNeighbors.Depth; x++)
            {
                for(int y = -CellNeighbors.Depth; y <= CellNeighbors.Depth; y++)
                {
                    neighbors.Neighbors[xCounter, yCounter].Cell = 
                        field.GetTypeAtPosition(xPosition + x, yPosition + y);
                    
                    yCounter++;
                }
                yCounter = 0;
                xCounter++;
            }

            neighbors.Neighbors[neighbors.SelfIndex, neighbors.SelfIndex].IsSelf = true;
            return neighbors;
        }
    }
}
