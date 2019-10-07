using System;
using System.Collections.Generic;
using System.Linq;

public static class TwoSums {
    
    public static void Run(){
        var nums = new  int[] {2, 11, 15, 7};
        var target=9;
        var result=NewApproach(nums, target);
        foreach(var t in result){
            Console.WriteLine(t);
        }


    }
    public static int[] TwoSum(int[] nums, int target) {
        var numsLength=nums.Length;
        if(numsLength<=1){
            return null;
        }
        var numsDictionary = new Dictionary<int, int>();
        int index;
        int complement;
        int num;
        for(int i=0;i<numsLength;i++){
            num=nums[i];
            complement=target-num;
            if (numsDictionary.TryGetValue(complement, out index))
            {
                return new int[] { index, i };
            }
            if (!numsDictionary.ContainsKey(num))
            {
                numsDictionary.Add(num, i);
            }
        }
        
        return null;
    }

    public static int[] NewApproach(int[] nums, int target){
      
    var map = new Dictionary<int,int>();
    for (int i = 0; i < nums.Length; i++) {
        int complement = target - nums[i];
        if (map.ContainsKey(complement)) {
            return new int[] { map[complement], i };
        }
        map.Add(nums[i], i);
    }
    throw new ArgumentException("No two sum solution");

    }
}