using System;

public class NumberOfDiceRolls{
    public void Run(){
        var dice=2;
        var faces=6;
        var target=7;
        Console.WriteLine(NumRollsToTarget(dice,faces,target));
    }

     public int NumRollsToTarget(int d, int f, int target) {
        const int mod = 1000000007;
        var dp = new int[d + 1][];
        dp[0]=new int[target+1];
        dp[0][0] = 1;
         
        for (int i = 1; i <= d; i++)
        {   
            dp[i]=new int[target+1];
            for (int j = 1; j <= f; j++)
                for (int k = j; k <= target; k++)
                    dp[i][k] = (dp[i][k] + dp[i - 1][k - j]) % mod;
        }            
        return dp[d][target];
    }
}