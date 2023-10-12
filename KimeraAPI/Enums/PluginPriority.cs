namespace KimeraAPI.Enums
{
    /// <summary>
    /// Plugin priority values
    /// </summary>
    public enum PluginPriority
    {
        Default = Medium,

        Last = int.MinValue,

        Lowest = -2,

        Low = -1,

        Medium = 0,

        High = 1,

        Higher = 2,

        First = int.MaxValue,

    }
}
