using Microsoft.Xna.Framework;

namespace NavySeal.Models
{
    public class Player : Unit
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public Player() : this(new Vector2(5.0f, 0.0f)){ }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="leftTopPosition"></param>
        public Player(Vector2 leftTopPosition)
        {
            Position = leftTopPosition;
            Life = 100;
            Speed = new Vector2(0, 0);
            Velocity = new Vector2(0, 0);
            Size = new Vector2(0.5f, 0.5f);
            CanFall = true;
        }

        /// <summary>
        /// Update player
        /// </summary>
        /// <param name="elapsedTimeSeconds"></param>
        public override void Update(float elapsedTimeSeconds)
        {
            Velocity = Speed * elapsedTimeSeconds;
            Velocity = !CanJump ? new Vector2(Velocity.X, Gravity * elapsedTimeSeconds) : new Vector2(Velocity.X, 0);

            if (!CanFall)
                Velocity = new Vector2(Velocity.X, 0); 

            Position += Velocity;
        }

       

    }
}
