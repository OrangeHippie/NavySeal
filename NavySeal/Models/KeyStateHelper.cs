using Microsoft.Xna.Framework.Input;

namespace NavySeal.Models
{
    /// <summary>
    /// Keyboard helper, get the previous and the current keybord state easy
    /// </summary>
    public static class KeyStateHelper
    {
        /// <summary>
        /// This is the previous keypress
        /// </summary>
        public static KeyboardState PrevoiusKeyboardState { get; set; }

        /// <summary>
        /// This is the current key that's getting pressed
        /// </summary>
        public static KeyboardState CurrentKeyboardState { get; set; }
    }
}
