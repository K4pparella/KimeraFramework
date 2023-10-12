using System.ComponentModel;

using Kimera.API.Interfaces;

namespace Kimera.KLoader
{
    public class Config : KConfig
    {
        [Description("Is Kimera enabled on the server?")]
        public bool isEnabled { get; set; } = true;
        [Description("Do you want to see Kimera's debug messages?")]
        public bool debug { get; set; } = true;
    }
}
