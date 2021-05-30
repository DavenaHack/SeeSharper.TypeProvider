using System.Reflection;

namespace Mimp.SeeSharper.TypeProvider
{
    public class EntryAssemblyTypeProvider : AssemblyTypeProvider
    {


        public EntryAssemblyTypeProvider()
            : base(Assembly.GetEntryAssembly()!) { }


    }
}
