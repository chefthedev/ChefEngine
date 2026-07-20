using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace ChefEngine.Graphics
{
    /// <summary>
    /// TextureAtlas class for managing a collection of texture regions within a single texture.
    /// </summary>
    public class TextureAtlas
    {
        // Dictionary to store the texture regions by name.
        private Dictionary<string, TextureRegion> _textureRegions;

        // Dictionary to store animations by name.
        private Dictionary<string, Animation> _animations;

        // The overall texture that contains all the regions.
        public Texture2D Texture { get; private set; }

        /// <summary>
        /// Constructor for the TextureAtlas class.
        /// </summary>
        /// <param name="texture">The overall texture containing the regions.</param>
        public TextureAtlas(Texture2D texture)
        {
            // Set the overall texture and initialize the texture regions and animations dictionaries.
            Texture = texture;
            _textureRegions = new Dictionary<string, TextureRegion>();
            _animations = new Dictionary<string, Animation>();
        }

        /// <summary>
        /// Adds a new texture region to the atlas.
        /// </summary>
        /// <param name="name">The name of the texture region.</param>
        /// <param name="x">The x coordinate of the region in the texture.</param>
        /// <param name="y">The y coordinate of the region in the texture.</param>
        /// <param name="width">The width of the texture region.</param>
        /// <param name="height">The height of the texture region.</param>
        public void AddRegion(string name, int x, int y, int width, int height)
        {
            // Create a new TextureRegion and add it to the dictionary.
            TextureRegion region = new TextureRegion(Texture, x, y, width, height);
            _textureRegions.Add(name, region);
        }

        /// <summary>
        /// Gets a texture region by name from the atlas.
        /// </summary>
        /// <param name="name">The name of the texture region.</param>
        /// <returns>The desired texture region, or null if not found.</returns>
        public TextureRegion GetRegion(string name)
        {
            // Return the texture region if it exists, otherwise return null.
            return _textureRegions.GetValueOrDefault(name);
        }

        /// <summary>
        /// Removes a texture region by name from the atlas.
        /// </summary>
        /// <param name="name">The name of the texture region.</param>
        public void RemoveRegion(string name)
        {
            // Remove the texture region from the dictionary if it exists.
            _textureRegions.Remove(name);
        }

        /// <summary>
        /// Clears all texture regions from the atlas.
        /// </summary>
        public void ClearRegions()
        {
            // Clear the dictionary of texture regions.
            _textureRegions.Clear();
        }

        /// <summary>
        /// Adds a new animation to the atlas.
        /// </summary>
        /// <param name="name">The name of the animation.</param>
        /// <param name="animation">The animation instance.</param>
        public void AddAnimation(string name, Animation animation)
        {
            // Add the animation to the dictionary.
            _animations.Add(name, animation);
        }

        /// <summary>
        /// Gets an animation by name from the atlas.
        /// </summary>
        /// <param name="name">The name of the animation.</param>
        /// <returns>The desired animation, or null if not found.</returns>
        public Animation GetAnimation(string name)
        {
            // Return the animation if it exists, otherwise return null.
            return _animations.GetValueOrDefault(name);
        }

        /// <summary>
        /// Removes an animation by name from the atlas.
        /// </summary>
        /// <param name="name">The name of the animation.</param>
        public void RemoveAnimation(string name)
        {
            // Remove the animation from the dictionary if it exists.
            _animations.Remove(name);
        }

        /// <summary>
        /// Clears all animations from the atlas.
        /// </summary>
        public void ClearAnimations()
        {
            // Clear the dictionary of animations.
            _animations.Clear();
        }
    }
}
