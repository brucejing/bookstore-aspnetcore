namespace BookStore.Core.Domain
{
    /// <summary>
    /// Interface of the base class for all entities.
    /// </summary>
    /// <typeparam name="TPrimaryKey">Type of the primary key of the entity</typeparam>
    public interface IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        TPrimaryKey Id { get; set; }
    }
}
