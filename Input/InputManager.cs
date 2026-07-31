namespace ChefEngine.Input
{
    /// <summary>
    /// Input Manager class to centralize interacting with user input hardware.
    /// </summary>
    public class InputManager
    {
        // Keyboard state manager.
        public KeyboardInfo Keyboard { get; private set; }

        // Mouse state manager.
        public MouseInfo Mouse { get; private set; }

        /// <summary>
        /// Empty constructor for the InputManager class.
        /// </summary>
        public InputManager()
        {
            // Initialize the keyboard and mouse state managers.
            Keyboard = new KeyboardInfo();
            Mouse = new MouseInfo();
        }

        /// <summary>
        /// Updates the states of each input device.
        /// </summary>
        public void Update()
        {
            // Update the keyboard and mouse inputs.
            Keyboard.Update();
            Mouse.Update();
        }
    }
}
