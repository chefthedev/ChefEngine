using Microsoft.Xna.Framework;

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
    }
}
