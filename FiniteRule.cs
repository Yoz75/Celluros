
using Celluros.Conditions;
using System;
using System.Collections.Generic;

namespace Celluros;

/// <summary>
/// A <see cref="IRule"/> that can be executed infinite or X times
/// </summary>
public class FiniteRule : IRule
{
    /// <summary>
    /// Name of rule (just for GUI, or to distinguish one condition from another)
    /// </summary>
    public string? Name;
    private int CurrentIteration = 0;
    private int IterationsCount;
    private bool IsCompleted;

    public IList<Condition> Conditions
    {
        get;
        private set;
    } = [];

    private Cell[,]? TempField;

    public event Action? Completed;

    /// <summary>
    /// Create a new <see cref="FiniteRule"/>
    /// </summary>
    /// <param name="iterationsCount">the count of iterations. Set 0 if you want to infinitly execute the rule</param>
    public FiniteRule(int iterationsCount)
    {
        IterationsCount = iterationsCount;  
    }

    public void Execute(Field field)
    {
        var fieldXSize = field.Resolution.Item1;
        var fieldYSize = field.Resolution.Item2;

        if(TempField is null || TempField.GetLength(0) != fieldXSize && TempField.GetLength(1) != fieldYSize)
        {
            TempField = new Cell[fieldXSize, fieldYSize];
        }

        if(CurrentIteration >= IterationsCount)
        {
            IsCompleted = true;
            return;
        }

        for(int y = 0; y < fieldYSize; y++)
        {
            for(int x = 0; x < fieldXSize; x++)
            {
                foreach(var condition in Conditions)
                {
                    Cell newCell = condition.Calculate(field, x, y, out bool isChangedCell);

                    if(isChangedCell)
                    {
                        TempField[x, y] = newCell;
                        break;
                    }

                    TempField[x, y] = field.Field_[x, y];
                }
            }
        }

        for(int y = 0;y < fieldYSize; y++)
        {
            for (int x = 0;x < fieldXSize; x++)
            {
                field.Field_[x, y] = TempField[x, y];
            }
        }

        CurrentIteration++;
    }

    public void SetIterationsCount(int iterationsCount)
    {
        IterationsCount = iterationsCount;
    }

    public bool CanBeExecuted() => !IsCompleted;
}
