namespace Northwind.Core.Contracts
{
    /// <summary>
    /// Marker interface which marks reference data entities.
    /// </summary>
    /// <remarks>
    /// Reference data entities have usually the following things in common:
    /// - they are referenced by many records
    /// - business rules depend on them
    /// - are often, if not always loaded (participate in many 'Includes')
    /// - rarely changing
    /// </remarks>
    public interface IReferenceData : ICacheable
    {
    }
}
