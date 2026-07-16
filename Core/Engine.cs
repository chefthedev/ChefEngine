using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ChefEngine.Core
{
    /// <summary>
    /// Engine class for bootstrapping and managing the game engine.
    /// </summary>
    public class Engine : Game
    {
        // Internal static reference to the singleton Engine instance.
        internal static Engine _instance;

        // Public static property to access the singleton Engine instance.
        public static Engine Instance => _instance;

        // GraphicsDeviceManager for interfacing and managing the graphics hardware.
        public static GraphicsDeviceManager Graphics { get; private set; }

        // GraphicsDevice for primitive based rendering.
        // Note: new keyword is used to hide the inherited GraphicsDevice property from the Game class.
        public static new GraphicsDevice GraphicsDevice { get; private set; }

        // SpriteBatch for optimized 2D rendering.
        public static SpriteBatch SpriteBatch { get; private set; }

        // ContentManager for loading game assets.
        // Note: new keyword is used to hide the inherited Content property from the Game class.
        public static new ContentManager Content { get; private set; }

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

            // Set the internal Engine reference to this object instance.
            _instance = this;

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

            // Set the Engine's content manager to the inherited Content property from the Game class.
            Content = base.Content;

            // Set the root directory for the content.
            Content.RootDirectory = "Content";

            // Set the default mouse visibility.
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // Call the base class's Initialize method.
            base.Initialize();

            // Set the Engine's graphics device to the inherited GraphicsDevice property from the Game class.
            GraphicsDevice = base.GraphicsDevice;

            // Create the SpriteBatch instance.
            SpriteBatch = new SpriteBatch(GraphicsDevice);
        }
    }
}
