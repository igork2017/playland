using System;

public class ReverseString2{
    public void Run(){
        var input = "hyzqyljrnigxvdtneasepfahmtyhlohwxmkqcdfehybknvdmfrfvtbsovjbdhevlfxpdaovjgunjqlimjkfnqcqnajmebeddqsgl";     
       /*  var input="abcd"; */
      /*  var input="abcdefg"; */
        var k=39;
        Console.WriteLine(ReverseStr(input,k));
    }

    public string ReverseStr2(string s, int k){
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

    private char[] ReverseSubstring(char[] arr, int index, int k){
        var length=arr.Length;
        var m=k;
        if(length-index < k) return arr;
        if(length-(index+k) < 2*k) m=length-(index+k);

        var len=m-1;
        for(int i=index;i<(len+index);i++,len--){
            var temp=arr[i];
            arr[i]=arr[len+index];
            arr[len+index]=temp;
        }

        return ReverseSubstring(arr,index+2*k, k);
    }

    private string ReverseStr(string s, int k){
        char[] a = s.ToCharArray();
        for (int start = 0; start < a.Length; start += 2 * k) {
            int i = start, j = Math.Min(start + k - 1, a.Length - 1);
            while (i < j) {
                char tmp = a[i];
                a[i++] = a[j];
                a[j--] = tmp;
            }
        }
        return new String(a);
    }

 /*    "fdcqkmxwholhytmhafpesaentdvxginrjlyqzyh 
     ehybknvdmfrfvtbsovjbdhevlfxpdaovjgunjql
     lgsqddebemjanqcqnfkjmi" */
}