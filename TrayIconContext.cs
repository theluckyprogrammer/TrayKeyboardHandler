using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrayKeyboardHandler.Properties;

namespace TrayKeyboardHandler
{
    public class TrayIconContext : ApplicationContext
    {
        private NotifyIcon trayIcon;
        private GlobalShortcutHandler keyboardHandler;

        public TrayIconContext()
        {
            keyboardHandler = new GlobalShortcutHandler();

            keyboardHandler.Add(new ToggleSettingsCommand());
            // Initialize Tray Icon
            trayIcon = new NotifyIcon()
            {
                Icon = Resources.pumpkin,
                ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("Exit", Exit)
            }),
                Visible = true
            };
        }

        void Exit(object sender, EventArgs e)
        {
            // Hide tray icon, otherwise it will remain shown until user mouses over it
            trayIcon.Visible = false;

            Application.Exit();
        }
    }
}
