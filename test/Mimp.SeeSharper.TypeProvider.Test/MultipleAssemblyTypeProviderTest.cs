using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mimp.SeeSharper.TypeProvider.Abstraction;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Mimp.SeeSharper.TypeProvider.Test
{
    [TestClass]
    public class MultipleAssemblyTypeProviderTest
    {


        [TestMethod]
        public void TestGetAssemblies()
        {

            var entry = new EntryAssemblyTypeProvider();
            var executing = new ExecutingAssemblyTypeProvider();
            var provider = new MultipleAssemblyTypeProvider(new IAssemblyTypeProvider[] {
                entry,
                executing
            });

            var assemblies = provider.GetAssemblies();

            Assert.IsTrue(assemblies.Any());

            Assert.IsTrue(assemblies.Contains(entry.Assembly));
            Assert.IsTrue(assemblies.Contains(executing.Assembly));

            Assert.IsNotNull(assemblies.SingleOrDefault(assembly => assembly.FullName == typeof(Type).Assembly.FullName));
        }

        [TestMethod]
        public void TestGetTypes()
        {

            var entry = new EntryAssemblyTypeProvider();
            var executing = new ExecutingAssemblyTypeProvider();
            var provider = new MultipleAssemblyTypeProvider(new IAssemblyTypeProvider[] {
                entry,
                executing
            });

            var assembly = entry.Assembly;
            Assert.IsTrue(provider.GetTypes(assembly).All(type => assembly.ExportedTypes.Contains(type)));

            Assert.ThrowsException<ArgumentException>(() =>
            {
                provider.GetTypes(Assembly.LoadFrom(Path.Combine(Path.GetDirectoryName(typeof(MultipleAssemblyTypeProviderTest).Assembly.Location), "Mock", "Foo.dll")));
            });

        }

    }
}
