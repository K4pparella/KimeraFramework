using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kimera.API.Key
{
    public abstract class ObjectCaster<T> where T : class
    {
        public ObjectCaster() { }

        /// <summary>
        /// Casts the current <typeparamref name="T"/>to the <typeparamref name="Obj"/>
        /// </summary>
        /// <typeparam name="Obj">Type to cast as the <typeparamref name="T"/></typeparam>
        /// <returns></returns>
        public Obj Cast<Obj>() where Obj : class, T => this as T as Obj;

    }
}
