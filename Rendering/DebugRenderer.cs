using ChefEngine.Geometry;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace ChefEngine.Rendering
{
    /// <summary>
    /// DebugRenderer class for drawing debug information to the screen.
    /// </summary>
    public static class DebugRenderer
    {
        // The pixel texture.
        private static Texture2D? _pixel;

        /// <summary>
        /// Initializes the static DebugRenderer class.
        /// </summary>
        /// <param name="graphicsDevice">The graphics device instance.</param>
        public static void Initialize(GraphicsDevice graphicsDevice)
        {
            // If the pixel texture was initialized.
            if (_pixel != null)
            {
                // Skip initialization.
                return;
            }

            // Initialize the pixel texture.
            _pixel = new Texture2D(graphicsDevice, 1, 1);
            _pixel.SetData([Color.White]);
        }

        /// <summary>
        /// Draws the outline of a Rectangle object.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to draw in.</param>
        /// <param name="rectangle">The Rectangle to draw the outline of.</param>
        /// <param name="color">The color of outline to use.</param>
        /// <param name="thickness">The thickness of outline to use.</param>
        public static void DrawRectangleOutline(SpriteBatch spriteBatch, Rectangle rectangle, Color color, int thickness = 1)
        {
            // If the pixel texture is not initialized.
            if (_pixel == null)
            {
                // Throw an exception.
                throw new InvalidOperationException("Debug renderer has not been initialized.");
            }

            // Draw the top edge.
            spriteBatch.Draw(
                _pixel,
                new Rectangle(rectangle.Left, rectangle.Top, rectangle.Width, thickness),
                color
            );

            // Draw the bottom edge.
            spriteBatch.Draw(
                _pixel,
                new Rectangle(rectangle.Left, rectangle.Bottom - thickness, rectangle.Width, thickness),
                color
            );

            // Draw the left edge.
            spriteBatch.Draw(
                _pixel,
                new Rectangle(rectangle.Left, rectangle.Top, thickness, rectangle.Height),
                color
            );

            // Draw the right edge.
            spriteBatch.Draw(
                _pixel,
                new Rectangle(rectangle.Right - thickness, rectangle.Top, thickness, rectangle.Height),
                color
            );
        }

        /// <summary>
        /// Draws the outline of a RectangleF object.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to draw in.</param>
        /// <param name="rectangle">The RectangleF to draw the outline of.</param>
        /// <param name="color">The color of outline to use.</param>
        /// <param name="thickness">The thickness of outline to use.</param>
        public static void DrawRectangleFOutline(SpriteBatch spriteBatch, RectangleF rectangle, Color color, int thickness = 1)
        {
            // If the pixel texture is not initialized.
            if (_pixel == null)
            {
                // Throw an exception.
                throw new InvalidOperationException("Debug renderer has not been initialized.");
            }

            // Draw the top edge.
            spriteBatch.Draw(
                _pixel,
                new Vector2(rectangle.Left, rectangle.Top),
                null,
                color,
                0.0f,
                Vector2.Zero,
                new Vector2(rectangle.Width, thickness),
                SpriteEffects.None,
                0.0f
            );

            // Draw the bottom edge.
            spriteBatch.Draw(
                _pixel,
                new Vector2(rectangle.Left, rectangle.Bottom - thickness),
                null,
                color,
                0.0f,
                Vector2.Zero,
                new Vector2(rectangle.Width, thickness),
                SpriteEffects.None,
                0.0f
            );

            // Draw the left edge.
            spriteBatch.Draw(
                _pixel,
                new Vector2(rectangle.Left, rectangle.Top),
                null,
                color,
                0.0f,
                Vector2.Zero,
                new Vector2(thickness, rectangle.Height),
                SpriteEffects.None,
                0.0f
            );

            // Draw the right edge.
            spriteBatch.Draw(
                _pixel,
                new Vector2(rectangle.Right - thickness, rectangle.Top),
                null,
                color,
                0.0f,
                Vector2.Zero,
                new Vector2(thickness, rectangle.Height),
                SpriteEffects.None,
                0.0f
            );
        }
    }
}
