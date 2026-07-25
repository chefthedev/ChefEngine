namespace ChefEngine.Physics
{
    /// <summary>
    /// CollisionResult struct for modeling the result of a collision.
    /// </summary>
    public struct CollisionResult
    {
        // The collision status of the result.
        public bool HasCollision { get; private set; }

        // Static collision result with a false value.
        public static CollisionResult None => new(false);

        /// <summary>
        /// Constructor for the CollisionResult struct.
        /// </summary>
        /// <param name="hasCollision"></param>
        public CollisionResult(bool hasCollision)
        {
            // Set the HasCollision property.
            HasCollision = hasCollision;
        }
    }
}
