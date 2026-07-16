using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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

        // The overall texture that contains all the regions.
        public Texture2D Texture { get; private set; }

        /// <summary>
        /// Empty constructor for the TextureAtlas class.
        /// </summary>
        public TextureAtlas()
        {
            // Initialize the texture regions dictionary.
            _textureRegions = new Dictionary<string, TextureRegion>();
        }

        /// <summary>
        /// Constructor for the TextureAtlas class.
        /// </summary>
        /// <param name="texture">The overall texture containing the regions.</param>
        public TextureAtlas(Texture2D texture)
        {
            // Set the overall texture and initialize the texture regions dictionary.
            Texture = texture;
            _textureRegions = new Dictionary<string, TextureRegion>();
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
                }
            }

            // Return the atlas.
            return atlas;
        }
    }
}
