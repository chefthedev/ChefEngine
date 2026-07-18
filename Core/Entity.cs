using Microsoft.Xna.Framework;

namespace ChefEngine.Core
{
    /// <summary>
    /// Entity abstract class for defining generic entity objects.
    /// </summary>
    public abstract class Entity
    {
        // The entity's position
        public Vector2 Position { get; protected set; }

        /// <summary>
        /// Updates the state of the entity.
        /// </summary>
        /// <param name="gameTime">The game time instance.</param>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Submits the entity for drawing on the screen.
        /// </summary>
        public abstract void Draw();
    }
}
