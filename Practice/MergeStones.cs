using System;

public class MergeStonesC{
    public void Run(){
        var stones=new int[]{3,2,4,1};
        var k=2;
        Console.WriteLine(MergeStones(stones,k));

    }

    public int MergeStones(int[] stones, int K){
        int n = stones.Length;
        if ((n - 1) % (K - 1) != 0) return -1;
        var sums =new int[n + 1];
        var dp =new int[n][];
        for(int l=0;l<n;l++) dp[l]=new int[n];
        for (int i = 1; i < n + 1; ++i) {
            sums[i] = sums[i - 1] + stones[i - 1];
        }
        for (int len = K; len <= n; ++len) {
            for (int i = 0; i + len <= n; ++i) {               
                int j = i + len - 1;
                dp[i][j] = Int32.MaxValue;
                for (int t = i; t < j; t += K - 1) {
                    dp[i][j] = Math.Min(dp[i][j], dp[i][t] + dp[t + 1][j]);
                }
                if ((j - i) % (K - 1) == 0) {
                    dp[i][j] += sums[j + 1] - sums[i];
                }
            }
        }
        return dp[0][n - 1];
    }
   /*  public int MergeStones2(int[] stones, int K) {
        var length=stones.Length;
        if(length<K || length%K>0) return -1;
        var minCost=Int32.MaxValue;
        var start=0;
        var end=K;
        for(int i=0;i<length-(K-1);i++){
            var startSum=i>0?stones[i-1]:0;
            var temp=startSum+CalculateSum(stones, start, end, K);
            if(temp<minCost) minCost=temp;
        }    
        return minCost;
    }
    
    private int CalculateSum(int[] stones, int start, int end, int k)     {
            if(end>stones.Length) return 0;
            var result=0;
            
            for(int i=start;i<end;i++){
                result=result+stones[i];
            }
            
            return result+CalculateSum(stones, start+k,end+k,k);
            
        
    } */
}