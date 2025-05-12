using Data;

var products = new List<Product>
        {
            new Product { Name = "Laptop", Category = "Electronics" },
            new Product { Name = "Smartphone", Category = "Electronics" },
            new Product { Name = "Table", Category = "Furniture" },
            new Product { Name = "Chair", Category = "Furniture" },
            new Product { Name = "T-Shirt", Category = "Clothing" }
        };

// Display the products
Console.WriteLine("Products:");
foreach (var product in products)
{
    Console.WriteLine($"Name: {product.Name}, Category: {product.Category}");
}
Console.WriteLine("-------------------------");

// Group products by category using ToLookup
// This will create a lookup where the key is the category and the value is a collection of products in that category
// Note: ToLookup creates a lookup that allows multiple values for the same key
// whereas ToDictionary requires unique keys. If there are duplicate keys, ToDictionary will throw an exception.
// ToDictionary will throw an exception if there are duplicate keys
// ToLookup will not throw an exception, but will create a collection of values for the same key
// ToLookup is useful when you want to group items by a key and allow multiple values for the same key
// ToDictionary is useful when you want to create a dictionary with unique keys and values
// ToLookup is a LINQ method that creates a lookup from a collection
// ToDictionary is a LINQ method that creates a dictionary from a collection

var lookup = products.ToLookup(p => p.Category);

// Iterate through each group
Console.WriteLine("Products grouped by category using ToLookup:");
foreach (var group in lookup)
{
    Console.WriteLine($"Category: {group.Key}");
    foreach (var product in group)
    {
        Console.WriteLine($"  {product.Name}");
    }
}
Console.WriteLine();
var groupedProducts = products.GroupBy(p => p.Category);
// This will create a collection of groups where each group contains products in the same category
Console.WriteLine("Products grouped by category using GroupBy:");
foreach (var group in groupedProducts)
{
    Console.WriteLine($"Category: {group.Key}");
    foreach (var product in group)
    {
        Console.WriteLine($"  {product.Name}");
    }
}

Console.WriteLine();
// Convert to Dictionary using ToDictionary
// This will create a dictionary where the key is the category and the value is a list of products in that category

var grouped = products.GroupBy(p => p.Category).ToDictionary(g => g.Key, g => g.ToList());
Console.WriteLine("Products grouped by category using ToDictionary:");
foreach (var group in grouped)
{
    Console.WriteLine($"Category: {group.Key}");
    foreach (var product in group.Value)
    {
        Console.WriteLine($"  {product.Name}");
    }
}