using Microsoft.Xna.Framework;
using System;

namespace ChefEngine.Geometry
{
    /// <summary>
    /// RectangleF struct for modeling rectangles in floating point precision.
    /// </summary>
    public struct RectangleF
    {
        // The x coordinate of the top-left corner.
        public float X { get; set; }

        // The y coordinate of the top-left corner.
        public float Y;

        // The width of the rectangle.
        public float Width;

        // The height of the rectangle.
        public float Height;

        // The x coordinate of the left side.
        public float Left => X;

        // The x coordinate of the right side.
        public float Right => X + Width;

        // The y coordinate of the top side.
        public float Top => Y;

        // The y coordinate of the bottom side.
        public float Bottom => Y + Height;

        // The center of the rectangle.
        public Vector2 Center => new Vector2((Left + Right) * 0.5f, (Top + Bottom) * 0.5f);

        // The position of the top-left corner.
        public Vector2 Position => new Vector2(X, Y);

        // The size of the rectangle.
        public Vector2 Size => new Vector2(Width, Height);

        /// <summary>
        /// Constructor for the RectangleF struct.
        /// </summary>
        /// <param name="x">The x coordinate of the top-left corner.</param>
        /// <param name="y">The y coordinate of the top-left corner.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
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
        /// <returns>The closest point on the rectangle to point.</returns>
        public Vector2 ClosestPoint(Vector2 point)
        {
            // Calculate the closest point.
            return new Vector2(Math.Clamp(point.X, Left, Right), Math.Clamp(point.Y, Top, Bottom));
        }
    }
}
