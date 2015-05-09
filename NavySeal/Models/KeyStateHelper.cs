using Microsoft.Xna.Framework.Input;

namespace NavySeal.Models
{
    /// <summary>
    /// Keyboard helper, get the previous and the current keybord state easy
    /// </summary>
    public static class KeyStateHelper
    {
        public static KeyboardState PrevoiusKeyboardState { get; set; }

        public static KeyboardState CurrentKeyboardState { get; set; }
    }
}
