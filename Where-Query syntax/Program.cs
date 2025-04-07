using Data;

var numbers = new[] { 10, 1, 4, 17, 122, 567 };
var evenNumbersQuerySyntax =
    from number in numbers
    where number % 2 == 0
    orderby number
    select number;

Console.WriteLine("Numbers");
foreach (var number in numbers)
{
    Console.WriteLine(number);
}
Console.WriteLine("Even Numbers");
foreach (var number in evenNumbersQuerySyntax)
{
    Console.WriteLine(number);
}

Console.WriteLine("-------------------------");

var pets = Pet.GenerateMockData();
var verySpecificPetsQuerySyntax =
    from pet in pets
    where pet.Weight < 14 && (pet.Type == PetType.Cat || pet.Type == PetType.Dog) && pet.Name?.Length > 4 && pet.Id % 2 == 0
    select $"Pet named {pet.Name}, of type {pet.Type} and weight {pet.Weight}";
Console.WriteLine("Very Specific Pets");
foreach (var pet in verySpecificPetsQuerySyntax)
{
    Console.WriteLine(pet);
}
Console.WriteLine("-------------------------");
var petIndexesSelectedByUser = new[] { 0, 2, 4 };
var petsSelectedByUserAndLighterThan5Kilos =
    from pet in pets
    where petIndexesSelectedByUser.Contains(pet.Id) && pet.Weight < 5
    select $"Pet named {pet.Name}, of type {pet.Type} and weight {pet.Weight}";
Console.WriteLine("Pets Selected By User And Lighter Than 5 Kilos");
foreach (var pet in petsSelectedByUserAndLighterThan5Kilos)
{
    Console.WriteLine(pet);
}
Console.WriteLine("-------------------------");
var countOfDogsHeavierThan1KilosUsingCountMethod =
   (from pet in pets
    where pet.Type == PetType.Dog && pet.Weight >1
    select pet).Count();    
Console.WriteLine($"Count of dogs heavier than 1 kilos using Count method: {countOfDogsHeavierThan1KilosUsingCountMethod}");
Console.WriteLine("-------------------------");
