using System;
using System.Collections.Generic;


public class Solution15 {
    public void Run(){
        var input = new string[]{"cat","bt","hat","tree"};
        var chars="atach";
        Console.WriteLine(CountCharacters(input, chars));
    }
    public int CountCharacters(string[] words, string chars) {
        var result=0;
        var n = words.Length;
        var c= chars.Length;
       
        var dictChars=new Dictionary<char,int>();
        for(int i=0;i<c;i++){
            if(dictChars.ContainsKey(chars[i])) dictChars[chars[i]]++;
            else dictChars.Add(chars[i], 1);
        }
        
        foreach(var w in words){
           var isGood=true;   
            var dictWord=new Dictionary<char,int>();
            for(int j=0;j<w.Length;j++){
               
                if(dictWord.ContainsKey(w[j])) dictWord[w[j]]++;
                else dictWord.Add(w[j], 1);
                if(!dictChars.ContainsKey(w[j]) || dictWord[w[j]]>dictChars[w[j]]){
                    isGood=false;
                    break;
                }   

            }
           if(isGood){
              result=result + w.Length;
           }
          
        }
        return result;
    }
}