using ChefEngine.Graphics;

namespace ChefEngine.Tilemaps
{
    /// <summary>
    /// TileDefinition class for modeling the properties of a tile in a tile set.
    /// </summary>
    public class TileDefinition
    {
        // Unique ID of the tile definition.
        public int Id { get; }

        // Name of the tile definition.
        public string Name { get; }

        // Optional texture region representing the graphical tile.
        public TextureRegion? TextureRegion { get; }

        /// <summary>
        /// Constructor for the TileDefinition class.
        /// </summary>
        /// <param name="id">Unique ID of the tile definition.</param>
        /// <param name="name">Name of the tile definition.</param>
        /// <param name="textureRegion">Optional texture region representing the graphical tile.</param>
        public TileDefinition(int id, string name, TextureRegion? textureRegion)
        {
            // Set the properties.
            Id = id;
            Name = name;
            TextureRegion = textureRegion;
        }
    }
}
