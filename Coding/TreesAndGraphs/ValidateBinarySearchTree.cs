using System;
using System.Collections.Generic;
public class ValidateBST{
    public void Run(){
        var root= new TreeNode(2);
        root.left=new TreeNode(1);
        root.right=new TreeNode(3);
        Console.WriteLine(IsValidBST(root));

    }

    public bool IsValidBST(TreeNode root) {
     var stack = new Stack<TreeNode>();
     double inorder = -Double.MaxValue;
        while (!(stack.Count==0) || root != null) {
            while (root != null) {
                stack.Push(root);
                root = root.left;
            }
            root = stack.Pop();

            if (root.val <= inorder) return false;
            inorder = root.val;
            root = root.right;
        }
        return true;
    }
}