using System.Reflection;

namespace Mimp.SeeSharper.TypeProvider
{
    public class ExecutingAssemblyTypeProvider : AssemblyTypeProvider
    {


        public ExecutingAssemblyTypeProvider()
            : base(Assembly.GetExecutingAssembly()!) { }


    }
}
