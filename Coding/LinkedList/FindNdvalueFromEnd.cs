using System;

public static class FindNdValueFromEnd{
    public static void Run(){
        var linkedList = new LinkedList();
        var llist = linkedList.GetLinkedList();
        llist.printList();
        var result = nthToLast(llist.head,10);
        Console.WriteLine("New test");
        if(result == null) Console.WriteLine("Empty");
        else Console.WriteLine(result.Data);
    }
    public static LinkedList.Node nthToLast(LinkedList.Node node, int n)
     {
         LinkedList.Node curr=node;
         LinkedList.Node follower = node;
         for (int i=0; i<n; i++){            
             if(curr==null) return null;
             curr=curr.Next;
         }
         while(curr.Next!=null){
             curr=curr.Next;
             follower=follower.Next;
         }
        return follower;         
     }
}