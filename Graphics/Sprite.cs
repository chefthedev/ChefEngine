using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChefEngine.Graphics
{
    /// <summary>
    /// Sprite class that represents a visual object created from a texture region.
    /// </summary>
    public class Sprite
    {
        // Overall texture region being referenced by the sprite.
        public TextureRegion TextureRegion { get; protected set; }

        // Masking of color, with a default of white (transparent).
        public Color Color { get; set; } = Color.White;

        // Rotation, in radians.
        public float Rotation { get; set; } = 0.0f;

        // X,Y position of the origin, based on the texture region.
        public Vector2 Origin { get; set; } = Vector2.Zero;

        // Scaling factor.
        public Vector2 Scale { get; set; } = Vector2.One;

        // Sprite visual options.
        public SpriteEffects SpriteEffects { get; set; } = SpriteEffects.None;

        // Which layer to draw the sprite on.
        public float LayerDepth { get; set; } = 0.0f;

        // Distance from left to right, including scaling.
        public float Width => TextureRegion.Width * Scale.X;

        // Distance from top to bottom, including scaling.
        public float Height => TextureRegion.Height * Scale.Y;

        /// <summary>
        /// Constructor for the Sprite class.
        /// </summary>
        /// <param name="textureRegion">Overall source texture region to set.</param>
        public Sprite(TextureRegion textureRegion)
        {
            // Set the overall texture region for this sprite.
            TextureRegion = textureRegion;
        }

        /// <summary>
        /// Sets the origin to the center of the texture region.
        /// </summary>
        public void SetCenterOrigin()
        {
            // Center the origin.
            Origin = new Vector2(TextureRegion.Width * 0.5f, TextureRegion.Height * 0.5f);
        }

        /// <summary>
        /// Sets the origin to the top left of the texture region.
        /// </summary>
        public void SetTopLeftOrigin()
        {
            // Top left the origin.
            Origin = Vector2.Zero;
        }

        /// <summary>
        /// Sets the origin to a custom point of the texture region.
        /// </summary>
        public void SetCustomOrigin(float x, float y)
        {
            // Customize the origin.
            Origin = new Vector2(x, y);
        }

        /// <summary>
        /// Sets the origin to a custom point of the texture region.
        /// </summary>
        public void SetCustomOrigin(Vector2 origin)
        {
            // Customize the origin.
            Origin = origin;
        }

        /// <summary>
        /// Submit the sprite for drawing to the current sprite batch.
        /// </summary>
        /// <param name="spriteBatch">Sprite batch to draw the sprite in.</param>
        /// <param name="position">Position to draw the sprite at, based on it's origin.</param>
        public void Draw(SpriteBatch spriteBatch, Vector2 position)
        {
            // Draw the sprite using the provided parameters and the sprite's properties.
            TextureRegion.Draw(spriteBatch, position, Color, Rotation, Origin, Scale, SpriteEffects, LayerDepth);
        }
    }
}
