using System;
using System.Collections.Generic;

namespace Mimp.SeeSharper.TypeProvider.Abstraction
{
    /// <summary>
    /// Use <see cref="ITypeProvider"/> to provide available types.
    /// </summary>
    public interface ITypeProvider
    {


        /// <summary>
        /// Return all provided types.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="TypeProvideException"></exception>
        public IEnumerable<Type> GetTypes();


    }
}
