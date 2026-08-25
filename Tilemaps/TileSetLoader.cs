using ChefEngine.Core;
using ChefEngine.Graphics;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace ChefEngine.Tilemaps
{
    /// <summary>
    /// TileSetLoader static class for loading in tile set files.
    /// </summary>
    public static class TileSetLoader
    {
        // Re-usable json serializer options.
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        /// <summary>
        /// Static method for loading a tile set in from a json file.
        /// </summary>
        /// <param name="fileName">File name of the json file.</param>
        /// <param name="atlas">Texture atlas to pull regions from.</param>
        /// <returns>TileSet object loaded from the provided file.</returns>
        public static TileSet Load(string fileName, TextureAtlas atlas)
        {
            // Get the file path of the json file.
            string filePath = Path.Combine(Engine.Instance.Content.RootDirectory, fileName);

            // Read and deserialize the json into data classes.
            string json = File.ReadAllText(filePath);
            TileSetData data = JsonSerializer.Deserialize<TileSetData>(
                json,
                _jsonOptions
            )
            ?? throw new InvalidDataException($"Failed to deserialize tile set {fileName}.");

            // Load the tile size.
            int tileSize = data.TileSize;

            // Create the tile set instance.
            TileSet tileSet = new TileSet(tileSize);

            // For each tile definition in the tile set file.
            foreach (TileDefinitionData definition in data.Definitions)
            {
                // Initialize the optional texture region.
                TextureRegion? textureRegion = null;

                // If the tile definition has a texture region.
                if (definition.TextureRegion != null)
                {
                    // Get the texture region.
                    textureRegion = atlas.GetRegion(definition.TextureRegion);
                }

                // Add the tile definition.
                tileSet.AddDefinition(definition.Id, definition.Name, textureRegion);
            }

            // Return the tile set.
            return tileSet;
        }
    }

    /// <summary>
    /// TileSetData internal class for modeling top level object in tile set json file.
    /// </summary>
    internal class TileSetData
    {
        public required int TileSize { get; set; }
        public required List<TileDefinitionData> Definitions { get; set; }
    }

    /// <summary>
    /// TileDefinitionData internal class for modeling definitions array items in tile set json file.
    /// </summary>
    internal class TileDefinitionData
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public string? TextureRegion { get; set; }
    }
}
