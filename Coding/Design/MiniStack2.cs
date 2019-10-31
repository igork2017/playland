using System;

public class MinStack2{
    public void Run(){
        MinStackR minStack = new MinStackR();
/*         minStack.Push(-2);
        minStack.Push(0);
        minStack.Push(-3);
        Console.WriteLine(minStack.GetMin());   // Returns -3.
        minStack.Pop();
        Console.WriteLine(minStack.Top());      // Returns 0.
        Console.WriteLine(minStack.GetMin());   // Returns -2. */
        minStack.Push(2147483646);
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
        Console.WriteLine(minStack.GetMin()); // 2147483647
       
    }
}
    public class MinStackR {
        public class ListNode {
            public int val;
            public ListNode next;
            public ListNode(int x) { val=x;}
        }

        private void AddNode(int number){
            if(head.next==null) head.next=new ListNode(number);
            var s= head.next;
            head.next=new ListNode(number);
            head.next.next=s;
            if(min==null) min.next=head.next;
            if(min.val>=number){
                var next=min;
                min=new ListNode(number);
                min.next=next;
            }
        }
        private ListNode head;
        private ListNode min;
        public MinStackR() {
            head=new ListNode(-1);
            min=new ListNode(Int32.MaxValue);
        }
    
        public void Push(int x) {
            AddNode(x);
        }
    
        public void Pop() {
            var t = head.next;
            if(t!=null){
               head.next=head.next.next;     
            }
            if(t.val==min.val){
                var m= min.next;
                min=m;
            }                
        }
        
        public int Top() {
            return head.next.val;
        }
        
        public int GetMin() {
        return min.val;
        }
    }
