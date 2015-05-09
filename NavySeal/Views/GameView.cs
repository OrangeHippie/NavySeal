using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NavySeal.Enums;
using NavySeal.Models;

namespace NavySeal.Views
{
    public class GameView
    {

        /// <summary>
        /// Game camera
        /// </summary>
        private Camera _camera;

        /// <summary>
        /// Gamemodel
        /// </summary>
        private GameModel _model;

        /// <summary>
        /// A dictionary with images (Text2d)
        /// </summary>
        private Dictionary<TextureType, Texture2D> _spriteDictionary;

        /// <summary>
        /// Spritebatch
        /// </summary>
        private SpriteBatch _spriteBatch;



        public GameView(GameModel model, SpriteBatch spriteBatch, Dictionary<TextureType, Texture2D> spriteDictionary, Camera camera)
        {
            _model = model;
            _spriteBatch = spriteBatch;
            _camera = camera;
            _spriteDictionary = spriteDictionary;
        }

        /// <summary>
        /// Draw game, GameState = Playing
        /// </summary>
        public void DrawGame()
        {
            _spriteBatch.Begin();

            DrawPlayer(_model.GetPlayer()); 

            _spriteBatch.End();
        }

        /// <summary>
        /// Draw splashscreen, GameState = SplashScreen
        /// </summary>
        public void DrawSplashScreen()
        {
            _spriteBatch.Begin();

            var visualRect = _camera.VisualRectangle(new Vector2(0, 0), new Vector2(Level.MAX_LEVEL_TILE_X/2.0f, Level.MAX_LEVEL_TILE_Y/2.0f));
            _spriteBatch.Draw(_spriteDictionary[TextureType.SplashScreen], visualRect, null, Color.White);

            _spriteBatch.End();
        }

        private void DrawPlayer(Player player)
        {
            var visualRect = _camera.VisualRectangle(player.Position, player.Size);
            _spriteBatch.Draw(_spriteDictionary[TextureType.Hero], visualRect, null, Color.White);
        }

        /// <summary>
        /// Check if player wants to move up
        /// </summary>
        /// <returns></returns>
        public bool PlayerWantsToMoveUp()
        {
            return KeyStateHelper.CurrentKeyboardState.IsKeyDown(Keys.W);
        }

        /// <summary>
        /// Check if player wants to move down
        /// </summary>
        /// <returns></returns>
        public bool PlayerWantsToMoveDown()
        {
            return KeyStateHelper.CurrentKeyboardState.IsKeyDown(Keys.S);
        }

        /// <summary>
        /// Check if player wants to move left
        /// </summary>
        /// <returns></returns>
        public bool PlayerWantsToMoveLeft()
        {
            return KeyStateHelper.CurrentKeyboardState.IsKeyDown(Keys.A);
        }

        /// <summary>
        /// Check if player wants to move right
        /// </summary>
        /// <returns></returns>
        public bool PlayerWantsToMoveRight()
        {
            return KeyStateHelper.CurrentKeyboardState.IsKeyDown(Keys.D);
        }

        public bool PressingPause()
        {
            return KeyStateHelper.CurrentKeyboardState.IsKeyDown(Keys.P) && !KeyStateHelper.PrevoiusKeyboardState.IsKeyDown(Keys.P);
        }

        public bool PlayerStandStill()
        {
            return !PlayerWantsToMoveDown() && 
                    !PlayerWantsToMoveLeft() && 
                    !PlayerWantsToMoveRight() &&
                    !PlayerWantsToMoveUp(); 
        }

    }
}
