using Microsoft.Xna.Framework.Graphics;
using System;

namespace ChefEngine.Tilemaps
{
    /// <summary>
    /// TileMap class for modeling a group of tiles in a 2D grid.
    /// </summary>
    public class TileMap
    {
        // Tiles of the map stored in a 1D array for efficiency.
        private readonly Tile[] _tiles;

        // How many tiles wide the map is.
        public int Width { get; }

        // How many tiles tall the map is.
        public int Height { get; }

        /// <summary>
        /// Constructor for the TileMap class.
        /// </summary>
        /// <param name="width">How many tiles wide the map will be.</param>
        /// <param name="height">How many tiles tall the map will be.</param>
        public TileMap(int width, int height)
        {
            // Set the width and height properties.
            Width = width;
            Height = height;

            // Initialize the tiles array with the proper size.
            _tiles = new Tile[width * height];
        }

        /// <summary>
        /// Gets the tile at the specified coordinates.
        /// </summary>
        /// <param name="x">X coordinate of the tile to get.</param>
        /// <param name="y">Y coordinate of the tile to get.</param>
        /// <returns>Tile at the specified coordinates.</returns>
        public Tile GetTile(int x, int y)
        {
            // Get the tile.
            return _tiles[GetIndex(x, y)];
        }

        /// <summary>
        /// Sets the tile at the specified coordinates.
        /// </summary>
        /// <param name="x">X coordinate of the tile to set.</param>
        /// <param name="y">Y coordinate of the tile to set.</param>
        /// <param name="tile">Tile to set.</param>
        public void SetTile(int x, int y, Tile tile)
        {
            // Set the tile.
            _tiles[GetIndex(x, y)] = tile;
        }

        /// <summary>
        /// Draws the tile map using the specified SpriteBatch and TileSet.
        /// </summary>
        /// <param name="spriteBatch">Sprite batch to draw the tile map with.</param>
        /// <param name="tileSet">Tile set to use for referencing each tile.</param>
        public void Draw(SpriteBatch spriteBatch, TileSet tileSet)
        {
            // TODO: Implement drawing logic for tile map.
        }

        /// <summary>
        /// Gets the index in the 1D array for the specified x-y coordinates.
        /// </summary>
        /// <param name="x">X coordinate of the location.</param>
        /// <param name="y">Y coordinate of the location.</param>
        /// <returns>Index in the 1D array for the location.</returns>
        private int GetIndex(int x, int y)
        {
            // If the x-y coordinates are out of bounds.
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                // Throw an exception.
                throw new ArgumentOutOfRangeException(
                    $"Coordinates ({x}, {y}) are out of the tile map bounds."
                );
            }

            // Return the 1D array index.
            return y * Width + x;
        }
    }
}
