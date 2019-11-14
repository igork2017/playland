using System;
using System.Collections.Generic;

public class LongestSubstringWithoutRepeating{
    public void Run(){
        var input="abcbbcbb";
        Console.WriteLine(LengthOfLongestSubstring(input));
    }
    public int LengthOfLongestSubstring(string s) {
        var max=0;
        var list = new List<char>();
        var i=0;
        var j=0;
        
        while(j<s.Length){
            if(!list.Contains(s[j])){
                list.Add(s[j]);
                j++;
                max=Math.Max(max, j-i);
            }
            else{
                list.Remove(s[i]);
                i++;
            }
        }
        return max;
    }

}