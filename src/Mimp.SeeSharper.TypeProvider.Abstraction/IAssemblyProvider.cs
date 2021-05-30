using System.Collections.Generic;
using System.Reflection;

namespace Mimp.SeeSharper.TypeProvider.Abstraction
{
    public interface IAssemblyProvider
    {


        public IEnumerable<Assembly> GetAssemblies();


    }
}
