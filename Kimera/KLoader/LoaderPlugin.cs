using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PluginAPI.Core;
using PluginAPI.Core.Attributes;

namespace Kimera.KLoader
{
    public class LoaderPlugin
    {
        [PluginConfig]
        public static Config Config;

        [PluginEntryPoint("Kimera", null, "A rich low level framework/ModLoader", "Kapparella, Foca del Brasile")]
        public void Enable()
        {
            if(!Config.isEnabled)
            {
                ServerConsole.AddLog("Kimera is currently disabled on your server");
                return;
            }

            Directory.CreateDirectory("../.config/KIMERA");
            Directory.CreateDirectory("../.config/KIMERA/KConfigs");
            Directory.CreateDirectory("../.config/KIMERA/KPlugins");
            Directory.CreateDirectory("../.config/KIMERA/Dependencies");


            new KLoader().RunLoader();
        }
    }
}
