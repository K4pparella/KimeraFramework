using System.Collections.Generic;

using Kimera.API.Interfaces;
namespace Kimera.KLoader.LoaderFeatures
{
    public sealed class PriorityComparer : IComparer<KPlugin<KConfig>>
    {
        public static readonly PriorityComparer Instance = new();

        public int Compare(KPlugin<KConfig> first, KPlugin<KConfig> second)
        {
            int compareValue = first.priority.CompareTo(second.priority);
            if (compareValue == 0)
                compareValue = first.GetHashCode().CompareTo(second.GetHashCode());

            return compareValue == 0 ? 1 : compareValue;
        }
    }
}
