using System;
public static class FizzFuzz{
    public static void Run(int x){
        
        for(int i=1;i<=x-1;i++){
            if(i%3==0 && i%5==0) Console.WriteLine("FizzFuzz");
            if(i%3==0) Console.WriteLine("Fizz");
            if(i%5==0) Console.WriteLine("Fuaa");
            else Console.WriteLine(i.ToString());
        }
    }
}