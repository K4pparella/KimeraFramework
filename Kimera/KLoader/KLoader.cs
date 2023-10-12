using API.Interfaces;
using Kimera.KLoader.LoaderFeatures;
using MapEditorReborn.Commands.UtilityCommands;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Kimera.KLoader
{
    /// <summary>
    /// The plugin Handler
    /// </summary>
    public class KLoader
    {
        /// <summary>
        /// Class instantiator
        /// </summary>
        public KLoader()
        {
            ServerConsole.AddLog("Starting KLOADER");
            CustomNetworkManager.Modded = true;
        }

        /// <summary>
        /// Gets a List of plugins sorted based on their priority
        /// </summary>
        public static SortedSet<KPlugin<KConfig>> kPlugins { get; } = new(PriorityComparer.Instance);

        /// <summary>
        /// Gets all the assembly Paths
        /// </summary>
        public static Dictionary<Assembly, string> PluginLocations { get; } = new(); 

        /// <summary>
        /// Gets the Assembly's version
        /// </summary>
        public static Version Version { get; } = Assembly.GetExecutingAssembly().GetName().Version;

        /// <summary>
        /// Gets the list of all of the assembly's dependencies
        /// </summary>
        public static List<Assembly> dependencyList { get; } = new();

        public static void LoadPlugins()
        {
            foreach (string path in Directory.GetFiles("../.config/KIMERA/KPlugins", "*.dll"))
            {
                Assembly plugin = 
        }



        public static void InstantiatePlugins()
        {

        }
        public void RunLoader()
        {

        }
    }
}
