using ChefEngine.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChefEngine.Entities
{
    /// <summary>
    /// Entity abstract class for defining generic entity objects.
    /// </summary>
    public abstract class Entity
    {
        // The entity's position.
        public Vector2 Position { get; protected set; }

        // The entity's collider.
        public Collider? Collider { get; protected set; }

        /// <summary>
        /// Updates the state of the entity.
        /// </summary>
        /// <param name="gameTime">The game time instance.</param>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Submits the entity for drawing on the screen.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to draw the entity in.</param>
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
