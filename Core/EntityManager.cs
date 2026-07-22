using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace ChefEngine.Core
{
    /// <summary>
    /// EntityManager class for managing the list of entities.
    /// </summary>
    public class EntityManager
    {
        // List of all entities.
        private List<Entity> _entities;

        // List of entities to add to the global list.
        private readonly List<Entity> _entitiesToAdd;

        // List of entities to remove from the global list.
        private readonly List<Entity> _entitiesToRemove;

        // Read only reference to the global entity list.
        public IReadOnlyList<Entity> Entities => _entities;

        /// <summary>
        /// Constructor for the EntityManager class.
        /// </summary>
        public EntityManager()
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
        /// Updates all entities and applies any pending additions and removals.
        /// </summary>
        /// <param name="gameTime">The game time instance.</param>
        public void Update(GameTime gameTime)
        {
            // For each entity in the global list.
            foreach (Entity entity in _entities)
            {
                // Update it.
                entity.Update(gameTime);
            }

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

        /// <summary>
        /// Submit each entity for drawing.
        /// </summary>
        public void Draw()
        {
            // For each entity in the global list.
            foreach (Entity entity in _entities)
            {
                // Draw it.
                entity.Draw();
            }
        }
    }
}
