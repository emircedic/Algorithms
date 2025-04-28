namespace Algorithms
{
    public class QuickSort
    {
        public int[] SortArray(int[] nums)
        {
            QuickSortInternal(0, nums.Length, nums);

            return nums;
        }

        private void QuickSortInternal(int startIndex, int endIndex, int[] nums)
        {
            if (endIndex - startIndex <= 1)
                return;

            int pivotValue = nums[endIndex - 1];
            int nextAvailableSlot = startIndex;

            for (int i = startIndex; i < endIndex; i++)
            {
                if (nums[i] < pivotValue)
                {
                    int tempValue = nums[i];
                    nums[i] = nums[nextAvailableSlot];
                    nums[nextAvailableSlot] = tempValue;

                    nextAvailableSlot++;
                }
            }

            nums[endIndex - 1] = nums[nextAvailableSlot];
            nums[nextAvailableSlot] = pivotValue;

            QuickSortInternal(startIndex, nextAvailableSlot, nums);
            QuickSortInternal(nextAvailableSlot + 1, endIndex, nums);
        }
    }
}
