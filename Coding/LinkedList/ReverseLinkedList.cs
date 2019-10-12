using System;

public class ReverseLinkedList{
    public void Run(){
       var input = new int[]{1,2,3,4,5};
       var m= input.CreateNodeList();
       m.PrintNodeList();
       var s = ReverseList(m);
       if(s!=null)
            s.PrintNodeList();
    }

    public ListNode ReverseList(ListNode head) {
        ListNode next=null;
        ListNode prev= null;
        var curr=head;
        while(curr!=null){
            next=curr.next;
            curr.next=prev;
            prev=curr;
            curr=next;
        }
        return prev;
    }
}