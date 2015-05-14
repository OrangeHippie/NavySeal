using Microsoft.Xna.Framework;

namespace NavySeal.Models
{
    public abstract class Unit
    {
        protected float Gravity
        {
            get { return 5.0f; }
        }

        public bool CanFall { get; set; }

        /// <summary>
        /// Left top position
        /// </summary>
        public Vector2 Position { get; protected set; }

        /// <summary>
        /// Velocity
        /// </summary>
        public Vector2 Velocity { get; set; }

        /// <summary>
        /// Player size
        /// </summary>
        public Vector2 Size { get; protected set; }

        /// <summary>
        /// Player speed
        /// </summary>
        public Vector2 Speed { get; set; }

        /// <summary>
        /// Player life
        /// </summary>
        public int Life { get; protected set; }

        /// <summary>
        /// Is the unit jumping
        /// </summary>
        public bool IsJumping { get; set; }

        /// <summary>
        /// JumpSpeed
        /// </summary>
        public int JumpSpeed { get; protected set; }

        public void DoJump()
        {
            IsJumping = true;
            JumpSpeed = 5;
        }

        /// <summary>
        /// Set new position on player, if collision happens
        /// </summary>
        /// <param name="position"></param>
        public void NewCollisionPosition(Vector2 position)
        {
            Position = position;
        }

        public abstract void Update(float elapsedTimeSeconds);
    }
}
