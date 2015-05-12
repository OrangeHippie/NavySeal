
using System;
using Microsoft.Xna.Framework;
using NavySeal.Enums;

namespace NavySeal.Models
{
    public class Level
    {
        public Level()
        {
            CreateLevel();
        }

        /// <summary>
        /// Total tiles x
        /// </summary>
        public const int MAX_LEVEL_TILE_X = 16;

        /// <summary>
        /// Total tiles y
        /// </summary>
        public const int MAX_LEVEL_TILE_Y = 9;

        /// <summary>
        /// The map
        /// </summary>
        public Tile[,] Tiles = new Tile[MAX_LEVEL_TILE_X, MAX_LEVEL_TILE_Y];

        /// <summary>
        /// Set position of something, check over the map if there's something that can be colliding at in the map
        /// </summary>
        /// <param name="position"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public bool CollidingAt(Vector2 position, Vector2 size)
        {
            //
            // Size of tile
            //
            var tileSize = size;

            //
            // Create game rectangle that's about to get collisionchecked
            //
            var checkingRect = GameRectangle.CreateFromTopLeft(position, tileSize);

            //
            // Check every tile on the map, see if there's any collision
            //
            for (var x = 0; x < MAX_LEVEL_TILE_X; x++)
            {
                for (var y = 0; y < MAX_LEVEL_TILE_Y; y++)
                {
                    var rect = GameRectangle.CreateFromTopLeft(new Vector2(x, y), tileSize);

                    if (checkingRect.IsIntersecting(rect))
                        if (Tiles[x, y].CanCollide)
                            return true;
                    
                }
            }

            return false;
        }

        /// <summary>
        /// Can collide with tile
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool CanCollide(int x, int y)
        {
            return Tiles[x, y].CanCollide;
        }

        /// <summary>
        /// Get tiletype 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public TileType GetTileType(int x, int y)
        {
            return Tiles[x, y].GetTileType;
        }

        /// <summary>
        /// Create level
        /// </summary>
        public void CreateLevel()
        {
            for (int x = 0; x < MAX_LEVEL_TILE_X; x++)
            {
                for (int y = 0; y < MAX_LEVEL_TILE_Y; y++)
                {
                    Tiles[x, y] = Tile.CreateEmptyTile();
                }

                Tiles[5, 5] = Tile.CreateWallTile();
                Tiles[5, 6] = Tile.CreateWallTile();
            }
        }
    }
}
