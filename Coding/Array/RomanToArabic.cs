using System;
using System.Collections.Generic;
public class RomanToArabics{
    private Dictionary<char,int> CharValues=null;
    public void Run(){
      //  Console.WriteLine(RomanToArabic("III"));
      //  Console.WriteLine(RomanToArabic("IV"));
      //  Console.WriteLine(RomanToArabic("LVIII"));
     //   Console.WriteLine(RomanToArabic("IX"));        
        Console.WriteLine(RomanToArabic("MCMXCIV"));
    }

    public int RomanToArabic(string s){
        if (CharValues == null)
        {
            CharValues = new Dictionary<char, int>();
            CharValues.Add('I', 1);
            CharValues.Add('V', 5);
            CharValues.Add('X', 10);
            CharValues.Add('L', 50);
            CharValues.Add('C', 100);
            CharValues.Add('D', 500);
            CharValues.Add('M', 1000);
        }

        if(s.Length==0) return 0;
        s=s.ToUpper();

        var total=0;
        int last_value=0;
        for(int i=s.Length-1; i>=0; i--){
            int new_value=CharValues[s[i]];
            if(new_value<last_value){
                total-=new_value;
            }
            else{
                total+=new_value;
                last_value=new_value;
            }
        }
        return total;
    }
}