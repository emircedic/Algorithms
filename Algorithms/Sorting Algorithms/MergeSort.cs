namespace Algorithms
{
    internal class MergeSort
    {
        public int[] SortArray(int[] nums)
        {
            MergeSortInternal(0, nums.Length, nums);

            return nums;
        }

        private void MergeSortInternal(int startIndex, int endIndex, int[] nums)
        {
            if (endIndex - startIndex <= 1)
                return;

            int midIndex = startIndex + ((endIndex - startIndex) / 2);

            MergeSortInternal(startIndex, midIndex, nums);
            MergeSortInternal(midIndex, endIndex, nums);
            Merge(startIndex, midIndex, endIndex, nums);
        }

        private void Merge(int startIndex, int midIndex, int endIndex, int[] nums)
        {
            int[] tempResult = new int[endIndex];

            int mainIndex = startIndex;
            int leftPartIndex = startIndex;
            int rightPartIndex = midIndex;

            while (leftPartIndex < midIndex && rightPartIndex < endIndex)
            {
                if (nums[leftPartIndex] <= nums[rightPartIndex])
                {
                    tempResult[mainIndex] = nums[leftPartIndex];
                    leftPartIndex++;
                }
                else
                {
                    tempResult[mainIndex] = nums[rightPartIndex];
                    rightPartIndex++;
                }

                mainIndex++;
            }

            while (leftPartIndex < midIndex)
            {
                tempResult[mainIndex] = nums[leftPartIndex];
                leftPartIndex++;
                mainIndex++;
            }

            while (rightPartIndex < endIndex)
            {
                tempResult[mainIndex] = nums[rightPartIndex];
                rightPartIndex++;
                mainIndex++;
            }

            for (int i = startIndex; i < endIndex; i++)
                nums[i] = tempResult[i];
        }
    }
}
