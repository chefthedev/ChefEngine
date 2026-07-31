using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace ChefEngine.Physics
{
    /// <summary>
    /// CollisionManager static class for performing collision checks between colliders.
    /// </summary>
    public static class CollisionManager
    {
        // Delegate function for testing collisions.
        private delegate CollisionResult CollisionTest(Collider a, Collider b);

        // Bindings for types of colliders to the proper collision test.
        private static readonly Dictionary<(Type, Type), CollisionTest> _collisionTests;

        /// <summary>
        /// Static constructor for the CollisionManager class.
        /// </summary>
        static CollisionManager()
        {
            // Initialize the collision tests dictionary with each binding.
            _collisionTests = new Dictionary<(Type, Type), CollisionTest>()
            {
                // Rectangle to Rectangle.
                {
                    (typeof(RectangleCollider), typeof(RectangleCollider)),
                    (a, b) => RectangleRectangle((RectangleCollider)a, (RectangleCollider)b)
                },
            };
        }

        /// <summary>
        /// Checks the collision status between two colliders.
        /// </summary>
        /// <param name="a">First collider.</param>
        /// <param name="b">Second collider.</param>
        /// <returns>Collision result of the colliders.</returns>
        public static CollisionResult CheckCollision(Collider a, Collider b)
        {
            // If either of the colliders are disabled.
            if (!a.IsEnabled || !b.IsEnabled)
            {
                // Return a no collision result.
                return CollisionResult.None;
            }

            // If there is a collision test for the type bindings.
            if (_collisionTests.TryGetValue((a.GetType(), b.GetType()), out CollisionTest? test))
            {
                // Call the collision test.
                return test(a, b);
            }

            // Return a no collision result otherwise.
            return CollisionResult.None;
        }

        /// <summary>
        /// Determine if two rectangles are colliding.
        /// </summary>
        /// <param name="a">First rectangle.</param>
        /// <param name="b">Second rectangle.</param>
        /// <returns>Collision result of the rectangles.</returns>
        private static CollisionResult RectangleRectangle(RectangleCollider a, RectangleCollider b)
        {
            // Perform the calculations.
            bool hasCollision = a.Bounds.Right > b.Bounds.Left
                && b.Bounds.Right > a.Bounds.Left
                && a.Bounds.Bottom > b.Bounds.Top
                && b.Bounds.Bottom > a.Bounds.Top;

            // If there is a collision.
            if (hasCollision)
            {
                // Initialize the result metadata.
                Vector2 normal;
                float penetrationDepth;

                // Calculate the x and y overlap.
                float xOverlap = MathF.Min(a.Bounds.Right, b.Bounds.Right) - MathF.Max(a.Bounds.Left, b.Bounds.Left);
                float yOverlap = MathF.Min(a.Bounds.Bottom, b.Bounds.Bottom) - MathF.Max(a.Bounds.Top, b.Bounds.Top);

                // If the x overlap is less than the y overlap.
                if (xOverlap < yOverlap)
                {
                    // Determine the direction of the collision.
                    float directionX = MathF.Sign(b.Bounds.Center.X - a.Bounds.Center.X);
                    
                    // If the two rectangles have the same x center.
                    if (directionX == 0.0f)
                    {
                        // Overlapping centers provide no meaningful collision direction.
                        // Choose a deterministic positive direction.
                        directionX = 1.0f;
                    }
                    
                    // Set the normal and penetration depth values.
                    normal = new Vector2(directionX, 0.0f);
                    penetrationDepth = xOverlap;
                }
                // Else, the y overlap is less or equal to the x overlap.
                else
                {
                    // Determine the direction of the collision.
                    float directionY = MathF.Sign(b.Bounds.Center.Y - a.Bounds.Center.Y);

                    // If the two rectangles have the same y center.
                    if (directionY == 0.0f)
                    {
                        // Overlapping centers provide no meaningful collision direction.
                        // Choose a deterministic positive direction.
                        directionY = 1.0f;
                    }

                    // Set the normal and penetration depth values.
                    normal = new Vector2(0.0f, directionY);
                    penetrationDepth = yOverlap;
                }

                // Return the collision result.
                return new(true, normal, penetrationDepth);
            }
            else
            {
                // Return a none collision result.
                return CollisionResult.None;
            }
        }
    }
}
