﻿using System;
using System.Collections.Generic;

namespace Mimp.SeeSharper.TypeProvider.Abstraction
{
    public interface ITypeProvider
    {


        public IEnumerable<Type> GetTypes();

        public IEnumerable<Type> GetDerivedTypes(Type type);


    }
}