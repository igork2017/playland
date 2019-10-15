using System;
using System.Collections.Generic;

public class BinaryTreeTraversal{
    public void Run(){
        var root=new TreeNode(3);
        var left1=new TreeNode(9);
        var right1=new TreeNode(20);
        var right1_left2=new TreeNode(15);
        var right1_right2=new TreeNode(7);
        right1.right=right1_right2;
        right1.left=right1_left2;
        root.left=left1;
        root.right=right1;
        var result= LevelOrder(root);

    }

    public IList<IList<int>> LevelOrder(TreeNode root) {
        var result = new List<IList<int>>();
        if(root == null) return result;
        var queue= new Queue<TreeNode>();
        queue.Enqueue(root);
        int level=0;
        while(queue.Count!=0){
            result.Add(new List<int>());
            var level_length=queue.Count;
            for(int i=0;i<level_length;i++){
                var node=queue.Dequeue();
                Console.WriteLine(node.val);
                result[level].Add(node.val); 
                if(node.left!=null) queue.Enqueue(node.left);
                if(node.right!=null ) queue.Enqueue(node.right);               
            }            
            level++;
        }
        return result;
    }
    private IList<IList<int>> levels=new List<IList<int>>();
    public IList<IList<int>> LevelOrderRecursive(TreeNode root) {
        if(root==null) return levels;
        helper(root,0);
        return levels;
    }

    public void helper(TreeNode node, int level){
        if(levels.Count==level)  levels.Add(new List<int>());

        levels[level].Add(node.val);

        if(node.left!=null) helper(node.left, level+1);
        if(node.right!=null) helper(node.right, level+1);


    }
}