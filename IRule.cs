using Celluros.Conditions;
using System;
using System.Collections.Generic;

namespace Celluros;

/// <summary>
/// Something that executes conditions on a cell of the field (a compilation of conditions)
/// </summary>
public interface IRule
{
    /// <summary>
    /// Execute conditions on a field
    /// </summary>
    /// <param name="field">the field</param>
    public void Execute(Field field);

    /// <summary>
    /// The conditions to be executed on a field
    /// </summary>
    public IList<Condition> Conditions
    {
        get;
    }

    /// <summary>
    /// Is this rule can be executed?
    /// </summary>
    /// <returns>true if field can be executed and false otherwise </returns>
    public bool CanBeExecuted();

    /// <summary>
    /// Called when the rule can't execute further
    /// </summary>
    public event Action Completed;
}