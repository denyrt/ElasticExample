using System.Reflection;

namespace ElasticExample.BusinessLogic.Extensions
{
    public static class AssemblyExtensions
    {
        public static Assembly GetBisunessAssembly() => typeof(AssemblyExtensions).Assembly;
    }
}
