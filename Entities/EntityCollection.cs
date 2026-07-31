using System.Collections.Generic;

namespace ChefEngine.Entities
{
    /// <summary>
    /// EntityCollection class for storing a list of entities.
    /// </summary>
    public class EntityCollection
    {
        // List of entities backing the collection.
        private List<Entity> _entities;

        // Entities to add to the collection.
        private readonly List<Entity> _entitiesToAdd;

        // Entities to remove from the collection.
        private readonly List<Entity> _entitiesToRemove;

        // Read only reference to the list of entities.
        public IReadOnlyList<Entity> Entities => _entities;

        /// <summary>
        /// Constructor for the EntityCollection class.
        /// </summary>
        public EntityCollection()
        {
            // Initialize the lists.
            _entities = new List<Entity>();
            _entitiesToAdd = new List<Entity>();
            _entitiesToRemove = new List<Entity>();
        }

        /// <summary>
        /// Schedule an entity to be added.
        /// </summary>
        /// <param name="entity">Entity to add.</param>
        public void Add(Entity entity)
        {
            // Schedule the add.
            _entitiesToAdd.Add(entity);
        }

        /// <summary>
        /// Schedule a range of entities to be added.
        /// </summary>
        /// <param name="entities">Range of entities.</param>
        public void AddRange(IEnumerable<Entity> entities)
        {
            // Schedule the add range.
            _entitiesToAdd.AddRange(entities);
        }

        /// <summary>
        /// Schedule an entity to be removed.
        /// </summary>
        /// <param name="entity">Entity to remove.</param>
        public void Remove(Entity entity)
        {
            // Schedule the remove.
            _entitiesToRemove.Add(entity);
        }

        /// <summary>
        /// Applies all pending additions and removals to the entity list.
        /// </summary>
        public void ApplyPendingChanges()
        {
            // For each entity scheduled for removal.
            foreach (Entity entity in _entitiesToRemove)
            {
                // Remove it.
                _entities.Remove(entity);
            }
            _entitiesToRemove.Clear();

            // Add each entity scheduled for addition.
            _entities.AddRange(_entitiesToAdd);
            _entitiesToAdd.Clear();
        }
    }
}
