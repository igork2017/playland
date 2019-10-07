using System;
using System.Collections.Generic;

public class Anagrams{
    public void Run(){
        string[] strs =new string[] {"eat", "tea", "tan", "ate", "nat", "bat"};
        var result = GroupAnagrams(strs);
        foreach(var m in result){
            Console.WriteLine("new array:");
            foreach(var l in m){
                Console.WriteLine(l);
            }
        }
    }
    
    public IList<IList<string>> GroupAnagrams(string[] strs) {
        var list = new List<IList<string>>();
        var hashTable=new Dictionary<string, IList<string>>();
        foreach(var t in strs){
            var charArray=t.ToCharArray();
            Array.Sort(charArray);
            var sortedValue=new string(charArray);
            if(hashTable.ContainsKey(sortedValue)){
                 var arr= hashTable.GetValueOrDefault(sortedValue);
                 arr.Add(t);
                 hashTable[sortedValue]=arr;
            }
            else{
                hashTable.Add(sortedValue, new List<string>{t});
            }
        }
        foreach(var k in hashTable.Keys){
            list.Add(hashTable[k]);
        }
        return list;
    }
}