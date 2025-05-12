using Data;
using DistinctBy;
using Person = Data.Person;

var pets = new[] {
    new Pet(1, "Goldie", PetType.Fish, 0.5),
    new Pet(2, "Whiskers", PetType.Cat, 4.2),
    new Pet(3, "Buddy", PetType.Dog, 12.8),
    new Pet(4, "Nemo", PetType.Fish, 2.8),
    new Pet(5, "Shadow", PetType.Cat, 5.1),
    new Pet(4, "Nemo", PetType.Fish, 2.8),
};
Console.WriteLine("All pets:");
foreach (var pet in pets)
{
    Console.WriteLine(pet);
}
Console.WriteLine("----------------");
Console.WriteLine("DistinctBy pets");
var distinctPets = pets.DistinctBy(p => p.Id).ToList();
foreach (var pet in distinctPets)
{
    Console.WriteLine(pet);
}
Console.WriteLine("----------------");
Console.WriteLine("DistinctByCustom");

var people = new[]
        {
            new DistinctBy.Person { Id = 1, Name = "Alice"   },
            new DistinctBy.Person { Id = 2, Name = "bob"     },
            new DistinctBy.Person { Id = 3, Name = "ALICE"   },
            new DistinctBy.Person { Id = 4, Name = "Charlie" },
            new DistinctBy.Person { Id = 5, Name = "Bob"     },
            new DistinctBy.Person { Id = 6, Name = "Charlie" },
        };
Console.WriteLine("All people:");
foreach (var p in people)
    Console.WriteLine($"{p.Id}: {p.Name}");

// Case‐insensitive DistinctBy on Name:
var distinctByNameCi = people
    .DistinctByCustom(p => p.Name, StringComparer.OrdinalIgnoreCase);

Console.WriteLine("DistinctByCustom with comparer:");
foreach (var p in distinctByNameCi)
    Console.WriteLine($"{p.Id}: {p.Name}");
Console.WriteLine("----------------");
Console.WriteLine("DistinctByCustom without comparer:");
var distinctByName = people
    .DistinctByCustom(p => p.Name);
foreach (var p in distinctByName)
    Console.WriteLine($"{p.Id}: {p.Name}");
Console.WriteLine("----------------");
string methodCode = @"
public static IEnumerable<TSource> DistinctByCustom<TSource, TKey>(
    this IEnumerable<TSource> source,
    Func<TSource, TKey> keySelector,
    IEqualityComparer<TKey>? comparer = null)
{
    if (source == null) throw new ArgumentNullException(nameof(source));
    if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

    var seenKeys = new HashSet<TKey>(comparer);
    foreach (var element in source)
    {
        var key = keySelector(element);
        if (seenKeys.Add(key))
        {
            // first time we see this key ⇒ yield the element
            yield return element;
        }
    }
}";

Console.WriteLine(methodCode);
