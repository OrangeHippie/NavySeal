using Microsoft.Xna.Framework;

namespace NavySeal.Models
{
    public class Player : Unit
    {
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
        /// Update player
        /// </summary>
        /// <param name="elapsedTimeSeconds"></param>
        public override void Update(float elapsedTimeSeconds)
        {
            Position = Position + Speed * elapsedTimeSeconds;
        }

       

    }
}
