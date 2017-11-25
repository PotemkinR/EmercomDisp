﻿using EmercomDisp.Data.Clients;
using StructureMap;

namespace EmercomDisp.Data.Dependencies
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<ICallClient>().Use<CallClient>();
        }
    }
}
