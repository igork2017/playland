using System;
using System.Collections.Generic;

/* public class TwoSum2{
    public void Run(){
        var numbers = new int[]{2,7,11,15};
        var target = 9;
        var result=TwoSum(numbers,target);
        foreach(var i in result)
            Console.WriteLine(i);

    }

    public int[] TwoSum(int[] numbers, int target) {
        var startIndex=0;
        var endIndex=numbers.Length-1;
        while(startIndex<endIndex){
            if(numbers[startIndex] +numbers[endIndex]==target) return new int[]{startIndex +1,endIndex+1};
            if(numbers[startIndex] +numbers[endIndex]>target) endIndex--;
            if(numbers[startIndex] +numbers[endIndex]<target) startIndex++;
        }
        return new int[]{-1,-1};
    }
} */