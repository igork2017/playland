using System;

public class UsingWater{
    public void Run(){
        var intArr=new int[]{2,3,10,5,7,8,9};
        Console.Write(MaxArea(intArr));
    }
    public int MaxArea(int[] height){
        var hLength=height.Length;
        int i=0;
        int j=hLength-1;
        if(hLength<2) return 0;
        int maxarea=0;
        while(i<j){              
               
                maxarea=Math.Max(maxarea, Math.Min(height[i],height[j]) * (j-i));
                if(height[i]<height[j])
                    i++;
                else
                    j--;
            }
        return maxarea;
    }
}