using System;
using System.Collections.Generic;

public class LetterComb{
    Dictionary<string,string[]> Buttons=new Dictionary<string,string[]>{
       {"2", new string[] {"a","b","c"}},
       {"3", new string[] {"d","e","f"}},
       {"4", new string[] {"g","h","i"}},
       {"5", new string[] {"j","k","l"}},
       {"6", new string[] {"m","n","o"}},
       {"7", new string[] {"p","q","r","s"}},
       {"8", new string[] {"t","u","v"}},
       {"9", new string[] {"w","x","y","z"}}
    };
    public void Run(){        
        var input ="22";
        foreach(var t in LetterCombinations(input))
            Console.WriteLine(t);
    }
    public IList<string> LetterCombinations(string digits) {
        var result = new List<string>();
        var digitArray=digits.ToCharArray();
        if(digitArray.Length==0) return result;
        var numbers=new List<string[]>();
        foreach(var c in digitArray)
        {
            var dig=c.ToString();
            if(Buttons.ContainsKey(dig)){
                numbers.Add(Buttons[dig]);
            }
        }
        if(numbers.Count==0) return result;
        var oneArray=numbers[0];
        if(numbers.Count==1) return oneArray;
        
        
        foreach(var n in oneArray){
             bsf(n.ToString(),numbers,result, 1);
        }
        return result;
    }
    
    public void bsf(string input, List<string[]> numbers, List<string> result,int level){
        if(numbers.Count==level) return;
        
        var numberArray= numbers[level];
       
        foreach(var n in numberArray){            
             var cur= $"{input}{n}";
             if(level == numbers.Count-1){
                 result.Add(cur);
             }            
             bsf(cur,numbers,result, level+1);
        }        
    }
}