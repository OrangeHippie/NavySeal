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
        /// splashtimer, how long have the splash been showing
        /// </summary>
        private float _splashTimer;

        /// <summary>
        /// How long shall the splashscreen be showing? in seconds
        /// </summary>
        private const int SHOW_SPLASH_SCREEN_TIMER = 1; 

        /// <summary>
        /// Sprite dictionary
        /// </summary>
        private Dictionary<TextureType, Texture2D> _spriteDictonary;

        public GameController()
        {
            _graphics = new GraphicsDeviceManager(this);

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
            _spriteDictonary.Add(TextureType.SplashScreen, Content.Load<Texture2D>("splash-screen"));

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

            KeyStateHelper.PreviousKeyboardState = KeyStateHelper.CurrentKeyboardState;
            KeyStateHelper.CurrentKeyboardState = Keyboard.GetState();
            KeyStateHelper.PreviousGamePadState = KeyStateHelper.CurrentGamePadState;
            KeyStateHelper.CurrentGamePadState = GamePad.GetState(PlayerIndex.One);

            if (_model.GetGameState == GameState.Playing)
            {
                
                if (_view.PlayerWantsToMoveLeft())
                    _model.MoveLeft();
                if (_view.PlayerWantsToMoveRight())
                    _model.MoveRight();
                if(_view.PlayerStandStill())
                    _model.StandStill();

                if (_view.PlayerWantsToJump() && !_model.GetPlayer().IsJumping)
                    _model.JumpPlayer(); 

                _model.Update((float) gameTime.ElapsedGameTime.TotalSeconds);
            }

            if (_model.GetGameState == GameState.SplashScreen)
            {
                _splashTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;

                if (_splashTimer > SHOW_SPLASH_SCREEN_TIMER)
                    _model.EndSplashScreen();
            }

            if (_model.GetGameState == GameState.Playing || _model.GetGameState == GameState.Pause)
                if (_view.PressedPause())
                    _model.TogglePause();



            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            switch (_model.GetGameState)
            {
                case GameState.Playing:
                    _view.DrawGame();
                    break; 
                case GameState.SplashScreen:
                    
                //
                    // Show splashscreen
                    //
                    _view.DrawSplashScreen();

                    break;
                case GameState.Menu:
                    //
                    // Show menu
                    //

                    break;
                case GameState.Pause:
                    //
                    // Show pause
                    //

                    break;
            }
                
            


            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
