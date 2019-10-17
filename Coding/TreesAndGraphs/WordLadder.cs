using System;
using System.Collections.Generic;
using System.Text;

public class WordLadder{
    public void Run(){
        var beginWord = "hit";
        var endWord = "cog";
        var wordList =new List<string> {"hot","dot","dog","lot","log","cog"};
/*         var beginWord = "leet";
        var endWord = "code";
        var wordList =new List<string> {"lest","leet","lose","code","lode","robe","lost"}; */
        var result = FindLadders(beginWord, endWord, wordList);
        if(result!=null && result.Count>0){
            foreach(var s in result){
                Console.WriteLine("new: ");
                foreach( var t in s){
                    Console.WriteLine(t);
                }                
            }
        }
    }

        //  Use DFS (backtracking) to generate the transformation sequences according to the mapping
    void buildLadders(string beginWord, string endWord,  IList<string> ladder,  IList<IList<string>> ladders,
                      Dictionary<string, IList<string>> children) {
        if (beginWord == endWord) {
            ladders.Add(ladder);
        } else {
            foreach (string word in children[beginWord]) {
                ladder.Add(word);
                buildLadders(word, endWord, ladder, ladders, children);
                // ladder.pop_back();
            }
        }
    }

    public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList){
       /*  unordered_set<string> dict(wordList.begin(), wordList.end());
        if (dict.Contains(endWord))
            return {}; */
        var children=new Dictionary<string, IList<string>>();
        if (!findEndWordByBFS(beginWord, endWord, wordList, children))
            return null;
        var ladders =  new List<IList<string>>();
        var ladder =new List<string>();
        ladder.Add(beginWord);
        buildLadders(beginWord, endWord, ladder, ladders, children);
        return ladders;
    }

    bool findEndWordByBFS(string beginWord, string endWord, IList<string> wordList, Dictionary<string, IList<string>> children) {
        var dict = wordList;
        var current = new List<string>();
        var next =new List<string>();
        current.Add(beginWord);
        while (true) {
            foreach (string word in current) {
                dict.Remove(word);
            }
            
            foreach (string word in current) {
                string parent = word;
                for (int i = 0; i < word.Length; i++) {
                    char t = word[i];
                    for (char c='a'; c<='z'; c++) {
                        var newString = new StringBuilder(word).Replace(word[i],c, i, 1).ToString();
                        if (dict.Contains(newString)) {
                            next.Add(newString);
                            var list=new List<string>();
                            list.Add(newString);
                            children.Add(parent, list);
                        }
                    }
                }
            }
            
            if (next.Count==0)
                return false;
            
            if (!next.Contains(endWord))
                return true;
            current.Clear();
            current.AddRange(next);
            next.Clear();
        } 
        
        return false;
    }
}