using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

using Kimera.API.Interfaces;
using Kimera.KLoader.LoaderFeatures;
using Kimera.API.Features;

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
            ServerConsole.AddLog("Starting KLOADER", ConsoleColor.Blue);
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

        /// <summary>
        /// Loads a single assembly
        /// </summary>
        /// <param name="pathName">Represents a single assembly path</param>
        /// <returns>Returns the loaded assembly</returns>
        public static Assembly LoadSinglePlugin(string pathName)
        {
            try
            {
                Assembly ass = Assembly.Load(File.ReadAllBytes(pathName));

                return ass;
            }
            catch(Exception ex)
            {
                ServerConsole.AddLog($"Error loading {pathName}! {ex}", ConsoleColor.Red);
                return null;
            }
        }

        /// <summary>
        /// Instantiates a Plugin
        /// </summary>
        /// <param name="ass">The plugin's Assembly</param>
        /// <returns>Returns the plugin's instance</returns>
        public static KPlugin<KConfig> InstantiatePlugin(Assembly ass)
        {
            try
            {
                foreach(Type t in ass.GetTypes())
                {
                    KPlugin<KConfig> plugin = null;
                    ConstructorInfo pluginConstructor = t.GetConstructor(Type.EmptyTypes);
                    if(pluginConstructor is not null)
                        plugin = pluginConstructor.Invoke(null) as KPlugin<KConfig>;
                    else
                    {
                        object val = Array.Find(t.GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static), property => property.PropertyType == t)?.GetValue(null);
                        if (val is not null)
                            plugin = val as KPlugin<KConfig>;
                    }
                    return plugin;
                }
            }
            catch (Exception ex)
            {
                ServerConsole.AddLog($"Error while loading {ass.FullName}, {ex}");
            }
            return null;
        }

        /// <summary>
        /// Loads All plugins
        /// </summary>
        public static void LoadPlugins()
        {
            foreach (string path in Directory.GetFiles("../.config/KIMERA/KPlugins", "*.dll"))
            {
                Assembly plugin = LoadSinglePlugin(path);
                if (plugin is null)
                    continue;

                PluginLocations[plugin] = path;
            }

            foreach(Assembly ass in PluginLocations.Keys)
            {
                if (PluginLocations[ass].Contains("dependencies"))
                    continue;

                KPlugin<KConfig> pl = InstantiatePlugin(ass);
                if(pl is null) continue;
                AssemblyInformationalVersionAttribute attribute = pl.assembly.GetCustomAttribute<AssemblyInformationalVersionAttribute>();
                KServer.Assemblies.Add(ass, pl);
            }
        }
        public void RunLoader()
        {

        }
    }
}
