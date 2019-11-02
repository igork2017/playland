/* using System;

public class Practice{
    public void Run
}

public class Solution {
    public string ReverseStr(string s, int k) {
        char[] result;
        var sArr=s.ToCharArray();
        if(s.Length<k){
           result = ReverseSubstring(sArr, 0, s.Length);          
        } 
        else{
            result = ReverseSubstring(sArr,0,k);
        }
        
        return new string(result);
    }
    
    private char[] ReverseSubstring(char[] arr, int start, int k){
        if((arr.Length-1-start)>k) return arr;
        var newIndex=start;
        var len=k-1;
        for(int i=newIndex;i<len;i++,len--){
            var temp=arr[i];
            arr[i]=arr[len];
            arr[len]=temp;
        }
        return ReverseSubstring(arr,start+k, k);
    }
}


public class Solution {
    private Dictionary<int,IList<int>> dict= new Dictionary<int,IList<int>>();
    public IList<IList<int>> CriticalConnections(int n, IList<IList<int>> connections) {
        foreach(var l in connections){
            if(!dict.ContainsKey(l[0])){
                dict.Add(l[0], new List<int>{l[1]});
            }
            else{
                dict[l[0]].Add(l[1]);
            }
        }
        
        var result =new List<IList<int>>();
        foreach(var key in dict.Keys){
            if(dict[key].Count==1){
                var brokenConnection=new List<int>{key, dict[key][0]};
                result.Add(brokenConnection);
            }
        }
       return result; 
    }
} */