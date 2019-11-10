using System;

public class Solution {
    public string ValidIPAddress(string IP) {
        var ipv4="IPv4";
        var ipv6="IPv6";
        var none="Neither";
        if(!IP.Contains(".") && !IP.Contains(":")) return none;
        if(IP.Contains(".") && IP.Contains(":")) return none;
        if(IP.Contains(".")){
            var arr=IP.Split(".");
            if(arr.Length!=4) return none;
            foreach(var t in arr){
                if(!IsIntString(t)) return none;
                int num;
                if(!Int32.TryParse(t, out num)){
                    return none;
                }
                if(num <0 || num >255) return none;               
            }
            return ipv4;
        }
        if(IP.Contains(":")){
            var arr6=IP.Split(":");
            if(arr6.Length!=8) return none;
            foreach(var s in arr6){
                if(s.Length==0 || s.Length>4) return none;
                if(!IsHexString(s)) return none;
            }
            return ipv6;
        }
       return none;
    }
    
    public bool IsIntString(string val){
        if(val.Length==0 ) return false;
        if(val.Length>1 && val.Substring(0,1)=="0") return false;
        if(val.Contains("+") || val.Contains("-")) return false;
        return true;
    }
    public bool IsHexString(string value)
    {
        string hx = "0123456789ABCDEF";
        foreach (char c in value.ToUpper()) {
            if (!hx.Contains(c))
            return false;
        }
        return true;
    }
}