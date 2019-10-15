using System;
using System.Collections.Generic;

public class Zigzag{
    public void Run(){
        var root=new TreeNode(1);
        var left1=new TreeNode(2);
        var right1=new TreeNode(3);
        var right1_left2=new TreeNode(4);
        var right1_right2=new TreeNode(5);
        right1.right=right1_right2;
        left1.left=right1_left2;
        root.left=left1;
        root.right=right1;
        var result= ZigzagLevelOrder(root);
    }

    public IList<IList<int>> ZigzagLevelOrder(TreeNode root) {
        var result = new List<IList<int>>();
        if(root == null) return result;
        var queue= new Queue<TreeNode>();
        var leftToRight = true;
        queue.Enqueue(root);
        int level=0;
        while(queue.Count!=0){           
            var level_length=queue.Count;
             result.Add(new List<int>());
            for(int i=0;i<level_length;i++){
                var node=queue.Dequeue();
                if(!leftToRight){ 
                  result[level].Insert(0, node.val);  
                }    
                else{
                   result[level].Add(node.val); 
                }
                if(node.left!=null) queue.Enqueue(node.left);
                if(node.right!=null ) queue.Enqueue(node.right);           
            } 
            leftToRight=!leftToRight;           
            level++;
        }
        return result;
    }
    
    private IList<IList<int>> levels=new List<IList<int>>();
    public IList<IList<int>> ZigZagLevelOrder2(TreeNode root) {
        if(root==null) return levels;
        var isLeft=false;
        helper(root,0,isLeft);
        return levels;
    }

    public void helper(TreeNode node, int level, bool isleft){
        if(levels.Count==level)  levels.Add(new List<int>());

        levels[level].Add(node.val);
        var _isleft=!isleft;
        if(isleft){
            if(node.left!=null) helper(node.left, level+1,_isleft);
            if(node.right!=null) helper(node.right, level+1,_isleft);
        }
        else{
            if(node.right!=null) helper(node.right, level+1,_isleft);
             if(node.left!=null) helper(node.left, level+1,_isleft);       
        }
    }
}