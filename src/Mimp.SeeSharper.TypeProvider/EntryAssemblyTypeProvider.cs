using System.Reflection;

namespace Mimp.SeeSharper.TypeProvider
{
    /// <summary>
    /// <see cref="EntryAssemblyTypeProvider"/> provide all referenced assemblies from <see cref="Assembly.GetEntryAssembly"/> and itself, too.
    /// </summary>
    public class EntryAssemblyTypeProvider : AssemblyTypeProvider
    {


        public EntryAssemblyTypeProvider()
            : base(Assembly.GetEntryAssembly()!) { }


    }
}
