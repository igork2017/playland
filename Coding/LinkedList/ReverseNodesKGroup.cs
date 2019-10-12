using System;

public class ReverseNodes{
    public void Run(){
        var listValues=new int[]{1,2,3,4,5 };
        var input = listValues.CreateNodeList();
        ReverseKGroup(input, 3).PrintNodeList();
    }
    public ListNode ReverseKGroup(ListNode head, int k) {
        var curr= head;
        int count=0;
        while (curr!=null && count!=k)
        {
            curr=curr.next;
            count++;
        }
        if(count==k){
            curr=ReverseKGroup(curr,k);
            while(count>0){
                ListNode next=head.next;
                head.next=curr;
                curr=head;
                head=next;
                count--;
            }
            head=curr;
        }
        return head;
    }
}