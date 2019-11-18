using System;

public class CopyListWithRandomPointer{
    public void Run(){
        var n1=new Node(1);
        n1.next=new Node(2);
        n1.random=n1.next;
        n1.next.random=n1.next;
        
    }
     public Node CopyRandomList(Node head) {
        if(head==null) return head;
        var curr=head;
        Node temp=null;
        while(curr!=null){
            temp=curr.next;
            curr.next=new Node(curr.val,null,null);
            curr.next.next=temp;
            curr=temp;
        }
        curr=head;
        
        while(curr!=null){
            if(curr.next!=null){
                curr.next.random= curr.random!=null? curr.random.next:null;
            }
            curr=curr.next!=null?curr.next.next:null;
        }
        var original=head;
        var copy=head.next;
        temp=copy;
        while(original!=null && copy!=null){
            original.next = (original.next != null)? original.next.next : null;  
  
            copy.next = (copy.next != null) ? copy.next.next: null;  
            original = original.next;  
            copy = copy.next; 
        }
        return temp;   
    } 

}