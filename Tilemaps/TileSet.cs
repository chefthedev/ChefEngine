using ChefEngine.Graphics;
using System;
using System.Collections.Generic;

namespace ChefEngine.Tilemaps
{
    /// <summary>
    /// TileSet class for modeling a collection of tile definitions.
    /// </summary>
    public class TileSet
    {
        // Size of each tile in the tile set.
        public int TileSize { get; }

        // List of tile definitions in the tile set.

        private readonly List<TileDefinition> _definitions = [];

        /// <summary>
        /// Constructor for the TileSet class.
        /// </summary>
        /// <param name="tileSize">Size of each tile in the tile set.</param>
        public TileSet(int tileSize) 
        {
            // Set the tile size property.
            TileSize = tileSize;
        }

        /// <summary>
        /// Adds a new tile definition to the tile set.
        /// </summary>
        /// <param name="id">ID of the tile definition.</param>
        /// <param name="name">Name of the tile definition.</param>
        /// <param name="textureRegion">Texture region for the tile definition.</param>
        public void AddDefinition(int id, string name, TextureRegion? textureRegion)
        {
            // If the id is not sequential.
            if (id != _definitions.Count)
            {
                // Throw an exception.
                throw new ArgumentException($"Tile definition ID must be sequential. Expected {_definitions.Count}, got {id}.");
            }

            // Add the tile definition to the list.
            TileDefinition definition = new TileDefinition(id, name, textureRegion);
            _definitions.Add(definition);
        }

        /// <summary>
        /// Gets a tile definition by its ID.
        /// </summary>
        /// <param name="tileId">ID of the tile definition to retrieve.</param>
        /// <returns>Tile definition with the specified ID.</returns>
        public TileDefinition GetDefinition(int tileId)
        {
            // If the tile id is out of bounds.
            if (tileId < 0 || tileId >= _definitions.Count)
            {
                // Throw an exception.
                throw new ArgumentOutOfRangeException(
                    nameof(tileId),
                    $"Id ({tileId}) does not exist in the tile set."
                );
            }

            // Return the matching tile definition.
            return _definitions[tileId];
        }
    }
}
