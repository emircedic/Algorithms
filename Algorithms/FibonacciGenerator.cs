namespace Algorithms
{
    // Fibonacci numbers are numbers which are created by adding two previous numbers.
    public static class FibonacciGenerator
    {
        public static List<int> GenerateFibonacciNumbers(int countOfNumbers)
        {
            List<int> fibonacciNumbers = new() { 0, 1 };

            while (fibonacciNumbers.Count < countOfNumbers)
            {
                var currentNewNumber = fibonacciNumbers.ElementAt(fibonacciNumbers.Count - 2) + fibonacciNumbers.ElementAt(fibonacciNumbers.Count - 1);
                fibonacciNumbers.Add(currentNewNumber);
            }

            return fibonacciNumbers;
        }
    }
}
