using System;
using System.Collections.Generic;

public class LogSorting{
    public void Run(){
        var logs= new string[]{"dig1 8 1 5 1","let1 art can","dig2 3 6","let2 own kit dig","let3 art zero"};
        foreach(var t in ReorderLogFiles(logs)){
            Console.WriteLine(t);             
        }
    } 

    public string[] ReorderLogFiles(string[] logs) {
       Array.Sort(logs, (string log1,string log2) =>{
           var arrLog1= log1.Split(" ", 2);
           var arrLog2= log2.Split(" ", 2);
           var isDigit1= Int32.TryParse(arrLog1[1].Substring(0,1), out int x);
           var isDigit2= Int32.TryParse(arrLog2[1].Substring(0,1), out int y);
           if(!isDigit1 && !isDigit2){
               var comp = arrLog1[1].CompareTo(arrLog2[1]);
               if(comp!=0) return comp;
               return arrLog1[0].CompareTo(arrLog2[0]);
           }
           return isDigit1?(isDigit2?0:1):-1;
       });
       return logs;      
    }
}