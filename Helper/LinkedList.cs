using System;


public class LinkedList{
    public Node head = null;   

    public class Node{
        private int _data;
        private Node _next;
        public Node(int x){
            _data=x;
            _next=null;
        }    
        public Node Next {get { return _next; } set { _next=value; }}
        public int Data => _data;
    }
public LinkedList GetLinkedList(){
    var linkedList= new LinkedList();
        var node1 = new Node(1);
        var node2 = new Node(2);
        var node3 = new Node(3);
        var node4 = new Node(4);
        var node5 = new Node(5);
        linkedList.head=node1;
        node1.Next=node2;
        node2.Next=node3;
        node3.Next=node4;
    return linkedList;
    }
    public void printList() 
    { 
        Node n = head; 
        while (n != null) { 
            Console.Write(n.Data + " "); 
            n = n.Next; 
        } 
    } 
}