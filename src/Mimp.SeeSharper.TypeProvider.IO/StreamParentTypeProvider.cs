using Mimp.SeeSharper.IO.Provide.Abstraction;
using Mimp.SeeSharper.TypeProvider.Abstraction;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Mimp.SeeSharper.TypeProvider.IO
{
    public class StreamParentTypeProvider : IAssemblyTypeProvider
    {


        public IStreamParentProvider ParentProvider { get; }

        public bool Recursive { get; }


        public IStreamProvider StreamProvider { get; }

        public IStreamParentInfo Parent { get; }

        public Predicate<Uri> StreamFilter { get; }


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
                        var providers = new List<IAssemblyProvider>();
                        foreach (var uri in Recursive ? ParentProvider.GetStreamsRecursive(Parent.Uri) : Parent.GetStreams())
                            if (StreamFilter(uri))
                                try
                                {
                                    providers.Add(new StreamTypeProvider(StreamProvider.ProvideStream(uri)));
                                }
                                catch (Exception ex)
                                {
                                    throw new TypeProvideException($"Can't provide assembly from {uri}", ex);
                                }
                        _provider = new MultipleAssemblyTypeProvider(providers);
                        return _provider;
                    }
                    catch (Exception ex)
                    {
                        throw new TypeProvideException($"Can't provide streams from {Parent} with {ParentProvider}", ex);
                    }
                }
            }
        }


        public StreamParentTypeProvider(IStreamParentProvider parentProvider, bool recursive, IStreamProvider streamProvider, IStreamParentInfo parent, Predicate<Uri> streamFilter)
        {
            ParentProvider = parentProvider ?? throw new ArgumentNullException(nameof(parentProvider));
            Recursive = recursive;
            StreamProvider = streamProvider ?? throw new ArgumentNullException(nameof(streamProvider));
            Parent = parent ?? throw new ArgumentNullException(nameof(parent));
            StreamFilter = streamFilter ?? throw new ArgumentNullException(nameof(streamFilter));
        }

        public StreamParentTypeProvider(IStreamParentProvider parentProvider, bool recursive, IStreamProvider streamProvider, IStreamParentInfo parent, Regex streamRegex)
            : this(parentProvider, recursive, streamProvider, parent, UriMatchRegex(streamRegex)) { }


        public StreamParentTypeProvider(IStreamParentProvider parentProvider, bool recursive, IStreamProvider streamProvider, IStreamParentInfo parent)
            : this(parentProvider, recursive, streamProvider, parent, _ => true) { }

        public StreamParentTypeProvider(IStreamParentProvider parentProvider, IStreamProvider streamProvider, IStreamParentInfo parent)
            : this(parentProvider, true, streamProvider, parent) { }


        public StreamParentTypeProvider(IStreamParentProvider parentProvider, bool recursive, IStreamProvider streamProvider, Uri parent, Predicate<Uri> streamFilter)
            : this(
                  parentProvider,
                  recursive,
                  streamProvider,
                  parentProvider?.ProvideStreamParent(parent ?? throw new ArgumentNullException(nameof(parent)))!,
                  streamFilter
            )
        { }

        public StreamParentTypeProvider(IStreamParentProvider parentProvider, bool recursive, IStreamProvider streamProvider, Uri parent, Regex streamRegex)
            : this(parentProvider, recursive, streamProvider, parent, UriMatchRegex(streamRegex)) { }

        public StreamParentTypeProvider(IStreamParentProvider parentProvider, bool recursive, IStreamProvider streamProvider, Uri parent)
            : this(parentProvider, recursive, streamProvider, parent, _ => true) { }

        public StreamParentTypeProvider(IStreamParentProvider parentProvider, IStreamProvider streamProvider, Uri parent)
            : this(parentProvider, true, streamProvider, parent) { }


        public StreamParentTypeProvider(IStreamParentProvider parentProvider, bool recursive, IStreamProvider streamProvider, string parent, Predicate<Uri> streamFilter)
            : this(parentProvider, recursive, streamProvider, new Uri(parent, UriKind.RelativeOrAbsolute), streamFilter) { }

        public StreamParentTypeProvider(IStreamParentProvider parentProvider, bool recursive, IStreamProvider streamProvider, string parent, Regex streamRegex)
            : this(parentProvider, recursive, streamProvider, parent, UriMatchRegex(streamRegex)) { }

        public StreamParentTypeProvider(IStreamParentProvider parentProvider, bool recursive, IStreamProvider streamProvider, string parent)
            : this(parentProvider, recursive, streamProvider, parent, _ => true) { }

        public StreamParentTypeProvider(IStreamParentProvider parentProvider, IStreamProvider streamProvider, string parent)
            : this(parentProvider, true, streamProvider, parent) { }


        public IEnumerable<Assembly> GetAssemblies() =>
            Provider.GetAssemblies();

        public IEnumerable<Type> GetTypes(Assembly assembly) =>
            Provider.GetTypes(assembly);

        public IEnumerable<Type> GetTypes() =>
            Provider.GetTypes();


        public static bool EndsWithDllExtension(Uri uri) =>
            uri.ToString().EndsWith(".dll");

        public static Predicate<Uri> UriMatchRegex(Regex regex)
        {
            if (regex is null)
                throw new ArgumentNullException(nameof(regex));

            return uri => regex.IsMatch(uri.ToString());
        }


    }
}
