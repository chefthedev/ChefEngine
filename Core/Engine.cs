using ChefEngine.Graphics;
using ChefEngine.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ChefEngine.Core
{
    /// <summary>
    /// Engine class for bootstrapping and managing the game engine.
    /// </summary>
    public class Engine : Game
    {
        // Singleton Engine instance.
        private static Engine _instance;

        // Public property for accessing the singleton Engine instance.
        public static Engine Instance
        {
            get
            {
                // If the singleton Engine instance is null.
                if (_instance == null)
                {
                    // Throw an exception.
                    throw new InvalidOperationException("Engine has not been initialized.");
                }

                // Return the Engine instance.
                return _instance;
            }
        }

        // GraphicsDeviceManager for interfacing and managing the graphics hardware.
        public GraphicsDeviceManager Graphics { get; private set; }

        // SpriteBatch for optimized 2D rendering.
        public SpriteBatch SpriteBatch { get; private set; }

        // InputManager for unified input handling.
        public InputManager Input { get; private set; }

        // EntityManager for managing all entities.
        public EntityManager EntityManager { get; private set; }

        // Camera for moving display of world.
        public Camera Camera { get; private set; }

        // ExitOnEscape flag for exit behavior, with a default value of true.
        public bool ExitOnEscape { get; set; } = true;

        /// <summary>
        /// Constructor for the Engine class.
        /// </summary>
        /// <param name="title">The title to display in the title bar of the game window.</param>
        /// <param name="width">The initial width of the game window.</param>
        /// <param name="height">The initial height of the game window.</param>
        /// <param name="isFullscreen">Indicates whether to start the game in fullscreen mode or not.</param>
        public Engine(string title, int width, int height, bool isFullscreen)
        {
            // If there is already an instance of the Engine class.
            if (_instance != null)
            {
                // Throw an exception
                throw new InvalidOperationException("The Engine class is a singleton. Only one instance is allowed.");
            }

            // Create a new GraphicsDeviceManager.
            Graphics = new GraphicsDeviceManager(this);

            // Set the graphics defaults.
            Graphics.PreferredBackBufferWidth = width;
            Graphics.PreferredBackBufferHeight = height;
            Graphics.IsFullScreen = isFullscreen;

            // Apply the graphics presentation changes.
            Graphics.ApplyChanges();

            // Set the window title.
            Window.Title = title;

            // Set the root directory for the content.
            Content.RootDirectory = "Content";

            // Set the default mouse visibility.
            IsMouseVisible = true;

            // Set the internal Engine reference to this object instance.
            _instance = this;
        }

        protected override void Initialize()
        {
            // Call the base class's Initialize method.
            base.Initialize();

            // Create the SpriteBatch instance.
            SpriteBatch = new SpriteBatch(GraphicsDevice);

            // Create the InputManager.
            Input = new InputManager();

            // Create the EntityManager.
            EntityManager = new EntityManager();

            // Create the Camera.
            Camera = new Camera(GraphicsDevice.Viewport);
        }

        protected override void Update(GameTime gameTime)
        {
            // Update the input manager.
            Input.Update();

            // If exit on escape is enabled and the escape key was just pressed.
            if (ExitOnEscape && Input.Keyboard.WasKeyJustPressed(Keys.Escape))
            {
                // Exit the game.
                Exit();
            }

            // Update all the entities.
            EntityManager.Update(gameTime);

            // Call the base class's Update method.
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // Clear the screen with a salmon color.
            GraphicsDevice.Clear(Color.Salmon);

            // Begin the sprite batch to prepare for 2D rendering with point sampling for sharp pixel art and the camera transform.
            SpriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Camera.Transform);

            // Draw all the entities.
            EntityManager.Draw();

            // End the sprite batch to finish 2D rendering.
            SpriteBatch.End();

            // Call the base class's Draw method.
            base.Draw(gameTime);
        }
    }
}
