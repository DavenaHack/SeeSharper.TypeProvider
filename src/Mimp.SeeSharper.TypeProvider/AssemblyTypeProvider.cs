using Mimp.SeeSharper.Reflection;
using Mimp.SeeSharper.TypeProvider.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mimp.SeeSharper.TypeProvider
{
    public class AssemblyTypeProvider : BaseAssemblyTypeProvider
    {


        private IEnumerable<Assembly>? _assemblies;


        /// <summary>
        /// Assembly from that all referenced assemblies provided.
        /// </summary>
        public Assembly Assembly { get; }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="assembly"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public AssemblyTypeProvider(Assembly assembly)
        {
            Assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
        }


        /// <summary>
        /// Return all referenced assemblies of <see cref="Assembly"/>.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="TypeProvideException"></exception>
        public override IEnumerable<Assembly> GetAssemblies()
        {
            if (_assemblies is null)
                lock (this)
                    if (_assemblies is null)
                        try
                        {
                            _assemblies = new[] { Assembly }.Concat(Assembly.GetAssemblies()).ToArray();
                        }
                        catch (Exception ex)
                        {
                            throw new TypeProvideException(ex.Message, ex);
                        }

            return _assemblies;
        }


    }
}
