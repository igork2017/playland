using System;
using System.Collections.Generic;

public class ValidParentheses{
    public void Run(){
        Console.WriteLine(IsValid(""));
    }
    private string parentheses="(){}[]";
    private bool IsValid(string s)
    {
        if(s.Length==0) return true;
        if(s.Length==1) return false;
        
        var t=s.Substring(0,1);
        var index=parentheses.IndexOf(t);
        var listOpenIndex=new List<int>();
        if(index%2>0){ 
            return false;
        }
        else{            
             listOpenIndex.Add(index);
        }
        for(int i=1;i<s.Length;i++){
            t=s.Substring(i,1);
            var openCount=listOpenIndex.Count;
            index=parentheses.IndexOf(t);
            if(index%2>0){ 
                if(parentheses.Substring(index-1,1) == s.Substring(i-1,1) || listOpenIndex[openCount-1]==index-1){
                    listOpenIndex.RemoveAt(openCount-1);
                }
                else{
                    return false;
                }
            }
            else{
                listOpenIndex.Add(index);
            }
        }
        return listOpenIndex.Count==0;
    }
}