using System.ComponentModel;

namespace Kimera.API.Interfaces
{
    public interface KConfig 
    {
        ///<summary>
        ///Checks if the plugin is enabled
        ///</summary>
        [Description("Is the plugin Enabled?")]
        bool isEnabled { get; set; }

        [Description("Is the plugin in Debug mode?")]
        bool debug { get; set; }
    }
}
