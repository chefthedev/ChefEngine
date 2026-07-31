using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChefEngine.Graphics
{
    /// <summary>
    /// Camera class for representing the viewport into the game.
    /// </summary>
    public class Camera
    {
        // X,Y position in space.
        public Vector2 Position { get; set; }

        // Rotation, in radians.
        public float Rotation { get; set; }

        // Zoom multiplier.
        public float Zoom { get; set; }

        public Viewport Viewport { get; private set; }

        // Matrix transformation based on camera properties.
        public Matrix Transform
        {
            get
            {
                // Move the world relative to the camera.
                // Apply rotation and zoom.
                // Move the camera origin to the center of the viewport.
                return Matrix.CreateTranslation(
                            -Position.X,
                            -Position.Y,
                            0.0f)
                     * Matrix.CreateRotationZ(Rotation)
                     * Matrix.CreateScale(Zoom)
                     * Matrix.CreateTranslation(
                            Viewport.Width * 0.5f,
                            Viewport.Height * 0.5f,
                            0.0f);
            }
        }

        /// <summary>
        /// Constructor for the Camera class.
        /// </summary>
        /// <param name="viewport">Viewport of the screen.</param>
        public Camera(Viewport viewport)
        {
            // Initialize the default camera values.
            Position = Vector2.Zero;
            Zoom = 1.0f;
            Rotation = 0.0f;

            // Set the viewport.
            Viewport = viewport;
        }

        /// <summary>
        /// Resizes the camera based on the new viewport.
        /// </summary>
        /// <param name="viewport">Updated viewport.</param>
        public void Resize(Viewport viewport)
        {
            // Set the updated viewport.
            Viewport = viewport;
        }
    }
}
