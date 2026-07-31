using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace ChefEngine.Input
{
    /// <summary>
    /// MouseInfo class for representing mouse state.
    /// </summary>
    public class MouseInfo
    {
        // Mouse state of the previous frame.
        public MouseState PreviousState { get; private set; }

        // Mouse state of the current frame.
        public MouseState CurrentState { get; private set; }

        // Position wrapper property.
        public Point Position
        {
            get => CurrentState.Position; // Gets the current position of the mouse.
            set => SetPosition(value.X, value.Y); // Sets the current position of the mouse.
        }

        // X Coordinate wrapper property.
        public int X
        {
            get => CurrentState.X; // Gets the current x coordinate of the mouse.
            set => SetPosition(value, CurrentState.Y); // Sets the x coordinate of the mouse and maintains the y.
        }

        // Y Coordinate wrapper property.
        public int Y
        {
            get => CurrentState.Y; // Gets the current y coordinate of the mouse.
            set => SetPosition(CurrentState.X, value); // Sets the y coordinate of the mouse and maintains the x.
        }

        // Change in X,Y position.
        public Point PositionDelta => CurrentState.Position - PreviousState.Position;

        // Change in the x coordinate.
        public int XDelta => CurrentState.X - PreviousState.X;

        // Change in the y coordinate.
        public int YDelta => CurrentState.Y - PreviousState.Y;

        // Whether the mouse was moved or not.
        public bool WasMoved => PositionDelta != Point.Zero;

        // Current scroll wheel value.
        public int ScrollWheel => CurrentState.ScrollWheelValue;

        // Change in the scroll wheel value.
        public int ScrollWheelDelta => CurrentState.ScrollWheelValue - PreviousState.ScrollWheelValue;

        /// <summary>
        /// Empty constructor for the MouseInfo class.
        /// </summary>
        public MouseInfo()
        {
            // Set the current state to the current mouse state.
            CurrentState = Mouse.GetState();

            // Set the previous state to the current mouse state initially.
            PreviousState = CurrentState;
        }

        /// <summary>
        /// Updates the stored mouse state.
        /// </summary>
        public void Update()
        {
            // Save the previous state, and fetch the new state.
            PreviousState = CurrentState;
            CurrentState = Mouse.GetState();
        }

        /// <summary>
        /// Determines if a mouse button is currently down.
        /// </summary>
        /// <param name="button">Target button.</param>
        /// <returns>Whether the button is down or not.</returns>
        public bool IsButtonDown(MouseButton button)
        {
            // Perform the button down check.
            return GetButtonState(CurrentState, button) == ButtonState.Pressed;
        }

        /// <summary>
        /// Determines if a mouse button is currently up.
        /// </summary>
        /// <param name="button">Target button.</param>
        /// <returns>Whether the button is up or not.</returns>
        public bool IsButtonUp(MouseButton button)
        {
            // Perform the button up check.
            return GetButtonState(CurrentState, button) == ButtonState.Released;
        }

        /// <summary>
        /// Determines if a mouse button was just pressed.
        /// </summary>
        /// <param name="button">Target button.</param>
        /// <returns>Whether the button was just pressed or not.</returns>
        public bool WasButtonJustPressed(MouseButton button)
        {
            // Perform the button pressed check.
            return GetButtonState(PreviousState, button) == ButtonState.Released && GetButtonState(CurrentState, button) == ButtonState.Pressed;
        }

        /// <summary>
        /// Determines if a mouse button was just released.
        /// </summary>
        /// <param name="button">Target button.</param>
        /// <returns>Whether the button was just released or not.</returns>
        public bool WasButtonJustReleased(MouseButton button)
        {
            // Perform the button released check.
            return GetButtonState(PreviousState, button) == ButtonState.Pressed && GetButtonState(CurrentState, button) == ButtonState.Released;
        }

        /// <summary>
        /// Manually sets the position of the mouse.
        /// </summary>
        /// <param name="x">X coordinate to set.</param>
        /// <param name="y">Y coordinate to set.</param>
        public void SetPosition(int x, int y)
        {
            // Set the mouse's position.
            Mouse.SetPosition(x, y);

            // Update the current mouse state.
            CurrentState = new MouseState(
                x,
                y,
                CurrentState.ScrollWheelValue,
                CurrentState.LeftButton,
                CurrentState.MiddleButton,
                CurrentState.RightButton,
                CurrentState.XButton1,
                CurrentState.XButton2
            );
        }

        /// <summary>
        /// Gets the button state of a mouse button from the provided mouse state.
        /// </summary>
        /// <param name="state">Target mouse state.</param>
        /// <param name="button">Target button.</param>
        /// <returns>ButtonState of the button.</returns>
        private ButtonState GetButtonState(MouseState state, MouseButton button)
        {
            // Determine the state of the button.
            return button switch
            {
                MouseButton.Left => state.LeftButton,
                MouseButton.Middle => state.MiddleButton,
                MouseButton.Right => state.RightButton,
                MouseButton.SideButton1 => state.XButton1,
                MouseButton.SideButton2 => state.XButton2,
                _ => throw new ArgumentOutOfRangeException(nameof(button))
            };
        }
    }
}
