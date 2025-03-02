using Data;
using System;
var people = new List<Person>
{
            new Person { Id = 1, Name = "Alice" },
            new Person { Id = 2, Name = "Bob" },
            new Person { Id = 3, Name = "Charlie" }
        };

// Convert to Dictionary using LINQ ToDictionary
Dictionary<int, string> personDictionary = 
    people.ToDictionary(
            p => p.Id, 
            p => p.Name
        );

// Display dictionary values
foreach (var kvp in personDictionary)
{
    Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
}
