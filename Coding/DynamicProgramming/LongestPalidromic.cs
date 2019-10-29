using System;
using System.Collections.Generic;

public class LongestPalidromic{
    public void Run(){
        var input="";
        Console.WriteLine(LongestPalindrome(input));
    }
    public string LongestPalindrome(string s) {
        if(s.Length<1) return "";
        int maxLength = 1; 
  
        int start = 0;  
        int len = s.Length;  
    
        int low, high;  
    
        for (int i = 1; i < len; ++i)  
        {  
            // Find the longest even length palindrome  
            // with center points as i-1 and i.  
            low = i - 1;  
            high = i;  
            while (low >= 0 && high < len && s[low] == s[high])  
            {  
                if (high - low + 1 > maxLength)  
                {  
                    start = low;  
                    maxLength = high - low + 1;  
                }  
                --low;  
                ++high;  
            }  
    
            // Find the longest odd length palindrome with center  
            // point as i  
            low = i - 1;  
            high = i + 1;  
            while (low >= 0 && high < len && s[low] == s[high])  
            {  
                if (high - low + 1 > maxLength)  
                {  
                    start = low;  
                    maxLength = high - low + 1;  
                }  
                --low;  
                ++high;  
            }  
        }    
        return s.Substring(start,maxLength);  
    }

    private int ExpandAroundCenter(String s, int left, int right) {
        int L = left, R = right;
        while (L >= 0 && R < s.Length && s[L] == s[R]) {
            L--;
            R++;
        }
        return R - L - 1;
    }

    void printSubStr(string str, int low, int high)  
    {      
        Console.WriteLine(str.Substring(low,high));  
    }  
}