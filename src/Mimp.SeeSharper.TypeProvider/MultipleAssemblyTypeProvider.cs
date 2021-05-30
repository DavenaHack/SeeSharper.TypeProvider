using Mimp.SeeSharper.TypeProvider.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Mimp.SeeSharper.TypeProvider
{
    public class MultipleAssemblyTypeProvider : BaseAssemblyTypeProvider
    {


        public IEnumerable<IAssemblyProvider> AssemblyProviders { get; }


        public MultipleAssemblyTypeProvider(IEnumerable<IAssemblyProvider> assemblyProviders)
        {
            AssemblyProviders = assemblyProviders?.ToArray() ?? throw new ArgumentNullException(nameof(assemblyProviders));
            if (AssemblyProviders.Any(p => p is null))
                throw new ArgumentNullException(nameof(assemblyProviders), "At least one provider is null");
        }


        public override IEnumerable<Assembly> GetAssemblies()
        {
            var assemblies = new Dictionary<string, Assembly>();
            foreach (var provider in AssemblyProviders)
                foreach (var assembly in provider.GetAssemblies())
                {
                    var name = assembly.GetName();
                    var n = name.Name;
                    if (n is null)
                        continue;
                    if (assemblies.TryGetValue(n, out var assm))
                    {
                        if (assm.GetName().Version < name.Version)
                            assemblies[n] = assembly;
                    }
                    else
                        assemblies[n] = assembly;
                }
            return assemblies.Values;
        }


    }
}
