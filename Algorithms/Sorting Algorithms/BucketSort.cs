namespace Algorithms
{
    public class BucketSort
    {
        public void SortColors(int[] nums)
        {
            int[] countPerColor = new int[3];

            foreach (var color in nums)
                countPerColor[color] += 1;

            int index = 0;
            for (int i = 0; i < countPerColor.Length; i++)
            {
                for (int j = 0; j < countPerColor[i]; j++)
                {
                    nums[index] = i;
                    index++;
                }
            }
        }
    }
}
