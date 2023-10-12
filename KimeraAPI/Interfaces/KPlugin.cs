using System;
using System.Collections.Generic;
using System.Reflection;
using CommandSystem;
using KimeraAPI.Enums;

namespace KimeraAPI.Interfaces
{
    public interface KPlugin<out T> : IComparable<KPlugin<KConfig>>
        where T : KConfig
    {
        ///<summary>
        ///Plugin assembly
        ///</summary>
        Assembly assembly { get; }


        ///<summary>
        ///Plugin name
        ///</summary>
        string pluginName { get; }

        ///<summary>
        ///Plugin Author name
        ///</summary>
        string pluginAuthor { get; }

        ///<summary>
        ///Plugin Commands
        ///</summary>
        Dictionary<Type, Dictionary<Type, ICommand>> Commands { get; }

        ///<summary>
        ///Plugin Priority
        ///</summary> 
        PluginPriority priority { get; }

        ///<summary>
        ///Plugin version
        ///</summary>
        Version version { get; }

        ///<summary>
        ///Plugin's config
        ///</summary>
        T config { get; }

        ///<summary>
        ///Config's path
        ///</summary>
        string path { get; }

        /// <summary>
        /// The method firstly executed when the plugin is enabled
        /// </summary>
        void OnEnabled();

        /// <summary>
        /// The method firstly executed when the plugin is enabled
        /// </summary>
        void OnDisabled();

        /// <summary>
        /// The method firstly executed when the plugin is reloaded
        /// </summary>
        void Reloaded();

        /// <summary>
        /// The method executed to register commands
        /// </summary>
        void RegisterCommands();

        /// <summary>
        /// The method executed to unregistering commands
        /// </summary>
        void UnRegisterCommnads();
    }
}
