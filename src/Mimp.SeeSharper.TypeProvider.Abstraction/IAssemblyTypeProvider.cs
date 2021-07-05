using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mimp.SeeSharper.TypeProvider.Abstraction
{
    /// <summary>
    /// Use <see cref="IAssemblyTypeProvider"/> to provide all types 
    /// or only all types of one provided assembly.
    /// </summary>
    public interface IAssemblyTypeProvider : IAssemblyProvider, ITypeProvider
    {


        /// <summary>
        /// Return all provided types from <paramref name="assembly"/>.
        /// </summary>
        /// <param name="assembly"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException">If <paramref name="assembly"/> isn't one of the provided assemblies.</exception>
        /// <exception cref="TypeProvideException"></exception>
        /// <seealso cref="IAssemblyProvider.GetAssemblies"/>
        /// <seealso cref="ITypeProvider.GetTypes"/>
        public IEnumerable<Type> GetTypes(Assembly assembly);


    }
}
