using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using NavySeal.Enums;

namespace NavySeal.Models
{
    public class GameModel
    {
        /// <summary>
        /// Gamestate of game
        /// </summary>
        private GameState _gameState; 

        /// <summary>
        /// Game level
        /// </summary>
        private readonly Level _level;

        /// <summary>
        /// player
        /// </summary>
        private readonly Player _player;

        /// <summary>
        /// Collision details
        /// </summary>
        private CollisionDetails _collisionDetails;

        /// <summary>
        /// Constructor
        /// </summary>
        public GameModel()
        {
            _gameState = GameState.SplashScreen;
            _level = new Level();
            _player = new Player();
            
        }

        /// <summary>
        /// Get level
        /// </summary>
        public Level Level
        {
            get
            {
                return _level;
            }
        }

        /// <summary>
        /// Update method
        /// </summary>
        /// <param name="elapsedTimeSeconds"></param>
        public void Update(float elapsedTimeSeconds)
        {
            if (elapsedTimeSeconds > 0)
            {
                UpdatePlayer(elapsedTimeSeconds);
            }
        }

        /// <summary>
        /// Update player
        /// </summary>
        /// <param name="elapsedTimeSeconds"></param>
        private void UpdatePlayer(float elapsedTimeSeconds)
        {
            
            //
            // old position
            //
            var prevPlayerPosition = _player.Position;


            if (CollisionFromBelow(prevPlayerPosition) || _player.IsJumping)
                _player.CanFall = false; 
            else if (!_player.IsJumping)
                _player.CanFall = true;   
            

            //
            // update player
            //
            _player.Update(elapsedTimeSeconds);

            //
            // new position after update
            //
            var newPlayerPosition = _player.Position;


            //
            // check if the new position is a collision
            //
            if (_level.CollidingAt(newPlayerPosition, _player.Size))
            {
                //
                // if the new position is collision, set the player back to the old position
                //
                _collisionDetails = GetCollisionDetails(prevPlayerPosition, newPlayerPosition, _player.Size);
                _player.NewCollisionPosition(_collisionDetails.PositionAfterCollision);
            }


        }

        /// <summary>
        /// Check if collide from bottom
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        private bool CollisionFromBelow(Vector2 position)
        {

            return _level.CanCollide((int) Math.Ceiling(position.X), (int) (position.Y + 1)) || _level.CanCollide((int) position.X, (int) (position.Y + 1)); 

        }

        private bool CollisionFromRight(Vector2 position, Vector2 size)
        {
            return _level.CanCollide((int)(position.X + (size.X * 2)), (int)position.Y);
        }

        private bool CollisionFromLeft(Vector2 position, Vector2 size)
        {
            return _level.CanCollide((int)(position.X + (size.X * 2) - 1), (int)position.Y);
        }

        /// <summary>
        /// Get collision details
        /// </summary>
        /// <param name="prevPosition"></param>
        /// <param name="newPosition"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        private CollisionDetails GetCollisionDetails(Vector2 prevPosition, Vector2 newPosition, Vector2 size)
        {
            var collisionDetails = new CollisionDetails(prevPosition);

            if (!CollisionFromRight(newPosition, size) && !CollisionFromLeft(newPosition, size))
                collisionDetails.PositionAfterCollision = new Vector2(newPosition.X,
                    collisionDetails.PositionAfterCollision.Y);
            else
                collisionDetails.PositionAfterCollision = new Vector2((float) Math.Round(collisionDetails.PositionAfterCollision.X),
                    collisionDetails.PositionAfterCollision.Y);

            collisionDetails.PositionAfterCollision = new Vector2(collisionDetails.PositionAfterCollision.X, newPosition.Y);


            return collisionDetails;
        }

        public Player GetPlayer()
        {
            return _player;
        }

        /// <summary>
        /// Move player left
        /// </summary>
        public void MoveLeft()
        {
            _player.Speed = new Vector2(-5.0f, 0);
        }

        /// <summary>
        /// Move player right
        /// </summary>
        public void MoveRight()
        {
            _player.Speed = new Vector2(5.0f, 0); 
        }

        /// <summary>
        /// Move player up
        /// </summary>
        public void MoveUp()
        {
            _player.Speed = new Vector2(0, -5.0f);
        }

        /// <summary>
        /// Move player down
        /// </summary>
        public void MoveDown()
        {
            _player.Speed = new Vector2(0, 5.0f);
        }

        /// <summary>
        /// Stand still
        /// </summary>
        public void StandStill()
        {
            _player.Speed = new Vector2(0, 0);
        }

        /// <summary>
        /// Set player to jump
        /// </summary>
        public void JumpPlayer()
        {
            _player.DoJump();
        }

        /// <summary>
        /// Gamestate
        /// </summary>
        /// <returns></returns>
        public GameState GetGameState { get { return _gameState; } }

        /// <summary>
        /// Set gamestate to pause 
        /// </summary>
        public void TogglePause()
        {
            _gameState =  _gameState == GameState.Pause ? GameState.Playing : GameState.Pause;
        }

        /// <summary>
        /// End the splashscreen, change the gameState to a proper gamestate Show menu or start playing
        /// </summary>
        public void EndSplashScreen()
        {
            _gameState = GameState.Playing;
        }
    }
}
