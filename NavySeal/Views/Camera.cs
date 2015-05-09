using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavySeal.Views
{
    public class Camera
    {
        /// <summary>
        /// Camera scale
        /// </summary>
        private Vector2 _scale;

        /// <summary>
        /// Max camera size in tiles x
        /// </summary>
        private const int MAX_LOGICAL_TILE_X = 16;
        
        /// <summary>
        /// Max camera size in tiles y
        /// </summary>
        private const int MAX_LOGICAL_TILE_Y = 9;


        /// <summary>
        /// Constructor, set window size and max 
        /// </summary>
        /// <param name="windowHeight"></param>
        /// <param name="windowWidth"></param>
        public Camera(float windowHeight, float windowWidth)
        {
            float x = windowWidth / MAX_LOGICAL_TILE_X;
            float y = windowHeight / MAX_LOGICAL_TILE_Y;

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
            float visualRadiusX = logicalRadius.X * _scale.X;
            float visualRadiusY = logicalRadius.Y * _scale.Y;

            int visualX = (int)(logicalPosition.X * _scale.X);
            int visualY = (int)(logicalPosition.Y * _scale.Y);

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
            float logicalRadiusX = (_scale.X / visualRadius);
            float logicalRadiusY = (_scale.Y / visualRadius);

            int logicalX = (int)(visualPosition.X / _scale.X);
            int logicalY = (int)(visualPosition.Y / _scale.Y);

            return new Rectangle(logicalX, logicalY, (int)(logicalRadiusX * 2.0f), (int)(logicalRadiusY * 2.0f));
        }
    }
}
