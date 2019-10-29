using System;

public class BestTimeToBuyAndSell{
    public void Run(){
        var input = new int[]{7,1,5,3,6,4};
        Console.WriteLine(MaxProfit(input));
    }

    public int MaxProfit(int[] prices) {
        var minPrice = Int32.MaxValue;
        var maxProfit=0;
        for(int i=0;i<prices.Length;i++){
            if(minPrice>prices[i]) minPrice=prices[i];
            else if(prices[i]-minPrice>maxProfit) maxProfit=prices[i]-minPrice;            
        }
        return maxProfit;
    }
}