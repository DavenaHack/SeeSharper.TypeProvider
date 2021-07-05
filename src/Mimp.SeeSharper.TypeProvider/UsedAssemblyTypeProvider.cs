using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mimp.SeeSharper.TypeProvider
{
    /// <summary>
    /// <see cref="UsedAssemblyTypeProvider"/> provide all assemblies which is loaded in <see cref="AppDomain.CurrentDomain"/>.
    /// </summary>
    public class UsedAssemblyTypeProvider : BaseAssemblyTypeProvider
    {


        public override IEnumerable<Assembly> GetAssemblies() =>
            AppDomain.CurrentDomain.GetAssemblies();


    }
}
