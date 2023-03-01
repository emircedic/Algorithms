using Algorithms;

var primeNumbers = PrimeNumberGenerator.GeneratePrimeNumbersOptimal(10);
foreach (var primeNumber in primeNumbers)
    Console.WriteLine(primeNumber);