using Microsoft.Xna.Framework;

namespace ChefEngine.Physics
{
    /// <summary>
    /// CollisionResult struct for modeling the result of a collision between two entities.
    /// </summary>
    public struct CollisionResult
    {
        // Whether A is colliding with B.
        public bool HasCollision { get; private set; }

        // Best geometric estimate of the collision normal, pointing from A toward B.
        public Vector2 Normal { get; private set; }

        // Minimum translation distance required to separate the colliders.
        public float PenetrationDepth { get; private set; }

        // Static collision result with a false value.
        public static CollisionResult None => new(false, Vector2.Zero, 0.0f);

        /// <summary>
        /// Constructor for the CollisionResult struct.
        /// </summary>
        /// <param name="hasCollision">Whether a collision occurred or not.</param>
        /// <param name="normal">Direction to separate the colliding objects.</param>
        /// <param name="penetrationDepth">Amount of overlap between the objects.</param>
        public CollisionResult(bool hasCollision, Vector2 normal, float penetrationDepth)
        {
            // Set the collision result properties.
            HasCollision = hasCollision;
            Normal = normal;
            PenetrationDepth = penetrationDepth;
        }

        public override string ToString()
        {
            // Convert the collision result to a string representation.
            return $"HasCollision: {HasCollision}. Normal: {Normal}. Penetration: {PenetrationDepth}.";
        }
    }
}
