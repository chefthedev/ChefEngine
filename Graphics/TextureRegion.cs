using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChefEngine.Graphics
{
    /// <summary>
    /// TextureRegion class for representing a rectangular region of a texture.
    /// </summary>
    public class TextureRegion
    {
        // The overall texture being referenced by the region.
        public Texture2D Texture { get; set; }

        // The rectangular area of the texture this region represents.
        public Rectangle SourceRectangle { get; set; }

        // The width of the texture region.
        public int Width => SourceRectangle.Width;

        // The height of the texture region.
        public int Height => SourceRectangle.Height;

        /// <summary>
        /// Constructor for the TextureRegion class.
        /// </summary>
        /// <param name="texture">The overall source texture to set.</param>
        /// <param name="x">The x coordinate of the region in the texture.</param>
        /// <param name="y">The y coordinate of the region in the texture.</param>
        /// <param name="width">The width of the texture region.</param>
        /// <param name="height">The height of the texture region.</param>
        public TextureRegion(Texture2D texture, int x, int y, int width, int height)
        {
            // Set the overall texture and the source rectangle for this region.
            Texture = texture;
            SourceRectangle = new Rectangle(x, y, width, height);
        }

        /// <summary>
        /// Submit the texture region for drawing to the current sprite batch.
        /// </summary>
        /// <param name="spriteBatch">The sprite batch to draw the region in.</param>
        /// <param name="position">The position to draw the texture region at, based on it's origin.</param>
        /// <param name="color">The color mask to apply to the drawn texture region.</param>
        /// <param name="rotation">The rotation to apply to the drawn texture region.</param>
        /// <param name="origin">The origin of drawing and texture transformations of this region.</param>
        /// <param name="scale">The scale to apply to the drawn texture region.</param>
        /// <param name="spriteEffects">The sprite effects to apply to the drawn texture region.</param>
        /// <param name="layerDepth">The layer depth to assign to the drawn texture region.</param>
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
    }
}
