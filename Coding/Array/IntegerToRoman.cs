using System;
using System.Text;

public class IntegerToRoman{
    private string[] ThouLetters = { "", "M", "MM", "MMM" };
    private string[] HundLetters =  { "", "C", "CC", "CCC", "CD", "D", "DC", "DCC", "DCCC", "CM" };
    private string[] TensLetters = { "", "X", "XX", "XXX", "XL", "L", "LX", "LXX", "LXXX", "XC" };
    private string[] OnesLetters = { "", "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX" };
    public void Run(){
        Console.WriteLine(ArabicToRoman(3));
        Console.WriteLine(ArabicToRoman(4));
        Console.WriteLine(ArabicToRoman(9));
        Console.WriteLine(ArabicToRoman(58));
        Console.WriteLine(ArabicToRoman(1994));
    }
    private string ArabicToRoman(int arabic){
        var sb = new StringBuilder();
        if(arabic>3999) return "";

        int num;
        num=arabic/1000;
        sb.Append(ThouLetters[num]);
        arabic %= 1000;

        num=arabic/100;
        sb.Append(HundLetters[num]);
        arabic %= 100;

        num=arabic/10;
        sb.Append(TensLetters[num]);
        arabic %= 10;

        sb.Append(OnesLetters[arabic]);

        return sb.ToString(); 
    }
}