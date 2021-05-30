using System;

namespace Mimp.SeeSharper.TypeProvider.Abstraction
{
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


        public static TypeProvideException GetAssemblyCannotLoadException(string assembly, Exception? inner) =>
            new TypeProvideException($@"""{assembly}"" can't load", inner);

        public static TypeProvideException GetAssemblyCannotLoadException(string assembly) =>
            GetAssemblyCannotLoadException(assembly, null);


    }
}
