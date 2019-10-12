using System;

public static class NodeListHelper{
     public static void PrintNodeList(this ListNode l){
        if(l!=null) Console.WriteLine(l.val);
        if(l.next !=null) PrintNodeList(l.next);
    }


    public static ListNode CreateNodeList(this int[] arr){
        
        var dummyListNode= new ListNode(0);
        if(arr.Length==0) return dummyListNode;
        var result= dummyListNode;
        for(int i=0; i<arr.Length;i++){
            result.next=new ListNode(arr[i]);
            result=result.next;
        }
        return dummyListNode.next;
    }
}

 public class ListNode {
        public int val;
        public ListNode next;
        public ListNode(int x) { val=x;}
}

public class Node{
    public int val;
    public Node next;
    public Node random;
    public Node(int x){
        val=x;
    }
}

 public class TreeNode {
      public int val;
      public TreeNode left;
      public TreeNode right;
      public TreeNode(int x) { val = x; }
 }