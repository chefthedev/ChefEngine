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

        // Dictionary for binding two types of colliders to the proper collision test.
        private static readonly Dictionary<(Type, Type), CollisionTest> _collisionTests;

        /// <summary>
        /// Static constructor for the CollisionManager class.
        /// </summary>
        static CollisionManager()
        {
            // Initialize the collision tests dictionary with each binding.
            _collisionTests = new Dictionary<(Type, Type), CollisionTest>()
            {
                // Circle to Circle.
                {
                    (typeof(CircleCollider), typeof(CircleCollider)),
                    (a, b) => CircleCircle((CircleCollider)a, (CircleCollider)b)
                },
                // Circle to Rectangle.
                {
                    (typeof(CircleCollider), typeof(RectangleCollider)),
                    (a, b) => CircleRectangle((CircleCollider)a, (RectangleCollider)b)
                },
                // Rectangle to Circle.
                {
                    (typeof(RectangleCollider), typeof(CircleCollider)),
                    (a, b) => RectangleCircle((RectangleCollider)a, (CircleCollider)b)
                },
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
        /// <param name="a">The first collider.</param>
        /// <param name="b">The second collider.</param>
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
        /// Determine if two circles are colliding.
        /// </summary>
        /// <param name="a">The first circle.</param>
        /// <param name="b">The second circle.</param>
        /// <returns>Collision result of the circles.</returns>
        private static CollisionResult CircleCircle(CircleCollider a, CircleCollider b)
        {
            // Perform the calculations.
            float distanceSquared = Vector2.DistanceSquared(a.Bounds.Center, b.Bounds.Center);
            float radiusSum = a.Bounds.Radius + b.Bounds.Radius;
            bool hasCollision = distanceSquared <= radiusSum * radiusSum;
            
            // Return their collision result.
            return new CollisionResult(hasCollision);
        }

        /// <summary>
        /// Determine if a circle and rectangle are colliding.
        /// </summary>
        /// <param name="a">The circle.</param>
        /// <param name="b">The rectangle.</param>
        /// <returns>Collision result of the circle and rectangle.</returns>
        private static CollisionResult CircleRectangle(CircleCollider a, RectangleCollider b)
        {
            // Perform the calculations.
            float distanceX = MathF.Max(MathF.Max(b.Bounds.Left - a.Bounds.X, 0), a.Bounds.X - b.Bounds.Right);
            float distanceY = MathF.Max(MathF.Max(b.Bounds.Top - a.Bounds.Y, 0), a.Bounds.Y - b.Bounds.Bottom);
            bool hasCollision = distanceX * distanceX + distanceY * distanceY <= a.Bounds.Radius * a.Bounds.Radius;

            // Return their collision result.
            return new CollisionResult(hasCollision);
        }

        /// <summary>
        /// Determine if a rectangle and circle are colliding.
        /// </summary>
        /// <param name="a">The rectangle.</param>
        /// <param name="b">The circle.</param>
        /// <returns>Collision result of the rectangle and circle.</returns>
        private static CollisionResult RectangleCircle(RectangleCollider a, CircleCollider b)
        {
            // Return their collision result.
            return CircleRectangle(b, a);
        }

        /// <summary>
        /// Determine if two rectangles are colliding.
        /// </summary>
        /// <param name="a">The first rectangle.</param>
        /// <param name="b">The second rectangle.</param>
        /// <returns>Collision result of the rectangles.</returns>
        private static CollisionResult RectangleRectangle(RectangleCollider a, RectangleCollider b)
        {
            // Perform the calculations.
            bool hasCollision = a.Bounds.Right >= b.Bounds.Left
                && b.Bounds.Right >= a.Bounds.Left
                && a.Bounds.Bottom >= b.Bounds.Top
                && b.Bounds.Bottom >= a.Bounds.Top;

            // Return their collision result.
            return new CollisionResult(hasCollision);
        }
    }
}
