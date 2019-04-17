using System;

namespace LooneyInvaders.Model
{
    internal class VibrationManager
    {
        public static EventHandler VibrationHandler;

        public static void Vibrate()
        {
            VibrationHandler?.Invoke(null, EventArgs.Empty);
        }
    }
}
