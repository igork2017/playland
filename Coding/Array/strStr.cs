using System;

public class strStr{
    public void Run(){
        var haystack="aaaaall";
        var needle="ll";
        Console.WriteLine(StrStr(haystack,needle));
    }

    public int StrStr(string haystack, string needle) {
        if(needle=="") return 0;
        var haystackLenght=haystack.Length;
        var needleLenght=needle.Length;
        var lowHaystack=haystack.ToLower();
        var lowNeedle=needle.ToLower();
        if(needleLenght>haystackLenght) return -1;
        if(needleLenght==haystackLenght) return haystack.ToLower()==needle.ToLower()?0:-1;
        var diff= haystackLenght-needleLenght;
        for(int i=0; i<=diff;i++){
            
            if(lowHaystack.Substring(i,needleLenght)==lowNeedle) return i;
        }
        return -1;
    }
}