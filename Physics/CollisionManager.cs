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
        private delegate bool CollisionTest(Collider a, Collider b);

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
                    CircleCircle
                },
                // Circle to Rectangle.
                {
                    (typeof(CircleCollider), typeof(RectangleCollider)),
                    CircleRectangle
                },
                // Rectangle to Circle.
                {
                    (typeof(RectangleCollider), typeof(CircleCollider)),
                    RectangleCircle
                },
                // Rectangle to Rectangle.
                {
                    (typeof(RectangleCollider), typeof(RectangleCollider)),
                    RectangleRectangle
                },
            };
        }

        /// <summary>
        /// Checks the collision status between two colliders.
        /// </summary>
        /// <param name="a">The first collider.</param>
        /// <param name="b">The second collider.</param>
        /// <returns>Collision status of the colliders.</returns>
        public static bool CheckCollision(Collider a, Collider b)
        {
            // If either of the colliders are disabled.
            if (!a.IsEnabled || !b.IsEnabled)
            {
                // Return a false collision status.
                return false;
            }

            // If there is a collision test for the type bindings.
            if (_collisionTests.TryGetValue((a.GetType(), b.GetType()), out CollisionTest? test))
            {
                // Call the collision test.
                return test(a, b);
            }

            // Return a default of false otherwise.
            return false;
        }

        /// <summary>
        /// Determine if two circles are colliding.
        /// </summary>
        /// <param name="a">The first circle.</param>
        /// <param name="b">The second circle.</param>
        /// <returns>Collision status of the circles.</returns>
        private static bool CircleCircle(Collider a, Collider b)
        {
            // Cast the circles to the correct type.
            CircleCollider circleColliderA = (CircleCollider)a;
            CircleCollider circleColliderB = (CircleCollider)b;

            // Perform the calculations.
            float distanceSquared = Vector2.DistanceSquared(circleColliderA.Bounds.Center, circleColliderB.Bounds.Center);
            float radiusSum = circleColliderA.Bounds.Radius + circleColliderB.Bounds.Radius;

            // Return their collision status.
            return distanceSquared <= radiusSum * radiusSum;
        }

        /// <summary>
        /// Determine if a circle and rectangle are colliding.
        /// </summary>
        /// <param name="a">The circle.</param>
        /// <param name="b">The rectangle.</param>
        /// <returns>Collision status of the circle and rectangle.</returns>
        private static bool CircleRectangle(Collider a, Collider b)
        {
            // Cast the circle and rectangle to the correct type.
            CircleCollider circleColliderA = (CircleCollider)a;
            RectangleCollider rectangleColliderB = (RectangleCollider)b;

            // Perform the calculations.
            float distanceX = MathF.Max(MathF.Max(rectangleColliderB.Bounds.Left - circleColliderA.Bounds.X, 0), circleColliderA.Bounds.X - rectangleColliderB.Bounds.Right);
            float distanceY = MathF.Max(MathF.Max(rectangleColliderB.Bounds.Top - circleColliderA.Bounds.Y, 0), circleColliderA.Bounds.Y - rectangleColliderB.Bounds.Bottom);

            // Return their collision status.
            return distanceX * distanceX + distanceY * distanceY <= circleColliderA.Bounds.Radius * circleColliderA.Bounds.Radius;
        }

        /// <summary>
        /// Determine if a rectangle and circle are colliding.
        /// </summary>
        /// <param name="a">The rectangle.</param>
        /// <param name="b">The circle.</param>
        /// <returns>Collision status of the rectangle and circle.</returns>
        private static bool RectangleCircle(Collider a, Collider b)
        {
            // Return their collision status.
            return CircleRectangle(b, a);
        }

        /// <summary>
        /// Determine if two rectangles are colliding.
        /// </summary>
        /// <param name="a">The first rectangle.</param>
        /// <param name="b">The second rectangle.</param>
        /// <returns>Collision status of the rectangles.</returns>
        private static bool RectangleRectangle(Collider a, Collider b)
        {
            // Cast the rectangles to the correct type.
            RectangleCollider rectangleColliderA = (RectangleCollider)a;
            RectangleCollider rectangleColliderB = (RectangleCollider)b;

            // Return their collision status.
            return rectangleColliderA.Bounds.Right >= rectangleColliderB.Bounds.Left
                && rectangleColliderB.Bounds.Right >= rectangleColliderA.Bounds.Left
                && rectangleColliderA.Bounds.Bottom >= rectangleColliderB.Bounds.Top
                && rectangleColliderB.Bounds.Bottom >= rectangleColliderA.Bounds.Top;
        }
    }
}
