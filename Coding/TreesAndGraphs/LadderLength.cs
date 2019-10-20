using System;
using System.Collections.Generic;
using System.Text;

public class WordLadderLength{
    public void Run(){
        var beginWord = "hit";
        var endWord = "cog";
        var wordList =new List<string> {"hot","dot","dog","lot","log","cog"};
        Console.WriteLine(LadderLength(beginWord,endWord, wordList));
    }

    public int LadderLength(string beginWord, string endWord, IList<string> wordList) {
        if(!wordList.Contains(endWord)) return 0;
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

        var queue=new Queue<Tuple<string,int>>();
        queue.Enqueue(new Tuple<string,int>(beginWord,1));

        var visited =new Dictionary<string,bool>();
        visited.Add(beginWord,true);

        while(queue.Count>0){
            var node = queue.Dequeue();
            var word = node.Item1;
            int level= node.Item2;

            for(int i=0; i < l;i++){
                 var newWord =new StringBuilder(word).Replace(word[i],'*', i, 1).ToString();;
                    if(dict.ContainsKey(newWord) && dict[newWord].Count>0){
                        foreach(var wd in dict[newWord]){
                            if(wd==endWord) return level+1;
                            if(!visited.ContainsKey(wd)){
                                visited.Add(wd, true);
                                queue.Enqueue(new Tuple<string,int>(wd,level+1));
                            }
                        }

                    }
            }
        }
        return 0;

    }
}
