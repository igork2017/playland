using System;

public class MaximumSubArray{
    public void Run(){
        var input= new int[]{-2,1,-3,4,-1,2,1,-5,4};
        Console.WriteLine(MaxSubArray(input));
    }
    public int MaxSubArray(int[] nums) {
        int n = nums.Length, maxSum = nums[0];
        for(int i = 1; i < n; ++i) {
            if (nums[i - 1] > 0) nums[i] += nums[i - 1];
            maxSum = Math.Max(nums[i], maxSum);
        }
        return maxSum;
    }
}
