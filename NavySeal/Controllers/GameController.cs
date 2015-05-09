using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using NavySeal.Enums;
using NavySeal.Models;
using NavySeal.Views;

namespace NavySeal.Controllers
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameController : Game
    {
        /// <summary>
        /// Graphics device manager
        /// </summary>
        private readonly GraphicsDeviceManager _graphics;

        /// <summary>
        /// spritebatch
        /// </summary>
        private SpriteBatch _spriteBatch;

        /// <summary>
        /// Game model
        /// </summary>
        private GameModel _model;

        /// <summary>
        /// Game camera
        /// </summary>
        private Camera _camera;
        
        /// <summary>
        /// Game view
        /// </summary>
        private GameView _view;

        /// <summary>
        /// Sprite dictionary
        /// </summary>
        private Dictionary<TextureType, Texture2D> _spriteDictonary;

        public GameController()
        {
            _graphics = new GraphicsDeviceManager(this);
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _model = new GameModel();
            _spriteDictonary = new Dictionary<TextureType, Texture2D>();
            Content.RootDirectory = "Content";

        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }
        
        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _spriteDictonary.Add(TextureType.Hero, Content.Load<Texture2D>("hero"));

            _camera = new Camera(_graphics.PreferredBackBufferHeight, _graphics.PreferredBackBufferWidth);
            _view = new GameView(_model, _spriteBatch, _spriteDictonary, _camera);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyStateHelper.PrevoiusKeyboardState = KeyStateHelper.CurrentKeyboardState;
            KeyStateHelper.CurrentKeyboardState = Keyboard.GetState();

            if (_model.GetGameState == GameState.Playing)
            {

                if (_view.PlayerWantsToMoveUp())
                {
                    _model.MoveUp();
                }
                else if (_view.PlayerWantsToMoveDown())
                {
                    _model.MoveDown();
                }
                else if (_view.PlayerWantsToMoveLeft())
                {
                    _model.MoveLeft();
                }
                else if (_view.PlayerWantsToMoveRight())
                {
                    _model.MoveRight();
                }
                else
                    _model.StandStill();

                _model.Update((float) gameTime.ElapsedGameTime.TotalSeconds);



            }

            if (_model.GetGameState == GameState.Playing || _model.GetGameState == GameState.Pause)
            {
                if (_view.PressingPause())
                {
                    _model.TogglePause();
                }
            }



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            
            _view.DrawGame();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
