using System;
using System.Collections.Generic;

public class Parentheses{
    public void Run(){
        var result =GenerateParenthesis2(3);
        foreach(var r in result){
            Console.WriteLine(r);
        }
    }
    public IList<string> GenerateParenthesis2(int n) {
        List<string> ans = new List<string>();
        backtrack(ans,"",0,0,n);
        return ans;
    }

    public void backtrack(List<string> ans, string cur, int open, int close,int max){
        if(cur.Length==max*2){
            ans.Add(cur);
            return;
        }

        if(open<max){
            backtrack(ans,cur+"(",open+1,close,max);
        }
        if(close<open){
            backtrack(ans,cur+")",open, close+1,max);
        }
    }

    public List<String> generateParenthesis(int n) {
        List<string> ans = new List<string>();
        if (n == 0) {
            ans.Add("");
        } else {
            for (int c = 0; c < n; ++c)
                foreach (var left in generateParenthesis(c))
                    foreach (var right in generateParenthesis(n-1-c))
                        ans.Add("(" + left + ")" + right);
        }
        return ans;
    }
}