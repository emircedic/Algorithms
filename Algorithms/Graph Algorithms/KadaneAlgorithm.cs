namespace Algorithms.Graph_Algorithms
{

    // Kadane's algorithm is a dynamic programming algorithm with the
    // only difference being that it doesn't need a seperate array.
    public class KadaneAlgorithm
    {
        // Brute Force: O(n^2)
        public static int BruteForce(int[] nums)
        {
            int maxSum = nums[0];

            for (int i = 0; i < nums.Length; i++)
            {
                int curSum = 0;
                for (int j = i; j < nums.Length; j++)
                {
                    curSum += nums[j];
                    maxSum = Math.Max(maxSum, curSum);
                }
            }
            return maxSum;
        }

        // Kadane's Algorithm: O(n)
        public static int Kadanes(int[] nums)
        {
            int maxSum = nums[0];
            int curSum = 0;

            foreach (int n in nums)
            {
                curSum = Math.Max(curSum, 0);
                curSum += n;
                maxSum = Math.Max(maxSum, curSum);
            }
            return maxSum;
        }

        // Dynamic programming solution similiar to Kadanes
        // but with sub-optimal space complexity.
        public static int DynamicProgramming(int[] nums)
        {
            int[] array = new int[nums.Length];

            array[0] = nums[0];

            for (int i = 1; i < nums.Length; i++)
                array[i] = nums[i] + Math.Max(0, array[i - 1]);

            return array.Max();
        }

        // Return the left and right index of the max subarray sum,
        // assuming there's exactly one result (no ties).
        // Sliding window variation of Kadane's: O(n)
        public static int[] SlidingWindow(int[] nums)
        {
            int maxSum = nums[0];
            int curSum = 0;
            int maxL = 0, maxR = 0;
            int L = 0;

            for (int R = 0; R < nums.Length; R++)
            {
                if (curSum < 0)
                {
                    curSum = 0;
                    L = R;
                }
                curSum += nums[R];
                if (curSum > maxSum)
                {
                    maxSum = curSum;
                    maxL = L;
                    maxR = R;
                }
            }
            return new int[] { maxL, maxR };
        }
    }
}
