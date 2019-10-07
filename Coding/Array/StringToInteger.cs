using System;
using System.Collections.Generic;
using System.Text;
public static class StringToInteger{
    
    public static void Run(){
        var input1="     3434 alsdkjfld";
        var input2="   -42";
        var input3="4193 with words";
        var input4="words and 987";
        var input5= "-91283472332";
        var result = MyAtoi(input1);
        Console.WriteLine(result);
        Console.WriteLine(MyAtoi(input2));
        Console.WriteLine(MyAtoi(input3));
        Console.WriteLine(MyAtoi(input4));
        Console.WriteLine(MyAtoi(input5));
        Console.WriteLine(MyAtoi("+"));
    }   
    public static int? MyAtoi(string str) { 
        bool hasNumber=false;
        bool isNegative=false;
        var minus='-';
        var plus='+';
        var stringBuilder = new StringBuilder();
        for(int i=0;i<str.Length;i++){
            var candidate=str[i];
           
            if(candidate==' ' && stringBuilder.Length==0) continue;
            if((candidate==minus || candidate==plus) && stringBuilder.Length==0){
                stringBuilder.Append(candidate); 
                if(candidate==minus) isNegative=true;
                continue;              
            }
            int intValue;
            if(Int32.TryParse(candidate.ToString(), out intValue)){
                stringBuilder.Append(candidate);
                hasNumber=true;
            }
            else{
                break;
            }
        }
        var arabic =8;
        var t= arabic/1000;
        arabic %=1000;
        if(stringBuilder.Length>0 && hasNumber){
            int result;
            if(Int32.TryParse(stringBuilder.ToString(), out result)){
                return result;
            }
            else{                
                if(isNegative) return Int32.MinValue;
                return Int32.MaxValue;
            }
        }
        return 0;
    }
}


