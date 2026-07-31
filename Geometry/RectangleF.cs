using Microsoft.Xna.Framework;
using System;

namespace ChefEngine.Geometry
{
    /// <summary>
    /// RectangleF struct for modeling rectangles in floating point precision.
    /// </summary>
    public struct RectangleF
    {
        // X coordinate of the top-left corner.
        public float X { get; set; }

        // Y coordinate of the top-left corner.
        public float Y;

        // Distance from left to right.
        public float Width;

        // Distance from top to bottom.
        public float Height;

        // X coordinate of the left-most point.
        public float Left => X;

        // X coordinate of the right-most point.
        public float Right => X + Width;

        // Y coordinate of the top-most point.
        public float Top => Y;

        // Y coordinate of the bottom-most point.
        public float Bottom => Y + Height;

        // X,Y position of the center.
        public Vector2 Center => new Vector2((Left + Right) * 0.5f, (Top + Bottom) * 0.5f);

        // X,Y position of the top-left corner.
        public Vector2 Position => new Vector2(X, Y);

        // X,Y size of the rectangle.
        public Vector2 Size => new Vector2(Width, Height);

        /// <summary>
        /// Constructor for the RectangleF struct.
        /// </summary>
        /// <param name="x">X coordinate of the top-left corner.</param>
        /// <param name="y">Y coordinate of the top-left corner.</param>
        /// <param name="width">Width of the rectangle.</param>
        /// <param name="height">Height of the rectangle.</param>
        public RectangleF(float x, float y, float width, float height)
        {
            // Set the properties of the rectangle.
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Finds the closest point on the rectangle to the provided point in space.
        /// </summary>
        /// <param name="point">The target point in space.</param>
        /// <returns>Closest point on the rectangle to point.</returns>
        public Vector2 ClosestPoint(Vector2 point)
        {
            // Calculate the closest point.
            return new Vector2(Math.Clamp(point.X, Left, Right), Math.Clamp(point.Y, Top, Bottom));
        }
    }
}
