using System;


public class DietPlan{
    public void Run(){
/*         var calories= new int[]{6,13,8,7,10,1,12,11};
        var k=6;
        var lower=5;
        var upper=37; */
        var calories= new int[]{1,2,3,4,5};
        var k=1;
        var lower=3;
        var upper=3;
        Console.WriteLine(DietPlanPerformance2(calories,k,lower,upper));
    }
/*     public int DietPlanPerformance(int[] calories, int k, int lower, int upper) {
        var total=0;
        for(int start=0;start<calories.Length-(k-1);start++){
            var cal=0;
            var j=Math.Min(start+k,calories.Length);
            if(start==0){
                for(int i=start;i<j;i++){
                    cal=cal+calories[i];
                }
            }
            else{
                cal=cal-calories[start-1]+calories[j];
            }
            
            if(cal<lower) total--;
            if(cal>upper) total++;
        }
        return total;
    } */

    public int DietPlanPerformance2(int[] calories, int k, int lower, int upper) {
        var total=0;
        var length=calories.Length;
        var start=0;
        var end=k;
        var cal=0;
        while(end<=length){
            if(start==0){
                for(int i=start;i<end;i++){
                    cal=cal+calories[i];
                }
            }
            else{
                cal=cal-calories[start-1]+calories[end-1];
            }
            if(cal<lower) total--;
            if(cal>upper) total++;
            start++;
            end++;
        }
        return total;
    }

   
}