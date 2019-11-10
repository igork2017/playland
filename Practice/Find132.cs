using System;
using System.Collections.Generic;
public class Find132{
    public void Run(){
        var input = new int[]{1, 2, 3, 4};
        var input2 = new int[]{3, 1, 4, 2};
        Console.WriteLine(Find132pattern(input));
    }

     public bool Find132pattern(int[] nums) {
        if(nums.Length<3) return false;
        var stack =new Stack<int>();
        var min=new int[nums.Length];
        min[0]=nums[0];
        for(int i=1;i<nums.Length;i++)
            min[i]=Math.Min(min[i-1],nums[i]);
        for(int j=nums.Length-1;j>=0;j--){
            if(nums[j]>min[j]){
                while(stack.Count>0 && stack.Peek()<=min[j])
                    stack.Pop();
                if(stack.Count>0 && stack.Peek()<nums[j]) return true;
                stack.Push(nums[j]);  
            }            
        }
        return false;
    }
}