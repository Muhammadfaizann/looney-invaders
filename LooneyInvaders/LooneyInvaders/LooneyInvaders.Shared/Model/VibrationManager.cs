using System;
using System.Collections.Generic;
using System.Text;

namespace LooneyInvaders.Model
{
    class VibrationManager
    {
        public static EventHandler VibrationHandler;

        public static void Vibrate()
        {
            VibrationHandler?.Invoke(null, EventArgs.Empty);
        }
    }
}
