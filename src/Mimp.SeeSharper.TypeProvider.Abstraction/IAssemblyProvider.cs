using System.Collections.Generic;
using System.Reflection;

namespace Mimp.SeeSharper.TypeProvider.Abstraction
{
    /// <summary>
    /// Use <see cref="IAssemblyProvider"/> to provide assemblies.
    /// </summary>
    public interface IAssemblyProvider
    {


        /// <summary>
        /// Return all provided assemblies.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="TypeProvideException"></exception>
        public IEnumerable<Assembly> GetAssemblies();


    }
}
