using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;

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
        /// Empty constructor for the TextureAtlas class.
        /// </summary>
        public TextureAtlas()
        {
            // Initialize the texture regions and animations dictionaries.
            _textureRegions = new Dictionary<string, TextureRegion>();
            _animations = new Dictionary<string, Animation>();
        }

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

        /// <summary>
        /// Static method for creating a texture atlas from an xml config file.
        /// </summary>
        /// <param name="content">The content manager instance for loading assets.</param>
        /// <param name="fileName">The file name of the xml config file.</param>
        /// <returns>TextureAtlas object created from the provided file.</returns>
        public static TextureAtlas CreateFromFile(ContentManager content, string fileName)
        {
            // Create a new texture atlas instance.
            TextureAtlas atlas = new TextureAtlas();

            // Get the file path of the xml config file.
            string filePath = Path.Combine(content.RootDirectory, fileName);

            using (Stream stream = TitleContainer.OpenStream(filePath))
            {
                using (XmlReader reader = XmlReader.Create(stream))
                {
                    // Load and parse the root from the xml config file.
                    XDocument doc = XDocument.Load(reader);
                    XElement root = doc.Root;

                    // Get the texture path from the <Texture> element
                    string texturePath = root.Element("Texture").Value;

                    // Load the texture using the content manager and assign it to the atlas.
                    atlas.Texture = content.Load<Texture2D>(texturePath);

                    // Get the <Regions> element and its child <Region> elements
                    IEnumerable<XElement> regions = root.Element("Regions")?.Elements("Region");

                    // If the regions element is not null
                    if (regions != null)
                    {
                        // For each region element
                        foreach (XElement region in regions)
                        {
                            // Get the attributes of the region element and parse them into variables.
                            string name = region.Attribute("name")?.Value;
                            int x = int.Parse(region.Attribute("x")?.Value ?? "0");
                            int y = int.Parse(region.Attribute("y")?.Value ?? "0");
                            int width = int.Parse(region.Attribute("width")?.Value ?? "0");
                            int height = int.Parse(region.Attribute("height")?.Value ?? "0");

                            // If the region has a valid name.
                            if (!string.IsNullOrEmpty(name))
                            {
                                // Add the region to the atlas using the parsed values.
                                atlas.AddRegion(name, x, y, width, height);
                            }
                        }
                    }

                    // Get the <Animations> element and its child <Animation> elements
                    IEnumerable<XElement> animations = root.Element("Animations")?.Elements("Animation");

                    // If the animations element is not null
                    if (animations != null)
                    {
                        // For each animation element
                        foreach (XElement animation in animations)
                        {
                            // Get the name and delay attributes and parse them into variables.
                            string name = animation.Attribute("name")?.Value;
                            float delayMs = float.Parse(animation.Attribute("delay")?.Value ?? "0");
                            TimeSpan delayMsTimespan = TimeSpan.FromMilliseconds(delayMs);

                            // Initialize the frame region list
                            List<TextureRegion> frameRegionList = new List<TextureRegion>();

                            // Get the <Animation> element's child <Frame> elements
                            IEnumerable<XElement> frames = animation.Elements("Frame");

                            // If the frames element list is not null
                            if (frames != null)
                            {
                                // For each frame element
                                foreach (XElement frame in frames)
                                {
                                    // Get the region attribute and parse it into a variable.
                                    string frameRegion = frame.Attribute("region")?.Value;

                                    // If the frame has a valid region.
                                    if (!string.IsNullOrEmpty(frameRegion))
                                    {
                                        // Create the texture region
                                        TextureRegion textureRegion = atlas.GetRegion(frameRegion);

                                        // Add the texture region to the frame region list.
                                        frameRegionList.Add(textureRegion);
                                    }
                                }
                            }

                            // If the animation has a valid name.
                            if (!string.IsNullOrEmpty(name))
                            {
                                // Create the animation
                                Animation animationToAdd = new Animation(frameRegionList, delayMsTimespan);

                                // Add the animation to the atlas using the parsed values.
                                atlas.AddAnimation(name, animationToAdd);
                            }
                        }
                    }
                }
            }

            // Return the atlas.
            return atlas;
        }

        /// <summary>
        /// Creates a sprite from a region in the texture atlas.
        /// </summary>
        /// <param name="textureRegionName">The name of the texture region to create the sprite from.</param>
        /// <returns>Sprite using the texture region as it's source.</returns>
        public Sprite CreateSprite(string textureRegionName)
        {
            // Get the texture region from the atlas.
            TextureRegion region = GetRegion(textureRegionName);

            // Create and return the sprite.
            return new Sprite(region);
        }

        /// <summary>
        /// Creates an animated sprite from an animation in the texture atlas.
        /// </summary>
        /// <param name="animationName">The name of the animation to create the sprite from.</param>
        /// <returns>Animated sprite using the animation as it's source.</returns>
        public AnimatedSprite CreateAnimatedSprite(string animationName)
        {
            // Get the animation from the atlas.
            Animation animation = GetAnimation(animationName);

            // Create and return the animated sprite.
            return new AnimatedSprite(animation);
        }
    }
}
