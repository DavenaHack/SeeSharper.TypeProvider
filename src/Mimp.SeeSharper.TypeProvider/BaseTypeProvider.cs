using Mimp.SeeSharper.TypeProvider.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mimp.SeeSharper.TypeProvider
{
    public abstract class BaseTypeProvider : ITypeProvider
    {


        public abstract IEnumerable<Type> GetTypes();

        public virtual IEnumerable<Type> GetDerivedTypes(Type type) =>
            GetTypes().Where(t => type.IsAssignableFrom(t));


    }
}
