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
    
    private static int[] PatternGenerator(int doubleDigits, int singleDigits){
        var arr=new int[7];
        for(int i=0;i<doubleDigits;i++){
            arr[i]=2;
        }
        for(int j=doubleDigits;j<singleDigits;j++){
            arr[j]=1;
        }
        return arr;
    }

    private static int[] ShiftArray(int[] patternArray){
        var length=patternArray.Length;
        var last=patternArray[length-1];
        for(int i=length-2;i<1;i--){
            patternArray[i+1]=patternArray[i];
        }
        patternArray[0]=last;
        return patternArray;
    }
    private static int[] GetTicket(string origin){
        var originLength=origin.Length;
        var ticketLength=7;
        //check out if string is out of range
        if(originLength<7 || originLength>14){
            return null;
        }

        int doubleDigits = originLength % ticketLength;
        int singleDigits= originLength-doubleDigits;
        var patternArray= PatternGenerator(doubleDigits, singleDigits);
        int index=0;
        var checkList=new List<int>();
        int candidate;
        
        for(int i=0;i<patternArray.Length;i++){
            var subValue=patternArray[i];
            Int32.TryParse(origin.Substring(index,subValue), out candidate);

            index=index+subValue;
        }
        
        return null;
    }
}