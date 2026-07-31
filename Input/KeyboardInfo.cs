using Microsoft.Xna.Framework.Input;

namespace ChefEngine.Input
{
    /// <summary>
    /// KeyboardInfo class for representing keyboard state.
    /// </summary>
    public class KeyboardInfo
    {
        // Keyboard state of the previous frame.
        public KeyboardState PreviousState { get; private set; }

        // Keyboard state of the new frame.
        public KeyboardState CurrentState { get; private set; }

        /// <summary>
        /// Empty constructor for the KeyboardInfo class.
        /// </summary>
        public KeyboardInfo()
        {
            // Set the current state to the current keyboard state.
            CurrentState = Keyboard.GetState();

            // Set the previous state to the current keyboard state initially.
            PreviousState = CurrentState;
        }

        /// <summary>
        /// Updates the stored keyboard state.
        /// </summary>
        public void Update()
        {
            // Save the previous state, and fetch the new state.
            PreviousState = CurrentState;
            CurrentState = Keyboard.GetState();
        }

        /// <summary>
        /// Determines if a key is currently down.
        /// </summary>
        /// <param name="key">Target key.</param>
        /// <returns>Whether the key is down or not.</returns>
        public bool IsKeyDown(Keys key)
        {
            // Perform the key down check.
            return CurrentState.IsKeyDown(key);
        }

        /// <summary>
        /// Determines if a key is currently up.
        /// </summary>
        /// <param name="key">Target key.</param>
        /// <returns>Whether the key is up or not.</returns>
        public bool IsKeyUp(Keys key)
        {
            // Perform the key up check.
            return CurrentState.IsKeyUp(key);
        }

        /// <summary>
        /// Determines if a key was just pressed.
        /// </summary>
        /// <param name="key">Target key.</param>
        /// <returns>Whether the key was just pressed or not.</returns>
        public bool WasKeyJustPressed(Keys key)
        {
            // Perform the key pressed check.
            return PreviousState.IsKeyUp(key) && CurrentState.IsKeyDown(key);
        }

        /// <summary>
        /// Determines if a key was just released.
        /// </summary>
        /// <param name="key">Target key.</param>
        /// <returns>Whether the key was just released or not.</returns>
        public bool WasKeyJustReleased(Keys key)
        {
            // Perform the key released check.
            return PreviousState.IsKeyDown(key) && CurrentState.IsKeyUp(key);
        }
    }
}
