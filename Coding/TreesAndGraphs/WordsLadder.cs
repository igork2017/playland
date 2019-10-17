using System;
using System.Collections.Generic;
using System.Text;

public class WordsLadder{
    public void Run(){
/*         var beginWord = "hit";
        var endWord = "cog";
        var wordList =new List<string> {"hot","dot","dog","lot","log","cog"}; */
        var beginWord = "leet";
        var endWord = "code";
        var wordList =new List<string> {"lest","leet","lose","code","lode","robe","lost"};
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

    public IList<IList<string>> FindLadders(string beginWord, string endWord, List<string> wordList) {
        var result = new List<IList<string>>();
        var unvisited=wordList;
        if(!unvisited.Contains(endWord)) return result;
        unvisited.Remove(beginWord);   
        
        var graph=new Dictionary<string, IList<string>>();

        var que1=new List<string>();
        var que2=new List<string>();
        que1.Add(beginWord);
        int len=0;

        while(!(unvisited.Count==0) && !(que1.Count==0)){
            foreach(var w in que1){
                var children=getChildren2(w, unvisited);
                foreach(var child in children){
                    if(!graph.ContainsKey(child)){
                        var list=new List<string>();
                        list.Add(w);
                        graph.Add(child, list);
                        que2.Add(child);
                    }
                    else{
                        graph[child].Add(w);
                    }
                    
                }
            }
            len++; 
            if (que2.Contains(endWord))  
               break;
            que1.Clear();  
            que1.AddRange(que2);          
            foreach (var w in que2) unvisited.Remove(w);
            que2.Clear();         
        }
      
        if (que1.Count==0) return new List<IList<string>>();
        return pathsInGraph(beginWord, endWord, graph, len);
    }
    
    private IList<IList<string>> pathsInGraph(string start, string end, Dictionary<string, IList<string>> graph, int depth) {
        var rslt = new List<IList<string>>();
        if (depth==0 || !graph.ContainsKey(end)) return rslt;
        if (depth==1) {
            rslt.Add(new List<string>{start, end});
            return rslt;
        }
        foreach (var w in graph[end]) {
            var paths = pathsInGraph(start, w, graph, depth-1);
            foreach (var v in paths) {
                v.Add(end);
                rslt.Add(v);
            }
        }
        return rslt;
    }
    IList<string> getChildren2(string s, IList<string> dict) {
        var result=new List<string>();
        for (int i=0; i<s.Length; i++) {
            var t= s.Substring(i,1);
            for (char c='a'; c<='z'; c++) {
                var newString = new StringBuilder(s).Replace(s[i], c, i, 1).ToString();
                if (dict.Contains(newString))
                    result.Add(newString);
            }
        }
        return result;
    }

}