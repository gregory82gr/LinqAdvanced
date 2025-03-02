using Data;

var products = new List<Product>
        {
            new Product { Name = "Laptop", Category = "Electronics" },
            new Product { Name = "Smartphone", Category = "Electronics" },
            new Product { Name = "Table", Category = "Furniture" },
            new Product { Name = "Chair", Category = "Furniture" },
            new Product { Name = "T-Shirt", Category = "Clothing" }
        };

// Group products by category using ToLookup
var lookup = products.ToLookup(p => p.Category);

// Iterate through each group
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
foreach (var group in groupedProducts)
{
    Console.WriteLine($"Category: {group.Key}");
    foreach (var product in group)
    {
        Console.WriteLine($"  {product.Name}");
    }
}

Console.WriteLine();
var grouped = products.GroupBy(p => p.Category).ToDictionary(g => g.Key, g => g.ToList());

foreach (var group in grouped)
{
    Console.WriteLine($"Category: {group.Key}");
    foreach (var product in group.Value)
    {
        Console.WriteLine($"  {product.Name}");
    }
}