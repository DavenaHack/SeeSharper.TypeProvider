using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mimp.SeeSharper.TypeProvider.Abstraction;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Mimp.SeeSharper.TypeProvider.Test
{
    [TestClass]
    public class ExecutingAssemblyTypeProviderTest
    {


        [TestMethod]
        public void TestGetAssemblies()
        {

            var provider = new ExecutingAssemblyTypeProvider();

            var assemblies = provider.GetAssemblies();

            Assert.IsTrue(assemblies.Any());

            var assembly = provider.Assembly;
            Assert.IsTrue(assemblies.Contains(assembly));

            Assert.IsTrue(assembly.GetReferencedAssemblies()
                .All(assemblyName => assemblies.Any(assm => AssemblyName.ReferenceMatchesDefinition(assm.GetName(), assemblyName))));

        }

        [TestMethod]
        public void TestGetTypes()
        {

            var provider = new ExecutingAssemblyTypeProvider();

            var assembly = provider.Assembly;
            Assert.IsTrue(provider.GetTypes(assembly).All(type => assembly.ExportedTypes.Contains(type)));

            Assert.ThrowsException<ArgumentException>(() =>
            {
                provider.GetTypes(Assembly.LoadFrom(Path.Combine(Path.GetDirectoryName(typeof(ExecutingAssemblyTypeProviderTest).Assembly.Location), "Mock", "Foo.dll")));
            });

        }

    }
}
