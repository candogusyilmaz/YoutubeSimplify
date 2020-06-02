using System;
using System.Runtime.InteropServices;

namespace ShareNLearn
{
    internal class NativeMethods
    {
        public const int HWND_BROADCAST = 0xffff;

        public static readonly int WM_SHARENLEARN = RegisterWindowMessage("WM_SHARENLEARN");

        [DllImport("user32")]
        public static extern bool PostMessage(IntPtr hwnd, int msg, IntPtr wparam, IntPtr lparam);

        [DllImport("user32")]
        public static extern int RegisterWindowMessage(string message);
    }
}
