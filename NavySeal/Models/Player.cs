using Microsoft.Xna.Framework;

namespace NavySeal.Models
{
    public class Player
    {

        /// <summary>
        /// Left top position
        /// </summary>
        public Vector2 Position { get; private set; }

        /// <summary>
        /// Player size
        /// </summary>
        public Vector2 Size { get; private set; }

        /// <summary>
        /// Player speed
        /// </summary>
        public Vector2 Speed { get; set; }

        /// <summary>
        /// Player life
        /// </summary>
        public int Life { get; private set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Player() : this(new Vector2(7.0f, 4.0f)){ }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="leftTopPosition"></param>
        public Player(Vector2 leftTopPosition)
        {
            Position = leftTopPosition;
            Life = 100;
            Speed = new Vector2(0, 0);
            Size = new Vector2(0.5f, 0.5f);
        }

        /// <summary>
        /// Set new position on player, if collision happens
        /// </summary>
        /// <param name="position"></param>
        public void NewCollisionPosition(Vector2 position)
        {
            Position = position;
        }

        /// <summary>
        /// Update player
        /// </summary>
        /// <param name="elapsedTimeSeconds"></param>
        public void Update(float elapsedTimeSeconds)
        {
            Position = Position + Speed * elapsedTimeSeconds;
        }

       

    }
}
