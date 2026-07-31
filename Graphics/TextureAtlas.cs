using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace ChefEngine.Graphics
{
    /// <summary>
    /// TextureAtlas class for managing a collection of texture regions within a single texture.
    /// </summary>
    public class TextureAtlas
    {
        // Texture regions stored by name.
        private Dictionary<string, TextureRegion> _textureRegions;

        // Animations stored by name.
        private Dictionary<string, Animation> _animations;

        // Overall texture that contains all the regions.
        public Texture2D Texture { get; private set; }

        /// <summary>
        /// Constructor for the TextureAtlas class.
        /// </summary>
        /// <param name="texture">Overall texture containing the regions.</param>
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
        /// <param name="name">Name of the texture region.</param>
        /// <param name="x">X coordinate of the region in the texture.</param>
        /// <param name="y">Y coordinate of the region in the texture.</param>
        /// <param name="width">Width of the texture region.</param>
        /// <param name="height">Height of the texture region.</param>
        public void AddRegion(string name, int x, int y, int width, int height)
        {
            // Create a new TextureRegion and add it to the dictionary.
            TextureRegion region = new TextureRegion(Texture, x, y, width, height);
            _textureRegions.Add(name, region);
        }

        /// <summary>
        /// Gets a texture region by name from the atlas.
        /// </summary>
        /// <param name="name">Name of the texture region.</param>
        /// <returns>Desired texture region.</returns>
        public TextureRegion GetRegion(string name)
        {
            // Try getting the texture region.
            if (!_textureRegions.TryGetValue(name, out TextureRegion? region))
            {
                // Throw an error if it wasn't found.
                throw new KeyNotFoundException($"Texture region {name} was not found.");
            }

            // Return the texture region.
            return region;
        }

        /// <summary>
        /// Removes a texture region by name from the atlas.
        /// </summary>
        /// <param name="name">Name of the texture region.</param>
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
        /// <param name="name">Name of the animation.</param>
        /// <param name="animation">Animation instance.</param>
        public void AddAnimation(string name, Animation animation)
        {
            // Add the animation to the dictionary.
            _animations.Add(name, animation);
        }

        /// <summary>
        /// Gets an animation by name from the atlas.
        /// </summary>
        /// <param name="name">Aame of the animation.</param>
        /// <returns>Desired animation.</returns>
        public Animation GetAnimation(string name)
        {
            // Try getting the animation.
            if (!_animations.TryGetValue(name, out Animation? animation))
            {
                // Throw an error if it wasn't found.
                throw new KeyNotFoundException($"Animation {name} was not found.");
            }

            // Return the animation.
            return animation;
        }

        /// <summary>
        /// Removes an animation by name from the atlas.
        /// </summary>
        /// <param name="name">Name of the animation.</param>
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
