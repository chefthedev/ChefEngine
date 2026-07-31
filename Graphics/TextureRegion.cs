using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChefEngine.Graphics
{
    /// <summary>
    /// TextureRegion class for representing a rectangular region of a texture.
    /// </summary>
    public class TextureRegion
    {
        // Overall texture being referenced by the region.
        public Texture2D Texture { get; private set; }

        // Rectangular area of the texture this region represents.
        public Rectangle SourceRectangle { get; private set; }

        // Distance from left to right of the source rectangle.
        public int Width => SourceRectangle.Width;

        // Distance from top to bottom of the source rectangle.
        public int Height => SourceRectangle.Height;

        /// <summary>
        /// Constructor for the TextureRegion class.
        /// </summary>
        /// <param name="texture">Overall source texture to set.</param>
        /// <param name="x">X coordinate of the region in the texture.</param>
        /// <param name="y">Y coordinate of the region in the texture.</param>
        /// <param name="width">Width of the texture region.</param>
        /// <param name="height">Height of the texture region.</param>
        public TextureRegion(Texture2D texture, int x, int y, int width, int height)
        {
            // Set the overall texture and the source rectangle for this region.
            Texture = texture;
            SourceRectangle = new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// Submit the texture region for drawing to the current sprite batch.
        /// </summary>
        /// <param name="spriteBatch">Sprite batch to draw the region in.</param>
        /// <param name="position">Position to draw the texture region at, based on its origin.</param>
        /// <param name="color">Color mask to apply to the drawn texture region.</param>
        /// <param name="rotation">Rotation to apply to the drawn texture region.</param>
        /// <param name="origin">Origin of drawing and texture transformations of this region.</param>
        /// <param name="scale">Scale to apply to the drawn texture region.</param>
        /// <param name="spriteEffects">Sprite effects to apply to the drawn texture region.</param>
        /// <param name="layerDepth">Layer depth to assign to the drawn texture region.</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 position, Color color, float rotation, Vector2 origin, Vector2 scale, SpriteEffects spriteEffects, float layerDepth)
        {
            // Draw the texture region using the provided parameters.
            spriteBatch.Draw(
                Texture,
                position,
                SourceRectangle,
                color,
                rotation,
                origin,
                scale,
                spriteEffects,
                layerDepth
            );
        }

        /// <summary>
        /// Overloaded Draw method for simpler calling.
        /// </summary>
        /// <param name="spriteBatch">Sprite batch to draw the region in.</param>
        /// <param name="position">Position to draw the texture region at, based on the default origin.</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            // Draw the texture region using the provided parameters and defaults.
            Draw(
                spriteBatch,
                position,
                Color.White,
                0.0f,
                Vector2.Zero,
                Vector2.One,
                SpriteEffects.None,
                0.0f
            );
        }
    }
}
