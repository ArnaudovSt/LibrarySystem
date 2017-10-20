using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Bytes2you.Validation;
using LibrarySystem.Services.Common.Contracts;

namespace LibrarySystem.Services.Common
{
    public class MappingService : IMappingService
    {
        static MappingService()
        {
            MappingProvider = new MappingService();
        }

        public static IMappingService MappingProvider { get; set; }

        public TMapTo Map<TMapTo>(object from)
        {
            Guard.WhenArgument(from, "Mapping object").IsNull().Throw();

            return Mapper.Map<TMapTo>(from);
        }
    }
}
