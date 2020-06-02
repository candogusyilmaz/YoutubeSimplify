using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ShareNLearn
{
    [DefaultEvent("ClipboardChanged")]
    public class ClipboardMonitor : Control
    {
        private static ClipboardMonitor mInstance;

        public static ClipboardMonitor Instance
        {
            get
            {
                if (mInstance == null)
                    mInstance = new ClipboardMonitor();

                return mInstance;
            }
        }

        private IntPtr nextClipboardMonitor;

        private ClipboardMonitor()
        {
            this.Visible = false;
            nextClipboardMonitor = (IntPtr)SetClipboardViewer((int)this.Handle);
        }

        public event EventHandler ClipboardChanged;

        [DllImport("User32.dll")]
        protected static extern int SetClipboardViewer(int hWndNewViewer);

        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            // defined in winuser.h 
            const int WM_DRAWCLIPBOARD = 0x308;
            const int WM_CHANGECBCHAIN = 0x030D;

            switch (m.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    OnClipboardChanged();
                    SendMessage(nextClipboardMonitor, m.Msg, m.WParam, m.LParam);
                    break;

                case WM_CHANGECBCHAIN:
                    if (m.WParam == nextClipboardMonitor)
                        nextClipboardMonitor = m.LParam;
                    else
                        SendMessage(nextClipboardMonitor, m.Msg, m.WParam, m.LParam);
                    break;

                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private void OnClipboardChanged()
        {
            ClipboardChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}
