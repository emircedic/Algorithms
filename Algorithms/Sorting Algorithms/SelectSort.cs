namespace Algorithms
{
     // Time complexity: O (n*n)
     // Space complexity: O (1)
    public class SelectSort
    {
        public int[] SortArray(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int minValueIndex = i;

                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] < nums[minValueIndex])
                        minValueIndex = j;
                }

                int tempValue = nums[i];
                nums[i] = nums[minValueIndex];
                nums[minValueIndex] = tempValue;
            }

            return nums;
        }
    }
}
