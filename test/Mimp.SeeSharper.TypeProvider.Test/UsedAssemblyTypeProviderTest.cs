using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mimp.SeeSharper.TypeProvider.Abstraction;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Mimp.SeeSharper.TypeProvider.Test
{
    [TestClass]
    public class UsedAssemblyTypeProviderTest
    {


        [TestMethod]
        public void TestGetAssemblies()
        {

            var provider = new UsedAssemblyTypeProvider();

            var assemblies = provider.GetAssemblies();

            Assert.IsTrue(assemblies.Any());

            Assert.IsTrue(AppDomain.CurrentDomain.GetAssemblies()
                .All(assembly => assemblies.Any(assm => assm.Equals(assembly))));

        }

        [TestMethod]
        public void TestGetTypes()
        {

            var provider = new UsedAssemblyTypeProvider();

            var assembly = typeof(UsedAssemblyTypeProviderTest).Assembly;
            Assert.IsTrue(provider.GetTypes(assembly).All(type => assembly.ExportedTypes.Contains(type)));

            provider.GetTypes(Assembly.LoadFrom(Path.Combine(Path.GetDirectoryName(typeof(UsedAssemblyTypeProviderTest).Assembly.Location), "Mock", "Foo.dll")));

        }

    }
}
