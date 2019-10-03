using System;
using System.Collections.Generic;

public static class WinnerTicket{
    public static void GetTickets(){
        string[] strArray= {"1", "42", "100848", "4938532894754", "1234567", "472844278465445"};
        LotteryPics(strArray);
        Console.WriteLine("Done!");
    }

    private static void LotteryPics(string[] strarray){
       var m = strarray.RemoveInvalidLength();
        Console.WriteLine(m.Count);
        foreach(var t in m){
            var list=new List<string>();
            Console.WriteLine(t);
        }
    }

    private static bool Checkout(List<int> result, string charN) {
        int intN;
        Int32.TryParse(charN, out intN);
        if(!result.Contains(intN) && intN>0 && intN<60 && result.Count<7){
            result.Add(intN);
            return true;
        }

        return false;
    }

    private static bool GetTheNumber(List<int> result, int start, int end, string numberString){
        var charN= numberString.Substring(start,start+1);
        var isValid = Checkout(result, charN );
         if(isValid && start < end){
            GetTheNumber(result, start+1, end , numberString);
         } 
        return false;            
    }
}