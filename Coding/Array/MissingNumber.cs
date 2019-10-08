using System;

public class MissingNumbers{
    public void Run(){
        var input= new int[] {3,0,1};
        Console.WriteLine(MissingNumber(input));

    }

    public int MissingNumber(int[] nums) {
        var length=nums.Length;
        Array.Sort(nums);       
        if(nums[0]!=0) return 0;
      
        if (nums[length-1] != length) {
           return length;
        }
        for(int i=1;i<length;i++){
            if(nums[i-1]+1!=nums[i])
                return nums[i-1]+1;
        }
        return -1;
    }
}