using System;
using System.IO;

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
                ServerConsole.AddLog("Kimera is currently disabled on your server", ConsoleColor.Blue);
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
