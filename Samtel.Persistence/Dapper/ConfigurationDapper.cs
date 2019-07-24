using System;
using DapperExtensions.Mapper;

namespace Samtel.Persistence.Dapper
{
    public class ConfigurationDapper
    {
        public static void Init()
        {
            DapperExtensions.DapperExtensions.DefaultMapper = typeof(CustomPluralizedMapper<>);
            //DapperExtensions.DapperExtensions.SetMappingAssemblies(new[] { typeof(PersonMapper).Assembly });
        }

        public class CustomPluralizedMapper<T> : PluralizedAutoClassMapper<T> where T : class
        {

        }
    }
}
