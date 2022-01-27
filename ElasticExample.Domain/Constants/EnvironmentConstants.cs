using static System.Environment;

namespace ElasticExample.Domain.Constants
{
    public static class EnvironmentConstants
    {
        public static string ConnectionString => GetEnvironmentVariable("EE_ConnectionString", EnvironmentVariableTarget.User) ?? string.Empty;

        public static string ElasticHost => GetEnvironmentVariable("EE_ElasticHost", EnvironmentVariableTarget.User) ?? string.Empty;
    }
}