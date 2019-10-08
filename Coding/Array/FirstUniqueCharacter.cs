using System;
using System.Collections.Generic;

public class FirstUniqueCharacter{
    public void Run(){
        var input = "loveleetcode";
        Console.WriteLine(FirstUniqChar(input));
        Console.WriteLine(FirstUniqChar2(input));
    }

    public int FirstUniqChar(string s) {
        var sam=s.Trim().ToCharArray();
        var length=s.Length;
        if(length==0) return -1;
        if(length==1) return 0;
        var index=length;
        Array.Sort(sam);
        for(int i=1;i<length-1; i++){
            if(sam[i]!=sam[i+1] && sam[i]!=sam[i-1]){
                var t=s.IndexOf(sam[i]);
                if(t<index){
                    index=t;
                }
            }
        }
        if(sam[length-1]!=sam[length-2]){
            var m=s.IndexOf(sam[length-1]);
            if(m<index)
              index=m;
        }
        if(sam[0]!=sam[1]){
            var m=s.IndexOf(sam[0]);
            if(m<index)
              index=m;
        }
        return index<length?index:-1;
    }

    public int FirstUniqChar2(string s) {
        var length=s.Length;
        var dict=new Dictionary<string, int>();
        for(int i=0; i<length; i++){
            var ch=s.Substring(i,1);
            if(dict.ContainsKey(ch)){
                dict[ch]+=1;
            }
            else{
                dict.Add(ch,1);
            }
        }
        foreach(var k in dict.Keys){
            if(dict[k]==1){
                return s.IndexOf(k);
            }
        }
        return -1;
    }
}
