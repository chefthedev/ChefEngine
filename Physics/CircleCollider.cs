using ChefEngine.Geometry;
using ChefEngine.Core;

namespace ChefEngine.Physics
{
    /// <summary>
    /// CircleCollider class for modeling circular colliders.
    /// </summary>
    public class CircleCollider : Collider
    {
        // The circle representing the local bounds of the collider, relative to the owner itself.
        public CircleF LocalBounds { get; set; }

        // The circle represending the bounds of the collider, relative to the owner's position in the world.
        public CircleF Bounds
        {
            get
            {
                return new CircleF(
                    Owner.Position.X + LocalBounds.X,
                    Owner.Position.Y + LocalBounds.Y,
                    LocalBounds.Radius
                );
            }
        }

        /// <summary>
        /// Constructor for the CircleCollider class.
        /// </summary>
        /// <param name="owner">Reference to the owner entity of the collider.</param>
        /// <param name="localBounds">Circle representing the local bounds of the collider.</param>
        public CircleCollider(Entity owner, CircleF localBounds) : base(owner)
        {
            // Set the local bounds of the circular collider.
            LocalBounds = localBounds;
        }
    }
}
