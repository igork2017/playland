using System;
using System.Collections.Generic;

public static class WinnerTicket{
    public static void GetTickets(){
        string[] strArray= {"1", "42", "100848", "4938532894754", "1234567000000", "472844278465445"};
        LotteryPics(strArray);
        Console.WriteLine("Done!");
    }

    private static void LotteryPics(string[] strarray){
       var m = strarray.RemoveInvalidLength();
        foreach(var t in m){
            var list=new List<int>();
            Console.WriteLine(t);
            var result = GetTheNumber(list,t,1);
            if(result){
                foreach(var l in list)
                    Console.WriteLine(l);
            }
        }
    }

    private static bool Checkout(List<int> result, int candidate) {
        if(!result.Contains(candidate) && candidate>0 && candidate<60){
            return true;
        }
        return false;
    }
    private static void Remove(List<int> result , string charN){
         int intN;
        Int32.TryParse(charN, out intN);
        if(result.Contains(intN)){
            result.Remove(intN);
        }
    }
    private static bool GetTheNumber(List<int> result, string numberString, int step){
        if(numberString.Length==0){
            if(result.Count ==7){
                return true;
            }
            else{
                return false;
            }
        }

        if(numberString.Length<step) return false;
        
        bool isValid=false; 
        int candidate;
        Int32.TryParse(numberString.Substring(0,step), out candidate);
        isValid=Checkout(result, candidate);
        if(isValid){
            result.Add(candidate);
            var newString=numberString.Substring(step,numberString.Length-step);
            isValid=GetTheNumber(result, newString, 1);
        }
        if(!isValid){
            result.Remove(candidate);
            isValid= GetTheNumber(result, numberString, 2);
        }
        return isValid;            
    }
}