using ChefEngine.Entities;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace ChefEngine.Physics
{
    /// <summary>
    /// PhysicsSystem class for simulating physics on entities.
    /// </summary>
    public class PhysicsSystem
    {
        // The gravity acceleration value of the physics system.
        public Vector2 GravityAcceleration { get; private set; }

        /// <summary>
        /// Constructor for the PhysicsSystem class.
        /// </summary>
        /// <param name="gravityAcceleration">Acceleration caused by gravity.</param>
        public PhysicsSystem(Vector2 gravityAcceleration)
        {
            // Set the gravity acceleration value.
            GravityAcceleration = gravityAcceleration;
        }

        /// <summary>
        /// Updates the system to simulate physics.
        /// </summary>
        /// <param name="gameTime">The game time instance.</param>
        /// <param name="entityCollection">The entities to simulate physics on.</param>
        public void Update(GameTime gameTime, EntityCollection entityCollection)
        {
            // Get the elapsed time since the last frame, in seconds.
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            // For each entity in the provided collection.
            foreach (Entity entity in entityCollection.Entities)
            {
                // If there is non-zero gravity and the entity is affected by gravity.
                if (GravityAcceleration != Vector2.Zero && entity.IsAffectedByGravity)
                {
                    // Apply gravity acceleration to the entity's velocity.
                    entity.Velocity += GravityAcceleration * deltaTime;
                }

                // Apply velocity to the entity's position to simulate movement.
                entity.Position += entity.Velocity * deltaTime;
            }

            // For each entity in the provided collection.
            for (int i = 0; i < entityCollection.Entities.Count; i++)
            {
                // Get a reference to entity A.
                Entity a = entityCollection.Entities[i];

                // If entity A has a collider.
                if (a.Collider != null)
                {
                    // For each other entity that is not A.
                    for (int j = i + 1; j < entityCollection.Entities.Count; j++)
                    {
                        // Get a reference to entity B.
                        Entity b = entityCollection.Entities[j];

                        // If entity B has a collider.
                        if (b.Collider != null)
                        {
                            // Check for collisions between entity A and B.
                            CollisionResult collisionResult = CollisionManager.CheckCollision(a.Collider, b.Collider);

                            // If there is a collision.
                            if (collisionResult.HasCollision)
                            {
                                // Log it.
                                Debug.WriteLine("Collision detected.");
                            }
                        }
                    }
                }
            }
        }
    }
}
