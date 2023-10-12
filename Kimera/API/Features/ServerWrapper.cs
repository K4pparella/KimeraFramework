using System;
using System.Collections.Generic;
using System.Reflection;

using GameCore;

using Kimera.API.Interfaces;

using MEC;

using Mirror;

using PlayerRoles.RoleAssign;
using PluginAPI.Core;
using RoundRestarting;

using UnityEngine;

namespace Kimera.API.Features
{
    public class ServerWrapper
    {
        /// <summary>
        /// Gets the Assembly with his paired KPlugin
        /// </summary>
        public static Dictionary<Assembly, KPlugin<KConfig>> Assemblies { get; } = new();
        
        /// <summary>
        /// Gets or sets the server'sName
        /// </summary>
        public static string ServerName { get => ServerConsole._serverName;
            set 
            { 
                ServerConsole._serverName = value;
                ServerConsole.singleton.RefreshServerData();
            } 
        }

        /// <summary>
        /// Gets the <see cref="Broadcast"/>
        /// </summary>
        public static Broadcast Broadcast => Broadcast.Singleton;

        /// <summary>
        /// Gets the current server's Version
        /// </summary>
        public static string Version => GameCore.Version.VersionString;

        /// <summary>
        /// Checks if the servers version is a beta
        /// </summary>
        public static bool Beta => GameCore.Version.PrivateBeta;

        /// <summary>
        /// Gets the server's IP
        /// </summary>
        public static string Ip => ServerConsole.Ip;

        /// <summary>
        /// Get's the server's port
        /// </summary>
        public static ushort Port => ServerStatic.ServerPort;

        /// <summary>
        /// Gets the server's TPS
        /// </summary>
        public static double Tps => Math.Round(1f / Time.smoothDeltaTime);

        /// <summary>
        /// Gets or sets if the friendly fire is allowed
        /// </summary>
        public static bool IsFriendlyFireAllowed
        {
            get => ServerConsole.FriendlyFire;
            set
            {
                ServerConsole.FriendlyFire = value;
                ServerConfigSynchronizer.Singleton.RefreshMainBools();
                PlayerStatsSystem.AttackerDamageHandler.RefreshConfigs();
            }
        }

        /// <summary>
        /// Gets the current players inside of the server
        /// </summary>
        public static int PlayerCount => Player.Count;

        /// <summary>
        /// Gets the late join time of a player
        /// </summary>
        public static float LateJoinTime => ConfigFile.ServerConfig.GetFloat(RoleAssigner.LateJoinKey, 0f);

        /// <summary>
        /// Gets if the server has LateJoin enabled
        /// </summary>
        public bool CanPlayersLateJoin => LateJoinTime > 0f;

        /// <summary>
        /// Restarts the server
        /// </summary>
        public static void Restart() => Round.Restart(false, false, ServerStatic.NextRoundAction.Restart);

        /// <summary>
        /// Closes the server
        /// </summary>
        public static void Close() => Shutdown.Quit(); 

        /// <summary>
        /// Redirects all the players that are currently in the server into a different server
        /// </summary>
        /// <param name="port">The redirecting server's port</param>
        public static void RedirectAllPlayers(ushort port) => NetworkServer.SendToAll(new RoundRestartMessage(RoundRestartType.RedirectRestart, 0f, port, true, false));

        /// <summary>
        /// Sends a serverconsole command. For RemoteAdminCommands type / before the command
        /// </summary>
        /// <param name="command">The command that gets executed</param>
        /// <param name="sender">The <see cref="CommandSender"/> that runs the command</param>
        public static void RunCommand(string command, CommandSender sender) => GameCore.Console.singleton.TypeCommand(command, sender);
    }
}
