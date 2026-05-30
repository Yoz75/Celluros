
namespace Celluros.Conditions
{
    /// <summary>
    /// Base class for all conditions
    /// </summary>
    public abstract class Condition
    {
        /// <summary>
        /// Name of condition (just for GUI, or to distinguish one condition from another)
        /// </summary>
        public string? Name;

        /// <summary>
        /// Calculate condition 
        /// </summary>
        /// <param name="neighbors">field where condition is calculated</param>
        /// <param name="isChangedCell">is condition changed cell or not?</param>
        /// <param name="frame">whole game field (kostyland govnocode)</param>
        /// <returns>Calculated cell type</returns>
        public abstract Cell Calculate(Field field, int selfX, int selfY, out bool isChangedCell);
    }
}
