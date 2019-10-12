using System;

public class CopyListWithRandomPointer{
    public void Run(){
        var n1=new Node(1);
        n1.next=new Node(2);
        n1.random=n1.next;
        n1.next.random=n1.next;
        
    }
/*     public Node CopyRandomList(Node head) {
        return new Node(0);
    } */

}