using System;
using System.Collections.Generic;

public class MostCommonWords{
    public void Run(){
        var paragraph = "a.";
        var banned =new string []{"hit"};
       Console.WriteLine(MostCommonWord(paragraph, banned));
    }

    public string MostCommonWord(string paragraph, string[] banned){
        var punctuation=new string[]{"!","?","'",",",";","."};
        if(paragraph.Length==0) return "";
        var paraArray=paragraph.Split(" ");
        var dict= new Dictionary<string,int>();

        var length = paraArray.Length;
        if(length==1) return RemovePunctuation(paraArray[0].Trim().ToLower(), punctuation);
        for(int i=0;i<paraArray.Length;i++){
            var t=paraArray[i].Trim().ToLower();
            t=RemovePunctuation(t,punctuation);
            if(IsBanned(t, banned)) continue;
            if(dict.ContainsKey(t)){
                dict[t]= dict[t]+1;
            }
            else{
                dict.Add(t, 1);
            }
        }
        int max=0;
        var result="";
        foreach(var k in dict.Keys){
            if(max<dict[k]){
                max=dict[k];
                result=k;
            }
        }
        return result;
    }

    public static string RemovePunctuation(string word, string[] punc){
        var result=word;
        foreach(var s in punc){
            var index=word.IndexOf(s);
            if(index>0)
                result = word.Remove(index);
        }
        return result;
    }

    public static bool IsBanned(string word, string[] banned){
        foreach(var m in banned){
            if(m==word)
              return true;
        }
        return false;
    }

    public string mostCommonWord2(string paragraph, string[] banned){
        paragraph += ".";

        Set<String> banset = new HashSet();
        for (String word: banned) banset.add(word);
        Map<String, Integer> count = new HashMap();

        String ans = "";
        int ansfreq = 0;

        StringBuilder word = new StringBuilder();
        for (char c: paragraph.toCharArray()) {
            if (Character.isLetter(c)) {
                word.append(Character.toLowerCase(c));
            } else if (word.length() > 0) {
                String finalword = word.toString();
                if (!banset.contains(finalword)) {
                    count.put(finalword, count.getOrDefault(finalword, 0) + 1);
                    if (count.get(finalword) > ansfreq) {
                        ans = finalword;
                        ansfreq = count.get(finalword);
                    }
                }
                word = new StringBuilder();
            }
        }

        return ans;
    }
}