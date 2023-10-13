using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Kimera.API.Interfaces
{
    public interface KWrapper<T> where T : MonoBehaviour
    {
        /// <summary>
        /// Gets the base class that this class is wrapping
        /// </summary>
        public T BaseClass { get; }
    }
}
