namespace Algorithms
{
    public class InsertSort
    {
        public int[] SortArray(int[] nums)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                int j = i;

                while (j > 0 && nums[j - 1] > nums[j])
                {
                    int tempValue = nums[j - 1];
                    nums[j - 1] = nums[j];
                    nums[j] = tempValue;

                    j--;
                }
            }

            return nums;
        }
    }
}
