using System;
using System.Collections.Generic;

public class CoinChangeT{
    public void Run(){
        var coins= new int[]{1, 2, 5};
        var amount = 11;
        Console.WriteLine(CoinChange_DP_TD(coins,amount));
    }

    public int CoinChange_DP_TD(int[] coins, int amount) {
        if(amount==0) return 0;
        return Calc(coins, 0, amount);
    }

    public int CoinChangeBruteForce(int[] coins, int amount) {
        if (amount < 1) return 0;
        return coinChange(coins, amount, new int[amount]);
    }

    private int coinChange(int[] coins, int rem, int[] count) {
        if (rem < 0) return -1;
        if (rem == 0) return 0;
        if (count[rem - 1] != 0) return count[rem - 1];
        int min = Int32.MaxValue;
        foreach (var coin in coins) {
            int res = coinChange(coins, rem - coin, count);
            if (res >= 0 && res < min)
                min = 1 + res;
        }
        count[rem - 1] = (min == Int32.MaxValue) ? -1 : min;
        return count[rem - 1];
    }
    private int Calc(int[] coins, int cur, int amount){
        if(amount==0) return 0;
        if(cur < coins.Length && amount>0){
            var maxVal= amount/coins[cur];
            var minCost = Int32.MaxValue;
            for(int x=0;x<=maxVal;x++){
                if (amount >= x * coins[cur]) {
                    int res = Calc(coins,cur + 1, amount - x * coins[cur]);
                    if (res != -1)
                        minCost = Math.Min(minCost, res + x);
                }  
            }
            return (minCost == Int32.MaxValue)? -1: minCost; 
        }
        return -1;
    }
}