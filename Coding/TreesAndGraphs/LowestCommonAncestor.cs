using System;
using System.Collections.Generic;

public class LowestCommon{
    private TreeNode ans;

    public LowestCommon(){
        this.ans=null;
    }
    public void Run(){
        var one=new TreeNode(3);
        var second=new TreeNode(5);
        var third=new TreeNode(1);
        one.left=second;
        one.right=third;
        second.left=new TreeNode(6);
        second.right=new TreeNode(2);
        second.right.left=new TreeNode(7);
        second.right.right=new TreeNode(4);
        third.left=new TreeNode(0);
        third.right=new TreeNode(8);
        var p=new TreeNode(5);
        var q= new TreeNode(1);
        var result= LowestCommonAncestor_Recursion(one,p,q);
        Console.WriteLine(result.val);
    }
    public TreeNode LowestCommonAncestor(TreeNode root, TreeNode p, TreeNode q) {
        RecourceTree(root, p, q);
        return this.ans;
    }

    bool RecourceTree(TreeNode current, TreeNode p, TreeNode q){
        if(current==null) return false;
        var left=RecourceTree(current.left, p, q)?1:0;
        var right=RecourceTree(current.right,p,q)?1:0;
        var mid= (current.val==p.val || current.val==q.val)?1:0;
        if(mid+left+right >=2) this.ans=current;
        return (mid+left+right>0);
    }

     public TreeNode LowestCommonAncestor_Recursion(TreeNode root, TreeNode p, TreeNode q) {
        var stack = new Stack<TreeNode>();
        var parent= new Dictionary<int,TreeNode>();
        parent.Add(root.val, null);
        stack.Push(root);

        while(!parent.ContainsKey(p.val) || !parent.ContainsKey(q.val)){
            var node=stack.Pop();
            if(node.left!=null){
                parent.Add(node.left.val, node);
                stack.Push(node.left);
            }

            if(node.right!=null){
                parent.Add(node.right.val,node);
                stack.Push(node.right);
            }
        }
        
        var list = new List<TreeNode>();
        while(p!=null){
            list.Add(p);
            p=parent[p.val];
        }

        while(!list.Contains(q)){
            q=parent[q.val];
        }

        return q;
    }
}