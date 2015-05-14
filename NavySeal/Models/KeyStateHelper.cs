using Microsoft.Xna.Framework.Input;

namespace NavySeal.Models
{
    /// <summary>
    /// Keyboard helper, get the previous and the current keybord state easy
    /// </summary>
    public static class KeyStateHelper
    {
        /// <summary>
        /// This is the revious keypress
        /// </summary>
        public static KeyboardState PreviousKeyboardState { get; set; }

        /// <summary>
        /// This is the current key that's getting pressed
        /// </summary>
        public static KeyboardState CurrentKeyboardState { get; set; }

        /// <summary>
        /// This is the previous gamepad state
        /// </summary>
        public static GamePadState PreviousGamePadState { get; set; }

        /// <summary>
        /// Current gamepad state
        /// </summary>
        public static GamePadState CurrentGamePadState { get; set; }


    }
}
