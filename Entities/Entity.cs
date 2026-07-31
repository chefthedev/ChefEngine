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
        // X,Y position of the entity in space.
        public Vector2 Position { get; set; }

        // X,Y velocity of the entity in space.
        public Vector2 Velocity { get; set; } = Vector2.Zero;

        // Whether the entity is affected by gravity.
        public bool IsAffectedByGravity { get; set; } = false;

        // Defines collision bounds of the entity.
        public Collider? Collider { get; protected set; }

        /// <summary>
        /// Updates the state of the entity.
        /// </summary>
        /// <param name="gameTime">Game time instance.</param>
        public abstract void Update(GameTime gameTime);

        /// <summary>
        /// Submits the entity for drawing on the screen.
        /// </summary>
        /// <param name="spriteBatch">Sprite batch to draw the entity in.</param>
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}
