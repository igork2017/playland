using System;

public class TwoNumbers {
    public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val=x;}
    }

    public void Run(){
        var l=new ListNode(2);
        l.next = new ListNode(4);
        l.next.next= new ListNode(3);
        var s = new ListNode(5);
        s.next = new ListNode(6);
        s.next.next = new ListNode(4);
        var result = AddTwoNumbers(l, s);
        Console.WriteLine(result.val);
        Console.WriteLine(result.next.val);
        Console.WriteLine(result.next.next.val);
    }

    public ListNode AddTwoNumbers(ListNode l1, ListNode l2){
        var dummyHead =new ListNode(0);
        var p=l1; 
        var q=l2;
        var curr = dummyHead;
        var carry=0;
        while(p!=null || q!=null){
            var x = (p!=null)? p.val:0;
            var y= (q!=null)? q.val:0;
            int sum = carry + x +y;
            carry = sum/10;
            curr.next=new ListNode(sum%10);
            curr = curr.next;
            if(p!=null) p=p.next;
            if(q!=null) q=q.next;
        }
        if(carry>0){
            curr.next=new ListNode(carry);
        }
        return dummyHead.next;
    }    
}