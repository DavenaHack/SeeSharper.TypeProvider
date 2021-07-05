using System.Reflection;

namespace Mimp.SeeSharper.TypeProvider
{
    /// <summary>
    /// <see cref="ExecutingAssemblyTypeProvider"/> provide all referenced assemblies from <see cref="Assembly.GetExecutingAssembly"/> and itself, too.
    /// </summary>
    public class ExecutingAssemblyTypeProvider : AssemblyTypeProvider
    {


        public ExecutingAssemblyTypeProvider()
            : base(Assembly.GetExecutingAssembly()!) { }


    }
}
