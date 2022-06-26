# MongoDB-Hosting

Simple Library to use MongoDB with DI.

## Example

DI Container
```csharp
services.AddMongoService("YourMongoUri");
```

Collection Class
```csharp
public class RandomCollection : CollectionBase<RandomModel>
{
    public RandomCollection(MongoClient client) : base(client, "Example") { }

    public async Task AddRandom(int Number)
        => await Collection.InsertOneAsync(new RandomModel(Number));

    public async Task DeleteRandom(int Number)
        => await Collection.DeleteOneAsync(filter => filter.Number == Number);
}
```
Collection Model
```csharp
public class RandomModel
{
    [BsonId]
    public ObjectId Id { get; set; }
    public int Number { get; set; }

    public RandomModel(int Number)
    {
        this.Number = Number;
    }
}
```

For an working Example view [MongoDB-Hosting.Example](https://github.com/kampfmodz/MongoDB-Hosting/tree/master/MongoDB-Hosting.Example)