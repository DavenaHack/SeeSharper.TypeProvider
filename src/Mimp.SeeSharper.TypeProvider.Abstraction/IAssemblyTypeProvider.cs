using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mimp.SeeSharper.TypeProvider.Abstraction
{
    public interface IAssemblyTypeProvider : IAssemblyProvider, ITypeProvider
    {


        public IEnumerable<Type> GetTypes(Assembly assembly);


    }
}
