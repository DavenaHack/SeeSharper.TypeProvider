using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mimp.SeeSharper.IO.Provide.File;
using Mimp.SeeSharper.TypeProvider.IO;
using System.Linq;

namespace Mimp.SeeSharper.TypeProvider.Test
{
    [TestClass]
    public class StreamParentTypeProviderTest
    {


        [TestMethod]
        public void TestGetTypes()
        {
            var streamProvider = new CurrentFileStreamProvider();
            var provider = new StreamParentTypeProvider(streamProvider, true, streamProvider, "Mock", StreamParentTypeProvider.EndsWithDllExtension);

            Assert.IsTrue(provider.GetTypes().Any(type => type.Assembly.GetName().Name == "Foo"));
        }


    }
}
