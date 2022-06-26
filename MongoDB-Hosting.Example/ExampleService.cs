using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDB_Hosting.Example
{
    internal class ExampleService : IHostedService
    {
        public RandomCollection RandomCollection { get; }
        public Random Random { get; }

        public ExampleService(RandomCollection randomCollection, Random random)
        {
            RandomCollection = randomCollection;
            Random = random;
        }        

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await RandomCollection.AddRandom(Random.Next(0, 100));

            int Number = Random.Next(0, 100);
            await RandomCollection.AddRandom(Number);
            await RandomCollection.DeleteRandom(Number);
        }

        public Task StopAsync(CancellationToken cancellationToken) { return Task.CompletedTask; }
    }
}
