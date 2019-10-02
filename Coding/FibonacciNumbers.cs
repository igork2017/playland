using System;
public static class FibonacciSerios{
    public static void Run(){
      //fib(10);
      Console.WriteLine(fib2(6));  
    }
    
    public static void fib(int len){
        
        int n1=0, n2=1, n3=0;
        Console.WriteLine(n1);
        Console.WriteLine(n2);
        for (int i=2;i<=len;i++){
            n3=n1+n2;
            Console.WriteLine(n3);
            n1=n2;
            n2=n3;
        }
    }

    public static int fib2(int x){
        if(x==0) return 0;
        if(x==1) return 1;
        return fib2(x-1) + fib2(x-2);
    }
}