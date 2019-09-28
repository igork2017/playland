using System;

public static class WinnerTicket{
    public static void GetTickets(){
        string[] strArray= {"1", "42", "100848", "4938532894754", "1234567", "472844278465445"};
        Console.WriteLine("Hello, World!");
        LotteryPics(strArray);
        Console.WriteLine("Done!");
    }

    private static void LotteryPics(string[] strarray){
       var m = strarray.RemoveInvalidLength().Filter();
        Console.WriteLine(m.Count);
        foreach(var t in m){
            Console.WriteLine(t);
        }
    }
}