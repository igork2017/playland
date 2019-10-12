using System;
using System.Collections.Generic;

public static class MyExtensions{
     
    public static bool Search(string oldlist,List<string> newlist){
        if(oldlist.Length==0) return newlist.Count==7;
        
        /* for (int i=1;i<length; i++){
              var charToAnalize=oldlist.Length>=i?oldlist.Substring(0,i):"";
              if(charToAnalize.IsInTheRange() && charToAnalize.IsUniqueNumber(newlist)){
                  newlist.Add(charToAnalize);
                  var oldnewvalue=oldlist.Substring(i);
                  return Search(oldnewvalue, newlist);
              }
            else{
                  return false;
            }
              
        } */
        return false;
    }
    
    public static bool IsUniqueNumber(this string val, List<string> ar){
        return !ar.Contains(val);
    }
    
    public static bool IsInTheRange(this string val)
    {
        int result;
        Int32.TryParse(val, out result);
        return result>0 & result<60? true:false;
    }
    public static List<string> RemoveInvalidLength(this string[] t){
        var result = new List<string>();
        foreach(var s in t){
            if(s.Length>=7 & s.Length<=14){
                result.Add(s);
            }
        }
        return result;
    }

   
}
