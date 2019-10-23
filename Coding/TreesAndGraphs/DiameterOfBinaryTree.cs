using System;

public class DiameterOfTree{
    private int ans;
    public void Run(){
        var root=new TreeNode(1);
        root.left=new TreeNode(2);
        root.right=new TreeNode(3);
        root.left.left=new TreeNode(4);
        root.left.right=new TreeNode(5);
        Console.WriteLine(DiameterOfBinaryTree(root));
    }
    public int DiameterOfBinaryTree(TreeNode root) {
        ans=1;
        depth(root);
        return ans-1;
    }

    public int depth(TreeNode node){
        if(node==null) return 0;
        var L= depth(node.left);
        var R= depth(node.right);
        ans= Math.Max(ans,L+R+1);
        return Math.Max(L,R)+1;
    }
}