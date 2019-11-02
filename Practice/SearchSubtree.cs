using System;
using System.Collections.Generic;
public class SearchSubtree{
    public void Run(){
/*         var s = new TreeNode(3);
        s.left=new TreeNode(4);
        s.right=new TreeNode(5);
        s.left.left=new TreeNode(1);
        s.left.right=new TreeNode(2);
        s.left.right.left=new TreeNode(0);

        var t =new TreeNode(4);
        t.left=new TreeNode(1);
        t.right=new TreeNode(2); */
        var s =new TreeNode(1);
        s.left=new TreeNode(1);
        var t=new TreeNode(1);
        Console.WriteLine(IsSubtree(s,t));
    }
    public bool IsSubtree2(TreeNode s, TreeNode t) {
        var nodeList=new List<TreeNode>();
        var queue= new Queue<TreeNode>();
        
        queue.Enqueue(s);       
        while(queue.Count>0){
            var cur= queue.Dequeue();
            if(cur.val==t.val) nodeList.Add(cur);
            if(cur.left !=null){
                queue.Enqueue(cur.left);
            }
            if(cur.right!=null){
                queue.Enqueue(cur.right);
            }
        }
        foreach(var n in nodeList)
        if(n!=null && n.val==t.val){
            if(ComapreNodes(n,t))
                return true;
        }
        return false;
    }

    private bool ComapreNodes(TreeNode s, TreeNode t){
        if(t==null && s!=null) return false;
        if(t!=null && s==null) return false;
        if(t==null && s==null) return true;
        if(s.val!=t.val) return false;
        var left=ComapreNodes(s.left,t.left);
        var right=ComapreNodes(s.right,t.right);
        if(right && left) return true;
        return false;
    }

    public bool equals(TreeNode x,TreeNode y)
    {
        if(x==null && y==null)
            return true;
        if(x==null || y==null)
            return false;
        return x.val==y.val && equals(x.left,y.left) && equals(x.right,y.right);
    }
    public bool traverse(TreeNode s,TreeNode t)
    {
        return  s!=null && ( equals(s,t) || traverse(s.left,t) || traverse(s.right,t));
    }

    public bool IsSubtree(TreeNode s, TreeNode t) {
        return traverse(s,t);
    }
}