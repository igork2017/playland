using System;
using System.Collections.Generic;

public class TimeMapClass{
    
    public void Run(){}

    public class TimeMap {
       
        public Dictionary<int, string> dictTime;
        public Dictionary<string, IList<int>> dictKey;
    /** Initialize your data structure here. */
        public TimeMap() {
            dictTime=new Dictionary<int, string>();
            dictKey=new Dictionary<string, IList<int>>();
        }
    
    public void Set(string key, string value, int timestamp) {
        if(dictKey.ContainsKey(key)) dictKey[key].Add(timestamp);
        else{
            var t=new List<int>{timestamp};
            dictKey.Add(key,t);
        }
        if(dictTime.ContainsKey(timestamp)) dictTime[timestamp]=value;
        else dictTime.Add(timestamp,value);
    }
    
    public string Get(string key, int timestamp) {
        if(!dictKey.ContainsKey(key)) return "";
        var timeList=dictKey[key];
        var max=0;
        for(int i=(timeList.Count-1);i>=0;i--){
            if(timeList[i]<=timestamp){
                 max=timeList[i];
                 break;
            }
        }
        if(max==0) return "";
        if(dictTime.ContainsKey(max)) return dictTime[max];
        return "";
    }
}
}