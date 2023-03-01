namespace Algorithms
{
    public static class PrimeNumberGenerator
    {
        public static List<int> GeneratePrimeNumbersBruteForce(int countOfPrimeNumbers)
        {
            List<int> primes = new();
            int n = 2;

            while (primes.Count < countOfPrimeNumbers)
            {
                bool isPrime = true;

                // Checking if the current number is divisible by numbers from 2 to the square root of it.
                var sqrtOfCurrentIndex = Math.Sqrt(n);
                for (int i = 2; i <= sqrtOfCurrentIndex; i++)
                {
                    if (n % i == 0)
                    {
                        isPrime = false;
                        break;
                    }
                }

                if (isPrime)
                    primes.Add(n);

                n++;
            }

            return primes;
        }

        public static List<int> GeneratePrimeNumbersOptimal(int countOfPrimeNumbers)
        {
            List<int> primeNumbers = new();
            bool[] isComposite = new bool[countOfPrimeNumbers * 20];

            for (int i = 2; primeNumbers.Count < countOfPrimeNumbers; i++)
            {
                if (!isComposite[i])
                {
                    primeNumbers.Add(i);
                    for (int j = i * i; j < isComposite.Length; j += i) // Setting all numbers multiplied and than added by the same number as composite.
                    {
                        isComposite[j] = true;
                    }
                }
            }

            return primeNumbers;
        }
    }

}
