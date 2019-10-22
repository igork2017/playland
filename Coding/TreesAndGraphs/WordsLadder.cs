using System;
using System.Collections.Generic;
using System.Text;

public class WordsLadder{
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

    public IList<IList<string>> FindLadders(string beginWord, string endWord, List<string> wordList) {
        var result = new List<IList<string>>();
    
        if(!wordList.Contains(endWord)) return result;
            
        wordList.Remove(beginWord);

        var l= beginWord.Length;
        var dict= new Dictionary<string, IList<string>>();
        foreach(var w in wordList){
            for(int j=0; j < l;j++){
                var newWord=new StringBuilder(w).Replace(w[j],'*', j, 1).ToString();
                var transformations= dict.ContainsKey(newWord)? dict[newWord]:new List<string>();
                transformations.Add(w);
                if(dict.ContainsKey(newWord))
                {
                    dict[newWord]=transformations;
                }
                else{
                    dict.Add(newWord, transformations);
                }
            }
        }
        var dict2= new Dictionary<string, IList<string>>();
        var visited=new Dictionary<string, IList<string>>();
        var check = new List<string>();
        CreateGraph(beginWord,endWord,dict,visited,check);
        return pathsInGraph(beginWord, endWord, visited, check.Count-1);
    }
    
    void CreateGraph(string start, string end, Dictionary<string,IList<string>> dict, Dictionary<string,IList<string>> visited, List<string> check){
        var l= start.Length;
        if(!check.Contains(start)) check.Add(start);
        for(int i=0; i < l;i++){
                 var newWord =new StringBuilder(start).Replace(start[i],'*', i, 1).ToString();
                    if(dict.ContainsKey(newWord) && dict[newWord].Count>0){
                        foreach(var wd in dict[newWord]){
                            if(check.Contains(wd)) continue;

                            if(!visited.ContainsKey(wd)) {
                                visited.Add(wd, new List<string>{start});                               
                            }
                            else {
                                visited[wd].Add(start);
                            }
                            if(wd==end) return;
                            
                            CreateGraph(wd,end,dict,visited, check);
                        }
                        
                    }
            }
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
    
    public class WordsLadde_FirstVersion{
        public IList<IList<string>> FindLadders(string beginWord, string endWord, IList<string> wordList) {
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
    
        return result;
    }  
    
    IList<string> getChildren2(string s, IList<string> dict) {
        var result=new List<string>();
        for (int i=0; i<s.Length; i++) {
            //var t= s.Substring(i,1);
            for (char c='a'; c<='z'; c++) {
                var newString = new StringBuilder(s).Replace(s[i], c, i, 1).ToString();
                if (dict.Contains(newString))
                    result.Add(newString);
            }
        }
        return result;
    }
    
    IList<IList<string>> pathsInGraph(string start, string end, Dictionary<string, IList<string>> graph, int depth) {
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
    }
}