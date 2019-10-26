using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

public class ToKFriequentElements{
    public void Run(){
        var nums = new int[] {1,1,1,2,2,3};
        var k = 2;
        var result=topKFrequent(nums,k);
        foreach(var i in result)
            Console.WriteLine(i);
    }
    public List<int> topKFrequent(int[] nums, int k) {
    // build hash map : character and how often it appears
    Dictionary<int, int> count = new Dictionary<int, int>();
    foreach (var n in nums) {
        if(count.ContainsKey(n)){
            count[n]++;
        }
        else{
            count.Add(n,1);
        }
    }
      // init heap 'the less frequent element first'
    var heap = new Queue<int>();

    // keep k top frequent elements in the heap
 /*    foreach (var n in count.Keys) {
      heap.Enqueue(n);
      if (heap.Count > k)
        heap.Dequeue();
    } */
    var list=new List<Point>();
     foreach (var n in count.Keys) {
         list.Add(new Point(n,count[n]));
     }

    var sortedList= list.OrderByDescending(m=>m.Y).ToList();

    // build output list
    List<int> top_k = new List<int>();
   /*  while (heap.Count>0)
      top_k.Add(heap.Dequeue());
    top_k.Reverse(); */
    for(int i=0;i<k;i++){
        top_k.Add(sortedList[i].X);
    }
    return top_k;
  }
}