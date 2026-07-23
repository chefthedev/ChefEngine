using System.Collections.Generic;

namespace ChefEngine.Entities
{
    /// <summary>
    /// EntityCollection class for storing a list of entities.
    /// </summary>
    public class EntityCollection
    {
        // List of entities.
        private List<Entity> _entities;

        // List of entities to add to the list.
        private readonly List<Entity> _entitiesToAdd;

        // List of entities to remove from the list.
        private readonly List<Entity> _entitiesToRemove;

        // Read only reference to the entity list.
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
        /// <param name="entity">The entity to add.</param>
        public void Add(Entity entity)
        {
            // Schedule the add.
            _entitiesToAdd.Add(entity);
        }

        /// <summary>
        /// Schedule a range of entities to be added.
        /// </summary>
        /// <param name="entities">The range of entities.</param>
        public void AddRange(IEnumerable<Entity> entities)
        {
            // Schedule the add range.
            _entitiesToAdd.AddRange(entities);
        }

        /// <summary>
        /// Schedule an entity to be removed.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
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
