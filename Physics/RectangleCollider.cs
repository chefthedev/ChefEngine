using ChefEngine.Entities;
using ChefEngine.Geometry;
using ChefEngine.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChefEngine.Physics
{
    /// <summary>
    /// RectangleCollider class for modeling rectangular colliders.
    /// </summary>
    public class RectangleCollider : Collider
    {
        // Local bounds of the collider, relative to the owner itself.
        public RectangleF LocalBounds { get; set; }

        // Bounds of the collider, relative to the owner's position in the world.
        public RectangleF Bounds
        {
            get
            {
                return new RectangleF(
                    Owner.Position.X + LocalBounds.X,
                    Owner.Position.Y + LocalBounds.Y,
                    LocalBounds.Width,
                    LocalBounds.Height
                );
            }
        }

        /// <summary>
        /// Constructor for the RectangleCollider class.
        /// </summary>
        /// <param name="owner">Reference to the owner entity of the collider.</param>
        /// <param name="localBounds">Rectangle representing the local bounds of the collider.</param>
        public RectangleCollider(Entity owner, RectangleF localBounds) : base(owner)
        {
            // Set the local bounds of the rectangular collider.
            LocalBounds = localBounds;
        }

        public override void DebugDraw(SpriteBatch spriteBatch, Color color, int thickness = 1)
        {
            // Draw the outline of the rectangular collider.
            DebugRenderer.DrawRectangleFOutline(spriteBatch, Bounds, color, thickness);
        }
    }
}
