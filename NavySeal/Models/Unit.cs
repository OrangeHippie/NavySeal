﻿using Microsoft.Xna.Framework;

namespace NavySeal.Models
{
    public abstract class Unit
    {
        /// <summary>
        /// Left top position
        /// </summary>
        public Vector2 Position { get; protected set; }

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