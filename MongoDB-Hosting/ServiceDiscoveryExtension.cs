using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using MongoDB.Driver;
using MongoDBHosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static partial class ServiceDiscoveryExtension
    {
        public static IServiceCollection AddMongoService(this IServiceCollection services, string MongoUri)
        {
            services.TryAddSingleton(new MongoClient(MongoUri));
            RegisterCollections(ref services);
            return services;
        }

        private static void RegisterCollections(ref IServiceCollection services)
        {            
            foreach(var type in Assembly.GetEntryAssembly().GetTypes()) 
            {
                if (type.BaseType == null)
                    continue;

                try
                {
                    if (type.BaseType.GetGenericTypeDefinition() == typeof(CollectionBase<>))
                    {
                        services.TryAddSingleton(type);
                    }
                }
                catch { }
            }
        }
    }
}
