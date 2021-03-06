using System;

namespace Mimp.SeeSharper.TypeProvider.Abstraction
{
    /// <summary>
    /// Throws if types can't load.
    /// </summary>
    [Serializable]
    public class TypeProvideException : Exception
    {


        public TypeProvideException() { }

        public TypeProvideException(string? message)
            : base(message) { }

        public TypeProvideException(string? message, Exception? inner) 
            : base(message, inner) { }


        protected TypeProvideException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context
        ) : base(info, context) { }


        public static TypeProvideException GetAssemblyCanNotLoadException(string assembly, Exception? inner) =>
            new TypeProvideException($@"""{assembly}"" can't load", inner);

        public static TypeProvideException GetAssemblyCanNotLoadException(string assembly) =>
            GetAssemblyCanNotLoadException(assembly, null);


    }
}
