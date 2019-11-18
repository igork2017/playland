using System;
using System.Collections.Generic;

public class MinStackSample{
    public void Run(){
        MinStack minStack = new MinStack();
/*         minStack.Push(-2);
        minStack.Push(0);
        minStack.Push(-3);
        Console.WriteLine(minStack.GetMin());   // Returns -3.
        minStack.Pop();
        Console.WriteLine(minStack.Top());      // Returns 0.
        Console.WriteLine(minStack.GetMin());   // Returns -2. */
/*         minStack.Push(2147483646);
        minStack.Push(2147483646);
        minStack.Push(2147483647);
        Console.WriteLine(minStack.Top()); //2147483647
        minStack.Pop();
        Console.WriteLine(minStack.GetMin()); // 2147483646
        minStack.Pop();
        Console.WriteLine(minStack.GetMin()); // 2147483646
        minStack.Pop();
        minStack.Push(2147483647);
        Console.WriteLine(minStack.Top()); //2147483647
        Console.WriteLine(minStack.GetMin()); //2147483647
        minStack.Push(-2147483648);
        Console.WriteLine(minStack.Top()); // -2147483648
        Console.WriteLine(minStack.GetMin()); // -2147483648
        minStack.Pop();
        Console.WriteLine(minStack.GetMin()); // 2147483647 */
       
    }
}
public class MinStack {
  /*   private Stack<int> stack;
    private int min;
    public MinStack() {
        stack=new Stack<int>();
    }
    
    public void Push(int x) {
        if(stack.Count==0){
            min=x;
            stack.Push(x);
            return;
        }
        if(x<min){
            stack.Push(2*x-min);
            min=x;
        }
        else{
            stack.Push(x);
        }
    }
    
    public void Pop() {
        if(stack.Count==0) return;
        var t=stack.Pop();
        if(t<min){
            min=2*min -t;
        }
    }
    
    public int Top() {
        var t = stack.Peek();
        if(t<min){
            return min;
        }
        else{
            return t;
        }
    }
    
    public int GetMin() {
        if(stack.Count==0) return Int32.MinValue;
        return min;
    } */
}
