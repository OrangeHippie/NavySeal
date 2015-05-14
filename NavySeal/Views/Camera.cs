using Microsoft.Xna.Framework;

namespace NavySeal.Views
{
    /// <summary>
    /// Game camera, get visual and logical size and position of an object
    /// </summary>
    public class Camera
    {
        /// <summary>
        /// Camera scale
        /// </summary>
        private Vector2 _scale;

        /// <summary>
        /// Max camera size in tiles x
        /// </summary>
        private const int MAX_LOGICAL_TILE_X = 32;
        
        /// <summary>
        /// Max camera size in tiles y
        /// </summary>
        private const int MAX_LOGICAL_TILE_Y = 18;

        /// <summary>
        /// Window height (in pixels)
        /// </summary>
        public int WindowHeight { get; private set; }

        /// <summary>
        /// Window width (in pixels)
        /// </summary>
        public int WindowWidth { get; private set; }


        /// <summary>
        /// Constructor, set window size and max 
        /// </summary>
        /// <param name="windowHeight"></param>
        /// <param name="windowWidth"></param>
        public Camera(float windowHeight, float windowWidth)
        {

            WindowHeight = (int)windowHeight;
            WindowWidth = (int)windowWidth;

            var x = windowWidth / MAX_LOGICAL_TILE_X;
            var y = windowHeight / MAX_LOGICAL_TILE_Y;

            _scale = new Vector2(x, y);
        }

        /// <summary>
        /// Get non logical rectangle (with visual positions and size)
        /// </summary>
        /// <param name="logicalPosition"></param>
        /// <param name="logicalRadius"></param>
        /// <returns></returns>
        public Rectangle VisualRectangle(Vector2 logicalPosition, Vector2 logicalRadius)
        {
            var visualRadiusX = logicalRadius.X * _scale.X;
            var visualRadiusY = logicalRadius.Y * _scale.Y;

            var visualX = (int)(logicalPosition.X * _scale.X);
            var visualY = (int)(logicalPosition.Y * _scale.Y);

            return new Rectangle(visualX, visualY, (int)(visualRadiusX * 2.0f), (int)(visualRadiusY * 2.0f));
        }

        /// <summary>
        /// Get non logical rectangle (with visual positions and size)
        /// </summary>
        /// <param name="visualPosition"></param>
        /// <param name="visualRadius"></param>
        /// <returns></returns>
        public Rectangle LogicalRectangle(Vector2 visualPosition, float visualRadius)
        {
            var logicalRadiusX = (_scale.X / visualRadius);
            var logicalRadiusY = (_scale.Y / visualRadius);

            var logicalX = (int)(visualPosition.X / _scale.X);
            var logicalY = (int)(visualPosition.Y / _scale.Y);

            return new Rectangle(logicalX, logicalY, (int)(logicalRadiusX * 2.0f), (int)(logicalRadiusY * 2.0f));
        }
    }
}
