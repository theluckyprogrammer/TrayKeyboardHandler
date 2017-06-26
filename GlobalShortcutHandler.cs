using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TrayKeyboardHandler
{
    public  class GlobalShortcutHandler    : NativeWindow
    {
        const int TOGGLE_RECORDING = 1;
        private Action invokeAction;
        private List<ShortcutCommand> commands = new List<ShortcutCommand>();

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public GlobalShortcutHandler()
        {
            CreateHandle(new CreateParams());  
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);

            if (m.Msg != 0x0312)
                return;

            int cmdId = m.WParam.ToInt32();
            commands.SingleOrDefault(cmd => cmd.COMMAND_IDENTIFIER == cmdId)?.Execute();           
        }

        public void Dispose()
        {
            DestroyHandle();
        }


        public void Add(ShortcutCommand scmd)
        {
            RegisterHotKey(this.Handle, scmd.COMMAND_IDENTIFIER, scmd.SPECIAL_KEYS, scmd.FUNCTIONAL_KEY);
            commands.Add(scmd);
        }
    }

       

}