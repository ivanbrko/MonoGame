// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Microsoft.Xna.Framework.Input
{
    public static partial class Mouse
    {
        [DllImportAttribute("user32.dll", EntryPoint = "SetCursorPos")]
        [return: MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
        private static extern bool SetCursorPos(int X, int Y);

        internal static Form Window;

        private static IntPtr PlatformGetHandle()
        {
            return PrimaryWindow.Handle;
        }

        private static MouseState PlatformGetState(GameWindow window)
        {
            return window.MouseState;
        }

        private static void PlatformSetPosition(int x, int y)
        {
            PrimaryWindow.MouseState.X = x;
            PrimaryWindow.MouseState.Y = y;
            
            var pt = Window.PointToScreen(new System.Drawing.Point(x, y));
            SetCursorPos(pt.X, pt.Y);
        }

        public static void PlatformSetCursor(MouseCursor cursor)
        {

        }
    }
}
