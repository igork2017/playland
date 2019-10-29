using System;
using System.Collections.Generic;

public class WordBreak{
    public void Run(){
        var s = "applepenapple";
        var wordDict = new List<string>{"apple", "pen"};
/*         var s = "catsandog";
        var wordDict = new List<string>{"cats","dog","sand","and","cat"}; */

        Console.WriteLine(WordBreak_DP(s,wordDict));
    }

    public bool WordBreak_DP(string s, IList<string> wordDict) {
        var wordDictSet=wordDict;
        var dp = new bool[s.Length + 1];
        dp[0] = true;
        for (int i = 1; i <= s.Length; i++) {
            for (int j = 0; j < i; j++) {
                if (dp[j] && wordDictSet.Contains(s.Substring(j, i-j))) {
                    dp[i] = true;
                    break;
                }
            }
        }
        return dp[s.Length];
    }
    public bool WordBreak_BFS(string s, IList<string> wordDict) {
        var wordDictSet= wordDict;
        var queue = new Queue<int>();
        int[] visited = new int[s.Length];
        queue.Enqueue(0);
        while (queue.Count>0) {
            int start = queue.Dequeue();
            if (visited[start] == 0) {
                for (int end = start+1; end <= s.Length; end++) {
                    if (wordDictSet.Contains(s.Substring(start, end-start))) {
                        queue.Enqueue(end);
                        if (end == s.Length) {
                            return true;
                        }
                    }
                }
                visited[start] = 1;
            }
        }
        return false;
    }

    public bool WordBreakBruteForce(string s, IList<string> wordDict) {
        return word_Break(s, wordDict, 0);
    }
    public bool word_Break(String s, IList<string> wordDict, int start) {
        if (start == s.Length) {
            return true;
        }
        for (int end = 0; end <= s.Length-start; end++) {
            if (wordDict.Contains(s.Substring(start, end)) && word_Break(s, wordDict, start+end)) {
                return true;
            }
        }
        return false;
     }
}