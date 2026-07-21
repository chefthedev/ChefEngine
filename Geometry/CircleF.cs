using System;
using Microsoft.Xna.Framework;

namespace ChefEngine.Geometry
{
    /// <summary>
    /// CircleF struct for modeling circles in floating point precision.
    /// </summary>
    public struct CircleF
    {
        // The x coordinate of the center.
        public float X;

        // The y coordinate of the center.
        public float Y;

        // The radius of the circle.
        public float Radius;

        // The diameter of the circle.
        public float Diameter => Radius * 2;

        // The circumference of the circle.
        public float Circumference => 2 * MathF.PI * Radius;

        // The x coordinate of the left-most point.
        public float Left => X - Radius;

        // The x coordinate of the right-most point.
        public float Right => X + Radius;

        // The y coordinate of the top-most point.
        public float Top => Y - Radius;

        // The y coordinate of the bottom-most point.
        public float Bottom => Y + Radius;

        // The center of the circle.
        public Vector2 Center => new Vector2(X, Y);

        /// <summary>
        /// Constructor for the CircleF struct.
        /// </summary>
        /// <param name="x">The x coordinate of the center.</param>
        /// <param name="y">The y coordinate of the center.</param>
        /// <param name="radius">The radius of the circle.</param>
        public CircleF(float x, float y, float radius)
        {
            // Set the properties of the circle.
            X = x;
            Y = y;
            Radius = radius;
        }
    }
}
