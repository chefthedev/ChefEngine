using ChefEngine.Entities;
using Microsoft.Xna.Framework;

namespace ChefEngine.Physics
{
    /// <summary>
    /// PhysicsSystem class for simulating physics on entities.
    /// </summary>
    public class PhysicsSystem
    {
        /// <summary>
        /// Constructor for the PhysicsSystem class.
        /// </summary>
        public PhysicsSystem()
        {

        }

        /// <summary>
        /// Updates the system to simulate physics.
        /// </summary>
        /// <param name="gameTime">The game time instance.</param>
        /// <param name="entityCollection">The entities to simulate physics on.</param>
        public void Update(GameTime gameTime, EntityCollection entityCollection)
        {
            // For each entity in the provided collection.
            foreach (Entity entity in entityCollection.Entities)
            {
                // Apply velocity to the entity to simulate movement.
                entity.Position += entity.Velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
            }
        }
    }
}
