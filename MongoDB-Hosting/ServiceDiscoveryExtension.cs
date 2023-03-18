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

namespace MongoDBHosting
{
    public static class ServiceDiscoveryExtension
    {
        public static IServiceCollection AddMongoService(this IServiceCollection services, string MongoUri)
        {
            services.TryAddSingleton(new MongoClient(MongoUri));
            var collections = RegisterCollections();

            collections.ForEach(c => services.AddSingleton(c));

            return services;
        }

        private static List<Type> RegisterCollections()
        {
            var collections = new List<Type>();
            var assemblys = AppDomain.CurrentDomain.GetAssemblies();

            foreach(var assembly in assemblys)
            {
                var types = assembly.GetTypes().Where(f =>
                    f.BaseType != null &&
                    f.BaseType.GetGenericTypeDefinition() == typeof(CollectionExtention<>));

                collections.AddRange(types);
            }

            return collections;
        }
    }
}
