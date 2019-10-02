using System;
using System.Collections.Generic;

public static class TrimpleSteps{
    public static void Run(){
        var dict = new Dictionary<int, int> ();
        Console.WriteLine(StepsCount(1));
        Console.WriteLine(StepsCount(2));
        Console.WriteLine(StepsCount(3));
        Console.WriteLine(StepsCount(4));
        Console.WriteLine(StepsCount(5));
        Console.WriteLine(StepsCount2(5,dict));
    }

    private static int StepsCount(int x)
    {
        if(x < 0) return 0;
        if(x==0) return 1;
        return StepsCount(x-1) + StepsCount(x-2) + StepsCount(x-3);
    }

    private static int StepsCount2(int x, Dictionary<int, int> dict){
        if(x<0) return 0;
        if(x==0) return 1;
        if(dict.ContainsKey(x) && dict[x]>-1) return dict[x];
        dict[x]= StepsCount2(x-1, dict) + StepsCount2(x-2, dict) + StepsCount2(x-3, dict) ;
        return dict[x];
    }
}