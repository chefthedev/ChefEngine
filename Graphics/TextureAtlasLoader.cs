using ChefEngine.Core;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ChefEngine.Graphics
{
    /// <summary>
    /// TextureAtlasLoader static class for loading in texture atlas files.
    /// </summary>
    public static class TextureAtlasLoader
    {
        /// <summary>
        /// Static method for loading a texture atlas in from a json file.
        /// </summary>
        /// <param name="fileName">The file name of the json file.</param>
        /// <returns>TextureAtlas object loaded from the provided file.</returns>
        public static TextureAtlas Load(string fileName)
        {
            // Get the file path of the json file.
            string filePath = Path.Combine(Engine.Instance.Content.RootDirectory, fileName);

            // Read and deserialize the json into data classes.
            string json = File.ReadAllText(filePath);
            TextureAtlasData data = JsonSerializer.Deserialize<TextureAtlasData>(
                json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
            );

            // Load the referenced texture using the content manager.
            Texture2D texture = Engine.Instance.Content.Load<Texture2D>(data.Texture);

            // Create the texture atlas instance.
            TextureAtlas atlas = new TextureAtlas(texture);

            // For each texture region in the atlas file.
            foreach (TextureAtlasRegionData region in data.Regions)
            {
                // Add the texture region.
                atlas.AddRegion(region.Name, region.X, region.Y, region.Width, region.Height);
            }

            // For each animation in the atlas file.
            foreach (TextureAtlasAnimationData animation in data.Animations)
            {
                // Initialize the list of animation frames.
                List<TextureRegion> animationFrames = new List<TextureRegion>();
                
                // For each animation frame.
                foreach (string frame in  animation.Frames)
                {
                    // Add the texture region.
                    animationFrames.Add(atlas.GetRegion(frame));
                }

                // Add the animation.
                atlas.AddAnimation(animation.Name, new Animation(animationFrames, TimeSpan.FromMilliseconds(animation.Delay)));
            }

            // Return the atlas.
            return atlas;
        }
    }

    /// <summary>
    /// TextureAtlasData internal class for modeling top level object in texture atlas json file.
    /// </summary>
    internal class TextureAtlasData
    {
        public string Texture { get; set; }
        public List<TextureAtlasRegionData> Regions { get; set; }
        public List<TextureAtlasAnimationData> Animations { get; set; }
    }

    /// <summary>
    /// TextureAtlasRegionData internal class for modeling regions array items in texture atlas json file.
    /// </summary>
    internal class TextureAtlasRegionData
    {
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    /// <summary>
    /// TextureAtlasAnimationdata internal class for modeling animations array items in texture atlas json file.
    /// </summary>
    internal class TextureAtlasAnimationData
    {
        public string Name { get; set; }
        public float Delay { get; set; }
        public List<string> Frames { get; set; }
    }
}
