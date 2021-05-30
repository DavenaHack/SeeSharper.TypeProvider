using Mimp.SeeSharper.Reflection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mimp.SeeSharper.TypeProvider
{
    public class AssemblyTypeProvider : BaseAssemblyTypeProvider
    {


        private IEnumerable<Assembly>? _assemblies;


        public Assembly Assembly { get; }


        public AssemblyTypeProvider(Assembly assembly)
        {
            Assembly = assembly ?? throw new ArgumentNullException(nameof(assembly));
        }


        public override IEnumerable<Assembly> GetAssemblies()
        {
            if (_assemblies is null)
                lock (this)
                    if (_assemblies is null)
                        _assemblies = new[] { Assembly }.Concat(Assembly.GetAssemblies()).ToArray();

            return _assemblies;
        }


    }
}
