namespace BookStore.Core.Domain
{
    /// <summary>
    /// Represents the base class for entities.
    /// </summary>
    /// <typeparam name="TPrimaryKey">Type of the primary key of the entity</typeparam>
    public abstract class Entity<TPrimaryKey> : IEntity<TPrimaryKey>
    {
        /// <summary>
        /// Gets or sets the entity identifier
        /// </summary>
        public virtual TPrimaryKey Id { get; set; }
    }
}
