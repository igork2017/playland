using System;

public class MergeKSortedLists{
    public void Run(){
        var l1=new int[]{1,4,5};
        var l2=new int[]{1,3,4};
        var l3 =new int[]{2,6};
        var input = new ListNode[]{l1.CreateNodeList(),l2.CreateNodeList(), l3.CreateNodeList()};
        var result=MergeKLists(input);
        result.PrintNodeList();
    }

    public ListNode MergeKLists(ListNode[] lists) {
        var length=lists.Length;
        var dummyHead = new ListNode(0);
       
        ListNode temp=lists[0];
        for(int i=1;i<length;i++){
            ListNode curr =dummyHead;
            while (temp!=null && lists[i]!=null){
                if(temp.val<lists[i].val){
                    curr.next=temp;
                    temp=temp.next;
                }
                else{
                    curr.next=lists[i];
                    lists[i]=lists[i].next;
                }
                curr=curr.next;
            }
            curr.next=temp==null?lists[i]:temp;
            temp=curr;
        }
        return dummyHead.next;
    }
}