using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrayKeyboardHandler.Properties;

namespace TrayKeyboardHandler
{
    public class ToggleSettingsCommand : ShortcutCommand
    {
        string path;


        public ToggleSettingsCommand() : base(1234, SpecialKey.ALT+SpecialKey.SHIFT,(int) System.Windows.Forms.Keys.R)
        {
            this.path = @"assets\testowy.txt";                                   
        }

        public override void Execute()
        {          

            string content = File.ReadAllText(path);

            bool stateToBeSet = content.Contains("false") ? true : false;

            var a = content.Replace((!stateToBeSet).ToString().ToLower(), stateToBeSet.ToString().ToLower());

            File.WriteAllText(path,a);

            ShowPopup(Resources.information_2_64, "Information", "Settings changed");
        }
    }
}
