using System;
using System.Collections.Generic;

public class WinnerTicket{

    public void Run(){
       string[] strArray= {"1", "42", "100848", "4938532894754", "1234567", "472844278465445"};
       //string[] strArray= {"4938532894754"};
        var ticketLength=7;
        var result=FindTicket(strArray,ticketLength);
        foreach(var list in result){
            Console.WriteLine("New number");

            foreach(var num in list)
                Console.WriteLine(num);
        }

    }

    public IList<IList<int>> FindTicket(string[] strarray, int length){
        var result =new List<IList<int>>();
        if(strarray.Length==0) return result;
        foreach(var s in strarray){
            if(s.Length<7 || s.Length>14) continue;
            var uniqueList=new List<int>();
           if(CreateTree(s, uniqueList))
              result.Add(uniqueList);
        }
        return result;
    }

    public bool CreateTree(string word, List<int> list){
        if(list.Count==7 && word.Length==0) return true;
        var result = false;
        var useDouble = word.Length<2? false:true;
        int left;
        int right;
        if(Int32.TryParse(word.Substring(0,1),out left)){       
            var newWord=word.Substring(1);
            var isValid=!list.Contains(left) && list.Count<7;
            if(isValid){
                 list.Add(left);   
                 result=CreateTree(newWord, list);
                 if(!result){
                     list.Remove(left);
                    }
                else{
                    return true;
                }
            }                
        }
        if(useDouble && Int32.TryParse(word.Substring(0,2),out right)){       
            var newWord=word.Substring(2);
            var isValid= right<60! && !list.Contains(right) && list.Count<7;
            if(isValid){
                 list.Add(right);   
                 result=CreateTree(newWord, list);
                 if(!result){
                     list.Remove(right);
                    }
                else{
                    return true;
                }
            }    
               
        }
       return false; 
    }

}