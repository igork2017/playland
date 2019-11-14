using System;
using System.Collections.Generic;
public class LastStoneWeightClass{
    public void Run(){
        var input = new int[]{2,7,4,1,8,1};
        var input2=new int[]{31,26,33,21,40};
        Console.WriteLine(LastStoneWeight2(input2));
    }
    public int LastStoneWeight(int[] stones){
        var list=new List<int>(stones);
        return SmashIt(list);
        
    }
    private int SmashIt(List<int> stones){
        var n=stones.Count;
        if(n==0) return 0;
        if(n==1) return stones[0];
        stones.Sort();
        var x=stones[n-2];
        var y=stones[n-1];
        stones.Remove(x);
        stones.Remove(y);
        if(x<y) stones.Add(y-x);
        if(x>y) stones.Add(x-y);
        return SmashIt(stones);
    }

     public int LastStoneWeight2(int[] stones){
        var sum=0;
        foreach(var s in stones){
            sum+=s;
        }
        var dp=new int[(sum>>1)+1];
        dp[stones[0]]=1;
        dp[0]=1;  
        for(int i=1; i<stones.Length; i++)  {
            for(int j=sum/2; j>=stones[i]; j--){

                if(dp[j] == 1 || dp[j - stones[i]] == 1) dp[j] =1;

            }
        }  
        for(int s = sum/2; s>=0; s--){
            if(dp[s]==1) return sum - s- s;
        }  
        return sum;  
    }

}