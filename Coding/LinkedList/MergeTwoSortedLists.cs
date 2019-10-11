using System;

public class MergeTwoSortedLists{
       
    public void Run(){
        var l=new ListNode(1);
        l.next = new ListNode(2);
        l.next.next= new ListNode(4);
        var s = new ListNode(1);
        s.next = new ListNode(3);
        s.next.next = new ListNode(4);
        var result = MergeTwoLists(l, s);
        result.PrintNodeList();
    }

    public ListNode MergeTwoLists(ListNode l1, ListNode l2) {
        var dummyHead= new ListNode(0);
        var curr = dummyHead;
        while (l1!=null && l2!=null){
           if(l1.val<l2.val){
               curr.next=l1;
               l1=l1.next;
           }
           else{
               curr.next=l2;
               l2=l2.next;
           }
           curr=curr.next;
        }
        curr.next=l1==null?l2:l1;

        return dummyHead.next;
    }

    public ListNode MergeTwoLists2(ListNode l1, ListNode l2){
        if(l1==null)
            return l2;
        if(l2==null)
            return l1;
        if(l1.val<l2.val){
            l1.next= MergeTwoLists2(l1.next,l2);
            return l1;
        }
        else{
            l2.next = MergeTwoLists2(l1,l2.next);
            return l2;
        }
    }
}