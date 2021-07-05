using Mimp.SeeSharper.TypeProvider.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mimp.SeeSharper.TypeProvider
{
    /// <summary>
    /// <see cref="BaseAssemblyTypeProvider"/> implement default behaviour.
    /// </summary>
    public abstract class BaseAssemblyTypeProvider : IAssemblyTypeProvider
    {


        public abstract IEnumerable<Assembly> GetAssemblies();


        public virtual IEnumerable<Type> GetTypes()
        {
            foreach (var a in GetAssemblies())
                foreach (var t in GetTypes(a))
                    yield return t;
        }


        public virtual IEnumerable<Type> GetTypes(Assembly assembly)
        {
            if (assembly is null)
                throw new ArgumentNullException(nameof(assembly));
            if (!GetAssemblies().Contains(assembly))
                throw new ArgumentException($@"{this} don't contain a assembly ""{assembly}""", nameof(assembly));

            return assembly.IsDynamic ? Type.EmptyTypes : assembly.ExportedTypes;
        }


    }
}
