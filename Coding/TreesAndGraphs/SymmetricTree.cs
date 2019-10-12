using System;
using System.Collections.Generic;

public class SymmetricTree{
    public void Run(){
        var root= new TreeNode(1);
        root.left=new TreeNode(2);
        root.right=new TreeNode(2);
        root.left.left=new TreeNode(3);
        root.right.right=new TreeNode(3);
        root.left.right=new TreeNode(4);
        root.right.left=new TreeNode(4);
        Console.WriteLine(IsSymmetric(root));
    }
    public bool IsSymmetric(TreeNode root) {
        var q= new Queue<TreeNode>();
        q.Enqueue(root);
        q.Enqueue(root);
        while(q.Count!=0){
            var t1=q.Dequeue();
            var t2=q.Dequeue();
            if(t1==null && t2==null) continue;
            if(t1==null || t2==null) return false;
            if(t1.val!=t2.val) return false;
            q.Enqueue(t1.left);
            q.Enqueue(t2.right);
            q.Enqueue(t1.right);
            q.Enqueue(t2.left);
        }
        return true;
    }
}