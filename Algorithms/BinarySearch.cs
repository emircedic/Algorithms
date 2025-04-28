namespace Algorithms
{
    public class BinarySearch
    {
        public int BinarySearchIterative(int[] nums, int target)
        {
            int leftIndex = 0;
            int rightIndex = nums.Length - 1;

            while (leftIndex <= rightIndex)
            {
                int midIndex = leftIndex + ((rightIndex - leftIndex) / 2);

                if (nums[midIndex] < target)
                    leftIndex = midIndex + 1;
                else if (nums[midIndex] > target)
                    rightIndex = midIndex - 1;
                else
                    return midIndex;
            }

            return -1;
        }

        private int BinarySearchRecursive(int startIndex, int endIndex, int target, int[] nums)
        {
            if (endIndex - startIndex <= 1)
                return nums[startIndex] == target ? startIndex : -1;

            int midIndex = startIndex + ((endIndex - startIndex) / 2);

            if (nums[midIndex] < target)
                return BinarySearchRecursive(midIndex, endIndex, target, nums);
            else if (nums[midIndex] > target)
                return BinarySearchRecursive(startIndex, midIndex, target, nums);
            else
                return midIndex;
        }
    }
}
