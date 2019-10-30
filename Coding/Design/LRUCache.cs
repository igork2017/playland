using System;
using System.Collections.Generic;

public class LRUCacheMain{
    public void Run(){
        var cache = new LRUCache(2);
        cache.Put(1,1);
        cache.Put(2,2);
        Console.WriteLine(cache.Get(1));
        cache.Put(3,3);
        Console.WriteLine(cache.Get(2));
        cache.Put(4,4);
        Console.WriteLine(cache.Get(1));
        Console.WriteLine(cache.Get(3));
        Console.WriteLine(cache.Get(4));
    }

}

public class LRUCache{
     public class LinkedNode {
      public int val;
      public int key;
      public LinkedNode next;
      public LinkedNode prev;
      public LinkedNode(){}
      public LinkedNode(int x, int y) {key=x; val = y; next= new LinkedNode(); prev=new LinkedNode();}
 }

    private void AddNode(LinkedNode node){
        node.prev=head;
        node.next=head.next;

        head.next.prev=node;
        head.next=node;
    }

    private void RemoveNode(LinkedNode node){
        var prev=node.prev;
        var next=node.next;  

        prev.next=next;   
        next.prev=prev;        
    }

    private void MoveToHead(LinkedNode node){
        RemoveNode(node);
        AddNode(node);
    }

    private LinkedNode PopTail(){
        var res= tail.prev;
        RemoveNode(res);
        return res;
    }

    private Dictionary<int,LinkedNode> cache = new Dictionary<int, LinkedNode>();
    private int size;
    private int capacity;
    private LinkedNode head, tail;
    public LRUCache(int capacity) {
        this.size=0;
        this.capacity=capacity;

        head=new LinkedNode();
        tail=new LinkedNode();
        head.next=tail;
        tail.prev=head;
    }
    
    public int Get(int key) {
        var node= cache.ContainsKey(key)?cache[key]:null;
        if(node==null) return -1;
        MoveToHead(node);
        return node.val;
    }
    
    public void Put(int key, int value) {
        var node= cache.ContainsKey(key)?cache[key]:null;
        if(node==null){
            var newNode= new LinkedNode(key,value);
            cache.Add(key, newNode);
            AddNode(newNode);
            size++;
            if(size>capacity){
                var tail=PopTail();
                cache.Remove(tail.key);
                size--;
            }
        }
        else{
            node.val=value;
            MoveToHead(node);
        }
    }
}