using OfType;

var flyables = new List<IFlyable>
{
    new Bird(),
    new Plane(),
    new Helicopter()
};

var birds = flyables.OfType<Bird>();
Console.WriteLine("Birds:");
foreach (var bird in birds)
{
    bird.Fly();
}

Console.WriteLine("Flyables:");
var fuelables = flyables.OfType<IFuelable>();
foreach (var flueable in fuelables)
{
    flueable.Fuel();
}
Console.WriteLine("Planes:");
var planes = flyables.OfType<Plane>();
foreach (var plane in planes)
{
    plane.Fly();
    plane.Fuel();
}

Console.WriteLine("---------");

var differentobjects = new object[]{
    null,
    1,
    "all",
    2,
    "duck"};

var strings = differentobjects.OfType<string>();
Console.WriteLine("Strings:");
foreach (var str in strings)
{
    Console.WriteLine(str);
}
