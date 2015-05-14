using Microsoft.Xna.Framework;

namespace NavySeal.Models
{
    /// <summary>
    /// This class is a helper class, to get the new position and speed if there's a collision
    /// </summary>
    public class CollisionDetails
    {
        /// <summary>
        /// Position after collision
        /// </summary>
        public Vector2 PositionAfterCollision { get; set; }

        /// <summary>
        /// Collision details
        /// </summary>
        /// <param name="position"></param>
        public CollisionDetails(Vector2 position)
        {
            PositionAfterCollision = position;
        }
    }
}
