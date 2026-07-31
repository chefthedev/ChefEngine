using System;
using Microsoft.Xna.Framework;

namespace ChefEngine.Geometry
{
    /// <summary>
    /// CircleF struct for modeling circles in floating point precision.
    /// </summary>
    public struct CircleF
    {
        // X coordinate of the center.
        public float X;

        // Y coordinate of the center.
        public float Y;

        // Distance from the center to the edge.
        public float Radius;

        // Distance across the width.
        public readonly float Diameter => Radius * 2;

        // Distance around the edge.
        public readonly float Circumference => 2 * MathF.PI * Radius;

        // X coordinate of the left-most point.
        public readonly float Left => X - Radius;

        // X coordinate of the right-most point.
        public readonly float Right => X + Radius;

        // Y coordinate of the top-most point.
        public readonly float Top => Y - Radius;

        // Y coordinate of the bottom-most point.
        public readonly float Bottom => Y + Radius;

        // X,Y position of the center.
        public readonly Vector2 Center => new(X, Y);

        /// <summary>
        /// Constructor for the CircleF struct.
        /// </summary>
        /// <param name="x">X coordinate of the center.</param>
        /// <param name="y">Y coordinate of the center.</param>
        /// <param name="radius">Radius of the circle.</param>
        public CircleF(float x, float y, float radius)
        {
            // Set the properties of the circle.
            X = x;
            Y = y;
            Radius = radius;
        }
    }
}
