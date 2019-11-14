using System;

public class SingleNonDuplicateClass{
    public void Run(){
        var input=new int[]{3,3,7,7,10,11,11};
        Console.WriteLine(SingleNonDuplicate(input));
    }
    public int SingleNonDuplicate(int[] nums) {
        if(nums.Length==1) return nums[0];
        if(nums[0]!=nums[1]) return nums[0]; 
        
        for(int i=1;i<nums.Length;i+=2){
            if(nums[i]!=nums[i-1]) return nums[i-1];
        }
        return nums[nums.Length-1];
    } 
}