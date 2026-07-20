namespace ChefEngine.Input
{
    /// <summary>
    /// Input Manager class to centralize interacting with user input hardware.
    /// </summary>
    public class InputManager
    {
        // The keyboard instance.
        public KeyboardInfo Keyboard { get; private set; }

        // The mouse instance.
        public MouseInfo Mouse { get; private set; }

        /// <summary>
        /// Empty constructor for the InputManager class.
        /// </summary>
        public InputManager()
        {
            // Initialize the keyboard and mouse.
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
