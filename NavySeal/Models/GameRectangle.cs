using Microsoft.Xna.Framework;

namespace NavySeal.Models
{
    /// <summary>
    /// Game rectangle
    /// </summary>
    public class GameRectangle
    {

        /// <summary>
        /// Top-left of rectangle
        /// </summary>
        private Vector2 _topLeft;

        /// <summary>
        /// Bottom-right of rectangle
        /// </summary>
        private Vector2 _bottomRight;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="topLeft"></param>
        /// <param name="bottomRight"></param>
        public GameRectangle(Vector2 topLeft, Vector2 bottomRight)
        {
            _topLeft = topLeft;
            _bottomRight = bottomRight;
        }

        /// <summary>
        /// Create a new gamerectangle, where "center position" of rectangle is topleft
        /// </summary>
        /// <param name="topLeftPosition"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        public static GameRectangle CreateFromTopLeft(Vector2 topLeftPosition, Vector2 size)
        {
            var topLeft = topLeftPosition;
            var bottomRight = topLeftPosition + (size * 2.0f);

            return new GameRectangle(topLeft, bottomRight);
        }

        /// <summary>
        /// Get right position of rectangle
        /// </summary>
        public float Right
        {
            get { return _bottomRight.X; }
        }

        /// <summary>
        /// Get bottom position of rectangle
        /// </summary>
        public float Bottom
        {
            get { return _bottomRight.Y; }
        }

        /// <summary>
        /// Get left position of rectangle
        /// </summary>
        public float Left
        {
            get { return _topLeft.X; }
        }

        /// <summary>
        /// Get top position of rectangle
        /// </summary>
        public float Top
        {
            get { return _topLeft.Y; }
        }

        /// <summary>
        /// Check if colliding
        /// </summary>
        /// <param name="gameRectangle"></param>
        /// <returns></returns>
        public bool IsIntersecting(GameRectangle gameRectangle)
        {
            if (Right < gameRectangle.Left)
                return false;
            if (Bottom < gameRectangle.Top)
                return false;
            if (Left > gameRectangle.Right)
                return false;
            if (Top > gameRectangle.Bottom)
                return false;

            return true;
        }
    }
}
