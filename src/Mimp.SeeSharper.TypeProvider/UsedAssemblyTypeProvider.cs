using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mimp.SeeSharper.TypeProvider
{
    public class UsedAssemblyTypeProvider : BaseAssemblyTypeProvider
    {


        public override IEnumerable<Assembly> GetAssemblies() =>
            AppDomain.CurrentDomain.GetAssemblies();


    }
}
