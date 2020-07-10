using System;
using Javax.Microedition.Khronos.Egl;

namespace LooneyInvaders.Droid.Helpers
{
    public static class EglHelper
    {
        public static void InitEgl() //ToDo: check - maybe isn't required anymore
        {
            var egl = (EGLContext.EGL as IEGL10) ?? (EGLContext.EGL as IEGL11);
            var display = (EGLDisplay)EGL10.EglDefaultDisplay;
            if (!egl.EglInitialize(display, null))
            {
                throw new Exception("Can't initialize EGL!");
            }
        }
    }
}
