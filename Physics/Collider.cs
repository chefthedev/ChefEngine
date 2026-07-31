using ChefEngine.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChefEngine.Physics
{
    /// <summary>
    /// Collider abstract class for representing base collider properties.
    /// </summary>
    public abstract class Collider
    {
        // Reference to the owner entity.
        public Entity Owner { get; private set; }

        // Whether the collider is enabled, defaulting to true.
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        /// Constructor for the collider abstract class.
        /// </summary>
        /// <param name="owner">Reference to the owner entitiy of the collider.</param>
        protected Collider(Entity owner)
        {
            // Set the owner entity reference.
            Owner = owner;
        }

        /// <summary>
        /// Draws the collider bounds for debugging.
        /// </summary>
        /// <param name="spriteBatch">Sprite batch to draw the collider in.</param>
        /// <param name="color">Color to draw the collider in.</param>
        /// <param name="thickness">Thickness to draw the collider with.</param>
        public abstract void DebugDraw(SpriteBatch spriteBatch, Color color, int thickness = 1);
    }
}
