using Mimp.SeeSharper.TypeProvider.Abstraction;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mimp.SeeSharper.TypeProvider
{
    public abstract class BaseAssemblyTypeProvider : BaseTypeProvider, ITypeProvider, IAssemblyProvider, IAssemblyTypeProvider
    {


        public abstract IEnumerable<Assembly> GetAssemblies();


        public override IEnumerable<Type> GetTypes()
        {
            foreach (var a in GetAssemblies())
                foreach (var t in GetTypes(a))
                    yield return t;
        }


        public virtual IEnumerable<Type> GetTypes(Assembly assembly)
        {
            if (!assembly.IsDynamic)
                foreach (var t in assembly.ExportedTypes)
                    yield return t;
        }


    }
}
