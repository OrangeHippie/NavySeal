using NavySeal.Enums;

namespace NavySeal.Models
{
    /// <summary>
    /// Tile type
    /// </summary>
    public class Tile
    {
        /// <summary>
        /// Tiletype
        /// </summary>
        private readonly TileType _tileType; 

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tileType"></param>
        public Tile(TileType tileType)
        {
            _tileType = tileType;
        }

        /// <summary>
        /// Create empty tile
        /// </summary>
        /// <returns></returns>
        public static Tile CreateEmptyTile()
        {
            return new Tile(TileType.EMPTY);
        }

        /// <summary>
        /// Create wall tile
        /// </summary>
        /// <returns></returns>
        public static Tile CreateWallTile()
        {
            return new Tile(TileType.WALL);
        }

        /// <summary>
        /// Check if this tiletype need to check collision
        /// </summary>
        public bool CanCollide
        {
            get { return _tileType == TileType.WALL; }
        }

        /// <summary>
        /// Get tiletype of tile
        /// </summary>
        public TileType GetTileType
        {
            get
            {
                return _tileType;
            }
        }
    }
}
