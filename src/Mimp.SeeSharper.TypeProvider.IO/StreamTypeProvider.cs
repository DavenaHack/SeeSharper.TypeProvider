using Mimp.SeeSharper.IO;
using Mimp.SeeSharper.IO.Provide.Abstraction;
using Mimp.SeeSharper.TypeProvider.Abstraction;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace Mimp.SeeSharper.TypeProvider.IO
{
    public class StreamTypeProvider : IAssemblyTypeProvider
    {


        public IStreamInfo Stream { get; }


        private IAssemblyTypeProvider? _provider;
        private IAssemblyTypeProvider Provider
        {
            get
            {
                if (_provider is not null)
                    return _provider;
                lock (this)
                {
                    if (_provider is not null)
                        return _provider;

                    try
                    {
                        var assembly = Assembly.Load(Stream.OpenRead().ReadBytes());
                        _provider = new AssemblyTypeProvider(assembly);
                        return _provider;
                    }
                    catch (Exception ex)
                    {
                        throw new TypeProvideException($"Can't read assembly from {Stream}.", ex);
                    }
                }
            }
        }


        public StreamTypeProvider(IStreamInfo stream)
        {
            Stream = stream ?? throw new ArgumentNullException(nameof(stream));
            if (!Stream.CanRead())
                throw new ArgumentException($"{stream} isn't readable", nameof(stream));
        }


        public IEnumerable<Assembly> GetAssemblies() =>
            Provider.GetAssemblies();

        public IEnumerable<Type> GetTypes(Assembly assembly) =>
            Provider.GetTypes(assembly);

        public IEnumerable<Type> GetTypes() =>
            Provider.GetTypes();


    }
}
