using System;

public static class NodeListHelper{
     public static void PrintNodeList(this ListNode l){
        if(l!=null) Console.WriteLine(l.val);
        if(l.next !=null) PrintNodeList(l.next);
    }
}

 public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val=x;}
}