List<int> numbers = new List<int>(Enumerable.Range(1, 1000));
if (numbers.TryGetNonEnumeratedCount(out int count))
{
    Console.WriteLine("Number of elements is {0}", count);
}
else
{
    Console.WriteLine("could not retrieve count without enumeration");
}

