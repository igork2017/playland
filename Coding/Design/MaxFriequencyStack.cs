using System;
using System.Collections.Generic;

public class MaxFriequencyStack{
    public void Run(){}

}

class FreqStack {
    Dictionary<int, int> freq;
    Dictionary<int, Stack<int>> group;
    int maxfreq;

    public FreqStack() {
        freq = new Dictionary<int, int>();
        group = new Dictionary<int, Stack<int>>();
        maxfreq = 0;
    }

    public void Push(int x) {
        var f=1;
        if(freq.ContainsKey(x)){
            f=freq[x]+1;
            freq[x]=f;
        }
        else{
            freq.Add(x, f);
        }
        
        if (f > maxfreq)
            maxfreq = f;
        if(!group.ContainsKey(f)) group[f]=new Stack<int>();
        group[f].Push(x);
    }

    public int Pop() {
        int x = group[maxfreq].Pop();
        if(freq.ContainsKey(x)){
            var newVal=freq[x]-1;
            freq[x]=newVal;
        }
      
        if (group[maxfreq].Count == 0)
            maxfreq--;
        return x;
    }
}