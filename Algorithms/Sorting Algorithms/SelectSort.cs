namespace Algorithms
{
    public class SelectSort
    {
        public int[] SortArray(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int currentLowestValueIndex = i;

                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[j] < nums[currentLowestValueIndex])
                        currentLowestValueIndex = j;
                }

                int tempValue = nums[i];
                nums[i] = nums[currentLowestValueIndex];
                nums[currentLowestValueIndex] = tempValue;
            }

            return nums;
        }
    }
}
