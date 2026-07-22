using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ChefEngine.Graphics
{
    /// <summary>
    /// Camera class for representing the viewport into the game.
    /// </summary>
    public class Camera
    {
        // The position of the camera.
        public Vector2 Position { get; set; }

        // The rotation of the camera, in radians.
        public float Rotation { get; set; }

        // The zoom multiplier of the camera.
        public float Zoom { get; set; }

        public Viewport Viewport { get; private set; }

        // The transform matrix of the camera.
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
        /// <param name="viewport">The viewport.</param>
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
        /// <param name="viewport">The updated viewport.</param>
        public void Resize(Viewport viewport)
        {
            // Set the updated viewport.
            Viewport = viewport;
        }
    }
}
