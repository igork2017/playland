using System;

public class TrappingRainWater{
    public void Run(){
        var input = new int[]{0,1,0,2,1,0,1,3,2,1,2,1};
        Console.WriteLine(Trap(input));
    }

    public int Trap(int[] height){
        if(height.Length==0) return 0;
        var result=0;
        var level=0;
        var left=0;
        var right=height.Length-1;
        while(left<right){
            var minHeight=height[left]<height[right]?left++:right--;
            int lowerAmountOfWater=height[minHeight];
            level= Math.Max(lowerAmountOfWater,level);
            result += (level-lowerAmountOfWater);

        }
        return result;
    }
}